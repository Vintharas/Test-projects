using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Shooter.Mechanics;
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
        // Keyboard input
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        // Gamepad input
        private GamePadState currentGamePadState;
        private GamePadState previousGamePadState;
        // Player movement speed
        private float playerMoveSpeed;
        
        // ENEMIES
        private Texture2D enemyTexture;
        private List<Enemy> enemies;
        // The rate at which enemies appear
        private TimeSpan enemySpawnTime;
        private TimeSpan previousSpawnTime;
        // A Random number generator
        private Random random;

        // PROJECTILES
        private Texture2D projectileTexture;
        private List<Projectile> projectiles;
        // The rate of fire of the player laser
        private TimeSpan fireTime;
        private TimeSpan previousFireTime;

        // EXPLOSIONS
        private Texture2D explosionTexture;
        private List<Animation> explosions;
 
        // SCORE
        private int score;
        private SpriteFont scoreFont;

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
            player = new Player();
            playerMoveSpeed = 8.0f;
            // Enemies
            enemies = new List<Enemy>();
            previousSpawnTime = TimeSpan.Zero;
            enemySpawnTime = TimeSpan.FromSeconds(1.0f);
            random = new Random();
            // Projectiles
            projectiles = new List<Projectile>();
            fireTime = TimeSpan.FromSeconds(.15f);
            // Explosions
            explosions = new List<Animation>();
            // Score
            score = 0;
            // Background
            bgLayer1 = new ParallaxingBackground();
            bgLayer2 = new ParallaxingBackground();
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load music
            gameplayMusic = Content.Load<Song>("sound/gameMusic");
            laserSound = Content.Load<SoundEffect>("sound/laserFire");
            explosionSound = Content.Load<SoundEffect>("sound/explosion");
            // Play music
            PlayMusic(gameplayMusic);
            // Load player resources
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("shipAnimation");
            Vector2 playerPosition = new Vector2(
                GraphicsDevice.Viewport.TitleSafeArea.X,
                GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height/2);
            playerAnimation.Initialize(playerTexture, Vector2.Zero,
                                       115, 69, 8, 30, Color.White, 1f, true);
            player.Initialize(playerAnimation, playerPosition);
            // Load enemy resources
            enemyTexture = Content.Load<Texture2D>("mineAnimation");
            // Load projectiles resources
            projectileTexture = Content.Load<Texture2D>("laser");
            // Load explosion content
            explosionTexture = Content.Load<Texture2D>("explosion");
            // Load score font
            scoreFont = Content.Load<SpriteFont>("gameFont");
            // Load background resources
            bgLayer1.Initialize(Content, "bgLayer1", GraphicsDevice.Viewport.Width, -1);
            bgLayer2.Initialize(Content, "bgLayer2", GraphicsDevice.Viewport.Width, -2);
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
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            UpdatePlayer(gameTime);
            UpdateEnemies(gameTime);
            UpdateProjectiles();
            UpdateExplotions(gameTime);
            UpdateBackground(gameTime);
            UpdateCollision();
            base.Update(gameTime);
        }

        private void UpdatePlayer(GameTime gameTime)
        {
            player.Update(gameTime);
            //Windows phone inputs
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                    player.Position += gesture.Delta;
            }
            // GamePad thumbstick inputs
            player.Position.X += currentGamePadState.ThumbSticks.Left.X*playerMoveSpeed;
            player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y*playerMoveSpeed;
            // Keyboard / Gamepad
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
                currentGamePadState.DPad.Left == ButtonState.Pressed)
                player.Position.X -= playerMoveSpeed;
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
                currentGamePadState.DPad.Right == ButtonState.Pressed)
                player.Position.X += playerMoveSpeed;
            if (currentKeyboardState.IsKeyDown(Keys.Up) ||
                currentGamePadState.DPad.Up == ButtonState.Pressed)
                player.Position.Y -= playerMoveSpeed;
            if (currentKeyboardState.IsKeyDown(Keys.Down) ||
                currentGamePadState.DPad.Down == ButtonState.Pressed)
                player.Position.Y += playerMoveSpeed;
            // Fire only every interval we set as the fireTime
            if (gameTime.TotalGameTime - previousFireTime > fireTime)
            {
                previousFireTime = gameTime.TotalGameTime; // Reset current time
                AddProjectile(player.Position + new Vector2(player.Width/2, 0));
            }
            //laserSound.Play(.5f, 0f, 0f);
            // Reset score if player health goes to zero
            if (player.Health <= 0)
            {
                player.Health = 100;
                score = 0;
            }
        }

        private void UpdateBackground(GameTime gameTime)
        {
            bgLayer1.Update();
            bgLayer2.Update();
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
                enemies[i].Update(gameTime);
                if (!enemies[i].Active)
                {
                    if (enemies[i].Health <= 0) // If the enemy has been destroyed create explotion
                    {
                        AddExplosion(enemies[i].Position);
                        explosionSound.Play(.1f, 0f, 0f);
                        score += enemies[i].Value;
                    }
                    enemies.RemoveAt(i);
                }
            }
        }

        private void UpdateProjectiles()
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update();
                if (!projectiles[i].Active)
                    projectiles.RemoveAt(i);
            }
        }

        private void UpdateExplotions(GameTime gameTime)
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
            // Use the Rectangle's built-in intersect function to determine if
            // two objects are overlapping
            Rectangle playerBoundingBox;
            Rectangle enemyBoundingBox;
            // Player bounding box
            playerBoundingBox = new Rectangle(
                (int) player.Position.X,
                (int) player.Position.Y,
                player.Width, player.Height);
            // Check collisions between player and enemies
            foreach (var enemy in enemies)
            {
                enemyBoundingBox = new Rectangle(
                    (int) enemy.Position.X, (int) enemy.Position.Y,
                    enemy.Width, enemy.Height);
                if (playerBoundingBox.Intersects(enemyBoundingBox))
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
            Rectangle projectileBoundingBox;
            // Check collisions between enemy and laser
            foreach (var projectile in projectiles)
            foreach (var enemy in enemies)
            {
                // Create bounding box we need to determine collisions
                projectileBoundingBox = new Rectangle(
                    (int) projectile.Position.X - projectile.Width/2,
                    (int) projectile.Position.Y - projectile.Height/2,
                    projectile.Width, projectile.Height);
                enemyBoundingBox = new Rectangle(
                    (int) enemy.Position.X - enemy.Width/2,
                    (int) enemy.Position.Y - enemy.Height/2,
                    enemy.Width, enemy.Height);
                // Determine collision
                if (projectileBoundingBox.Intersects(enemyBoundingBox))
                {
                    enemy.Health -= projectile.Damage;
                    projectile.Active = false;
                }
            }
        }

        private void AddEnemy()
        {
            // Create the animation object
            Animation enemyAnimation = new Animation();
            enemyAnimation.Initialize(enemyTexture, Vector2.Zero, 47, 61, 8, 30, Color.White, 1f, true);
            // Randomy generate the position of the enemy
            Vector2 position = new Vector2(
                GraphicsDevice.Viewport.Width + enemyTexture.Width/2,
                random.Next(100, GraphicsDevice.Viewport.Height - 100));
            // Create an enemy
            Enemy enemy = new Enemy();
            enemy.Initialize(enemyAnimation, position);
            // Add the enemy to the active enemies list
            enemies.Add(enemy);
        }

        private void AddProjectile(Vector2 position)
        {
            Projectile projectile = new Projectile();
            projectile.Initialize(GraphicsDevice.Viewport, projectileTexture, position);
            projectiles.Add(projectile);
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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // Background
            spriteBatch.Draw(mainBackground, Vector2.Zero, Color.White);
            bgLayer1.Draw(spriteBatch);
            bgLayer2.Draw(spriteBatch);
            // Enemies
            foreach (var enemy in enemies)
                enemy.Draw(spriteBatch);
            // Projectiles
            foreach (var projectile in projectiles)
                projectile.Draw(spriteBatch);
            // Explosions
            foreach (var explosion in explosions)
                explosion.Draw(spriteBatch);
            // Score
            spriteBatch.DrawString(scoreFont, "score: " + score,
                                   new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
                                               GraphicsDevice.Viewport.TitleSafeArea.Y),
                                   Color.White);
            // Draw the player health
            spriteBatch.DrawString(scoreFont, "health: " + player.Health,
                                   new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
                                               GraphicsDevice.Viewport.TitleSafeArea.Y + 30),
                                   Color.White);
            // Player
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
