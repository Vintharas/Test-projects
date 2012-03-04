using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Mechanics;

namespace Shooter.Model
{
    public class Player
    {
        public Vector2 Position;
        public bool Active;
        public int Health;
        public Animation PlayerAnimation { get; set; }
        public int Width { get { return PlayerAnimation.FrameWidth; } }
        public int Height { get { return PlayerAnimation.FrameHeight; } }

        public void Initialize(Animation animation, Vector2 position)
        {
            this.PlayerAnimation = animation;
            this.Position = position;
            Active = true;
            Health = 100;
        }

        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch sp)
        {
            PlayerAnimation.Draw(sp);
        }
    }
}