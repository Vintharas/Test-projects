using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Shooter.Graphics;
using Shooter.Model;

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        // PLAYER
        private Player player;
        // ENEMIES
        private List<Enemy> enemies;
        // The rate at which enemies appear
        private TimeSpan enemySpawnTime;
        private TimeSpan previousSpawnTime;
        // A Random number generator
        private Random random;
        // EXPLOSIONS
        private Texture2D explosionTexture;
        private List<Animation> explosions;
 
        // SCORE and PLAYER HEALTH UI
        private const string SCORE = "Score :";
        private const string HEALTH = "Health :";
        private int score;
        private GameText scoreText;
        private GameText playerHealthText;

        // BACKGROUND
        private Texture2D mainBackground;
        // Parallaxing layers
        private ParallaxingBackground bgLayer1;
        private ParallaxingBackground bgLayer2;
        
        // MUSIC AND SOUND EFFECTS
        private SoundEffect laserSound;
        private SoundEffect explosionSound;
        private Song gameplayMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // You add your initialization logic here
            // Player
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Services.AddService(typeof(SpriteBatch), spriteBatch);
            // Background
            bgLayer1 = new ParallaxingBackground(this, -1, "bgLayer1");
            bgLayer2 = new ParallaxingBackground(this, -2, "bgLayer2");
            Components.Add(bgLayer1);
            Components.Add(bgLayer2);
            // Add player 
            player = new Player(this, new Vector2(0, GraphicsDevice.Viewport.Height / 2));
            Components.Add(player);
            // Enemies
            enemies = new List<Enemy>();
            previousSpawnTime = TimeSpan.Zero;
            enemySpawnTime = TimeSpan.FromSeconds(1.0f);
            random = new Random();
            // Explosions
            explosions = new List<Animation>();
            // Game Text
            score = 0;
            scoreText = new GameText(this, SCORE + score, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
                                               GraphicsDevice.Viewport.TitleSafeArea.Y));
            playerHealthText = new GameText(this, HEALTH + player.Health, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
                                               GraphicsDevice.Viewport.TitleSafeArea.Y + 30));
            Components.Add(scoreText);
            Components.Add(playerHealthText);
            // Enable drag gesture
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            // Load music
            gameplayMusic = Content.Load<Song>("sound/gameMusic");
            laserSound = Content.Load<SoundEffect>("sound/laserFire");
            explosionSound = Content.Load<SoundEffect>("sound/explosion");
            // Play music
            PlayMusic(gameplayMusic);
            // Load explosion content
            explosionTexture = Content.Load<Texture2D>("explosion");
            // Load background resources
            //bgLayer1.Initialize(Content, "bgLayer1", GraphicsDevice.Viewport.Width, -1);
            //bgLayer2.Initialize(Content, "bgLayer2", GraphicsDevice.Viewport.Width, -2);
            mainBackground = Content.Load<Texture2D>("mainbackground");
        }

        private void PlayMusic(Song song)
        {
            // Due to the way the media player plays music,
            // we have to catch the exception. Music will play when the game is not tethered
            try
            {
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true; // Loop the currently played song
            }
            catch {}

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // Add your update logic here
            UpdatePlayer(gameTime);
            UpdateEnemies(gameTime);
            UpdateExplosions(gameTime);
            UpdateGameText();
            UpdateCollision();
            base.Update(gameTime);
        }

        private void UpdateGameText()
        {
            scoreText.Text = SCORE + score;
            playerHealthText.Text = HEALTH + player.Health;
        }

        private void UpdatePlayer(GameTime gameTime)
        {
            // Reset score if player health goes to zero
            if (player.Health <= 0)
            {
                player.Health = 100;
                score = 0;
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            // Spawn a new enemy every 1.5 seconds
            if (gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime)
            {
                previousSpawnTime = gameTime.TotalGameTime;
                AddEnemy();
            }
            // Update all enemies
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (!enemies[i].Active)
                {
                    if (enemies[i].Health <= 0) // If the enemy has been destroyed create explotion
                    {
                        AddExplosion(enemies[i].Position);
                        explosionSound.Play(.1f, 0f, 0f);
                        score += enemies[i].Value;
                    }
                    Components.Remove(enemies[i]);
                    enemies.RemoveAt(i);
                }
            }
        }

        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                explosions[i].Update(gameTime);
                if (!explosions[i].Active)
                    explosions.RemoveAt(i);
            }
        }

        private void UpdateCollision()
        {
            // Check collisions between player and enemies
            foreach (var enemy in enemies)
            {
                if (player.CollidedWith(enemy))
                {
                    // Substract health from the player based on enemy's damage
                    player.Health -= enemy.Damage;
                    // Destroy enemy
                    enemy.Health = 0;
                    // If the player health is less than zero he died
                    if (player.Health <= 0)
                        player.Active = false;
                }
            }
            // Check collisions between enemy and laser
            foreach (var projectile in player.Projectiles)
            foreach (var enemy in enemies)
            {
                if (projectile.CollidedWith(enemy))
                {
                    enemy.Health -= projectile.Damage;
                    projectile.Active = false;
                }
            }
        }

        private void AddEnemy()
        {
            // Create the animation object
            // Randomy generate the position of the enemy
            Vector2 position = new Vector2(
                GraphicsDevice.Viewport.Width,
                random.Next(100, GraphicsDevice.Viewport.Height - 100));
            // Create an enemy
            Enemy enemy = new Enemy(this, position);
            // Add the enemy to the active enemies list
            enemies.Add(enemy);
            Components.Add(enemy);
        }

        private void AddExplosion(Vector2 position)
        {
            Animation explosion = new Animation();
            explosion.Initialize(
                explosionTexture,
                position,
                134, 134, 12, 45,
                Color.White,
                1f,
                false);
            explosions.Add(explosion);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Add your drawing code here
            spriteBatch.Begin();
            // Background
            spriteBatch.Draw(mainBackground, Vector2.Zero, Color.White);
            base.Draw(gameTime);
            // Explosions
            foreach (var explosion in explosions)
                explosion.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
