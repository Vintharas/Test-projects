using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Shooter.Graphics;
using Shooter.Mechanics;

namespace Shooter.Model
{
    public class Player : CollisionableGameComponent
    {
        private const int PLAYER_HEALTH = 100;
        private const float PLAYER_SPEED = 8.0f;
        private const float PLAYER_FIRE_TIME = .15f;
        private SpriteBatch spriteBatch;

        public Vector2 Position { get { return position; } set { position = value; } }
        private Vector2 position;
        public bool Active { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }

        public Animation Animation { get; set; }
        public int Width { get { return Animation.FrameWidth; } }
        public int Height { get { return Animation.FrameHeight; } }

        // The rate of fire of the player laser
        private TimeSpan fireTime;
        private TimeSpan previousFireTime;
        // Player projectiles
        public List<Projectile> Projectiles { get; set; }

        public Player(Game game, Vector2 position) : base(game)
        {
            Position = position;
            Active = true;
            Health = PLAYER_HEALTH;
            Speed = PLAYER_SPEED;
            Projectiles = new List<Projectile>();
        }

        public override void Initialize()
        {
            fireTime = TimeSpan.FromSeconds(PLAYER_FIRE_TIME);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            // Load player resources
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Game.Content.Load<Texture2D>("shipAnimation");
            Vector2 playerPosition = new Vector2(
                GraphicsDevice.Viewport.TitleSafeArea.X,
                GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            playerAnimation.Initialize(playerTexture, Vector2.Zero,
                                       115, 69, 8, 30, Color.White, 1f, true);
            Animation = playerAnimation;
            base.LoadContent();
        }

        private KeyboardState currentKeyboardState;
        private GamePadState currentGamePadState;

        public override void Update(GameTime gameTime)
        {
            //Windows phone inputs
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            // Update player position based on inputs
            UpdatePlayerPosition();
            // Fire only every interval we set as the fireTime
            if (gameTime.TotalGameTime - previousFireTime > fireTime)
            {
                previousFireTime = gameTime.TotalGameTime; // Reset current time
                AddProjectile(Position + new Vector2(Width / 2, 0));
            }
            //laserSound.Play(.5f, 0f, 0f);
            // Update Animation
            Animation.Position = Position;
            Animation.Update(gameTime);
            UpdateProjectiles(gameTime);
            base.Update(gameTime);
        }

        private void UpdateProjectiles(GameTime gameTime)
        {
            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                if (!Projectiles[i].Active)
                {
                    Game.Components.Remove(Projectiles[i]);
                    Projectiles.RemoveAt(i);
                }
            }
        }
        
        private void AddProjectile(Vector2 position)
        {
            Projectile projectile = new Projectile(Game, position);
            Projectiles.Add(projectile);
            Game.Components.Add(projectile);
        }

        private void UpdatePlayerPosition()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                    Position += gesture.Delta;
            }
            // GamePad thumbstick inputs
            position.X += currentGamePadState.ThumbSticks.Left.X*Speed;
            position.Y -= currentGamePadState.ThumbSticks.Left.Y * Speed;
            // Keyboard / Gamepad
            if (currentKeyboardState.IsKeyDown(Keys.Left) ||
                currentGamePadState.DPad.Left == ButtonState.Pressed)
                position.X -= Speed;
            if (currentKeyboardState.IsKeyDown(Keys.Right) ||
                currentGamePadState.DPad.Right == ButtonState.Pressed)
                position.X += Speed;
            if (currentKeyboardState.IsKeyDown(Keys.Up) ||
                currentGamePadState.DPad.Up == ButtonState.Pressed)
                position.Y -= Speed;
            if (currentKeyboardState.IsKeyDown(Keys.Down) ||
                currentGamePadState.DPad.Down == ButtonState.Pressed)
                position.Y += Speed;
        }

        public override void Draw(GameTime gameTime)
        {
            Animation.Draw(spriteBatch);
            base.Draw(gameTime);
        }

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Width, Height);
            }
        }
    }
}