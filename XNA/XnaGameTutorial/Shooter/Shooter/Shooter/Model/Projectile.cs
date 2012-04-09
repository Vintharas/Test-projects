using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Mechanics;

namespace Shooter.Model
{
    public class Projectile : CollisionableGameComponent
    {
        private const int PROJECTILE_DAMAGE = 2;
        private const float PROJECTILE_SPEED = 20f;

        public Texture2D Texture { get; set; }  // Image representing the projectile
        public Vector2 Position { get { return position; } set { position = value; } }  // Position of the projectile
        private Vector2 position;
        public bool Active { get; set; }  // The state of the projectile
        public int Damage { get; set; }  // The amount of damage the projectile can inflict on the enemy
        public float Speed { get; set; }  // The projectile speed

        private Viewport viewport; // Represents the viewable boundary of the game
        private SpriteBatch spriteBatch;

        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }


        public Projectile(Game game, Vector2 position) : base(game)
        {
            this.position = position;
            viewport = game.GraphicsDevice.Viewport;
            Damage = PROJECTILE_DAMAGE;
            Speed = PROJECTILE_SPEED;
            Active = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch));
            // Load projectiles resources
            Texture = Game.Content.Load<Texture2D>("laser");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // Projectiles always move to the right
            position.X += Speed;
            // Deactivate the bullet if it goes out of the screen
            if (Position.X + Width / 2 > viewport.Width)
            {
                Active = false;
                Game.Components.Remove(this);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
                    new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
            base.Draw(gameTime);
        }

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                  (int)Position.X - Width / 2,
                  (int)Position.Y - Height / 2,
                  Width, Height);
            }
        }
    }
}