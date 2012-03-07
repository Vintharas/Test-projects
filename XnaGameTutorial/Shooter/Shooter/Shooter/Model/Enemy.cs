using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Mechanics;

namespace Shooter.Model
{
    public class Enemy
    {
        public Animation Animation { get; set; }  // Animation representing the enemy
        public Vector2 Position { get { return position; } set { position = value; } }  // The position of the enemy
        private Vector2 position;
        public bool Active { get; set; }  // The state of the enemy
        public int  Health { get; set; }  // The hit points of the enemy
        public int Damage { get; set; }  // The amount of damage the enemy inflicts on the player ship
        public int Value { get; set; }  // The amount of score the enemy will give to the player
        public float Speed { get; set; }  // The speed of the enemy

        public int Width { get { return Animation.FrameWidth; } }  // Width of the enemy
        public int Height { get { return Animation.FrameHeight; } }  // Height of the enemy

        public void Initialize(Animation animation, Vector2 position)
        {
            Animation = animation;
            Position = position;
            Active = true;
            Health = 10;
            Speed = 6f;
            Value = 100;
        }

        public void Update(GameTime gameTime)
        {
             // The enemy always moves to the left (so we decrement the x position)
            position.X -= Speed;
            // Update animation
            Animation.Position = Position;
            Animation.Update(gameTime);
            // If the enemy is past the screen or its health reaches 0 then deactivate it
            if (Position.X < -Width || Health <= 0)
                Active = false;
        }

        public void Draw(SpriteBatch sp)
        {
            Animation.Draw(sp);
        }
    }
}