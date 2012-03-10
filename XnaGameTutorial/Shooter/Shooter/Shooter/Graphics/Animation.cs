using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Graphics
{
    public class Animation
    {
        private Texture2D spriteStrip;  // Image representing the collection of images used for animation
        private float scale;  // The scale used to display the sprite strip
        
        private int elapsedTime; // The time since we last updated the frame
        private int frameTime; // The time we display a frame until the next one
        private int frameCount; // The number of frames that the animation contains
        private int currentFrame; // The index of the current frame we are displaying

        private Color color; // The color of the frame we will be displaying
        private Rectangle sourceRect = new Rectangle(); // The area of the image strip we want to display
        private Rectangle destinationRect = new Rectangle(); // The area where we want to display the image strip in the game

        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public bool Active { get; set; }
        public bool Looping { get; set; }
        public Vector2 Position { get; set; }

        public void Initialize(Texture2D texture, Vector2 position,
            int frameWidth, int frameHeight, int frameCount,
            int frameTime, Color color, float scale, bool looping)
        {
            spriteStrip = texture;
            Position = position;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            Looping = looping;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.color = color;
            this.scale = scale;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (Active)
                UpdateAnimation(gameTime);
            
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            elapsedTime += (int) gameTime.ElapsedGameTime.TotalMilliseconds;
            // When the elapsed time is larger than the frame time
            // we need to switch frames
            if (elapsedTime > frameTime)
            {
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (!Looping)
                        Active = false;
                }
                elapsedTime = 0;
            }
            // Take the correct frame in the image strip
            sourceRect = new Rectangle(currentFrame*FrameWidth, 0, FrameWidth, FrameHeight);
            destinationRect = new Rectangle(
                (int) Position.X - (int) (FrameWidth*scale)/2,
                (int) Position.Y - (int) (FrameHeight*scale)/2,
                (int) (FrameWidth*scale), (int) (FrameHeight*scale));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }
        }

    }
}