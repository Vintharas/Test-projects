using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Model
{
    public class Projectile
    {
        public Texture2D Texture { get; set; }  // Image representing the projectile
        public Vector2 Position { get { return position; } set { position = value; } }  // Position of the projectile
        private Vector2 position;
        public bool Active { get; set; }  // The state of the projectile
        public int Damage { get; set; }  // The amount of damage the projectile can inflict on the enemy
        public float Speed { get; set; }  // The projectile speed

        private Viewport viewport; // Represents the viewable boundary of the game

        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }

        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;
            Active = true;
            Damage = 2;
            Speed = 20f;
        }

        public void Update()
        {
            // Projectiles always move to the right
            position.X += Speed;
            // Deactivate the bullet if it goes out of the screen
            if (Position.X + Width / 2 > viewport.Width)
                Active = false;
        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(Texture, Position, null, Color.White, 0f,
                new Vector2(Width/2, Height/2), 1f, SpriteEffects.None, 0f );
        }
    }
}