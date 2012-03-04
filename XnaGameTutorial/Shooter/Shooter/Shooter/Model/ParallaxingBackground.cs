using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Model
{
    public class ParallaxingBackground
    {
        private Texture2D texture;  // The image representing the parallaxing background
        private Vector2[] positions;  // An array of positions of the parallaxing background
        private int speed;  // The speed at which the background is moving

        public void Initialize(ContentManager content,
            String texturePath, int screenWidth, int speed)
        {
            texture = content.Load<Texture2D>(texturePath);
            this.speed = speed;

            // If we divide the screen with the texture width,
            // then we can determine the number of tiles needed.
            // We add 1 to it so that we won't have a gap in the tiling
            positions = new Vector2[screenWidth/texture.Width +1];
            // Set the initial positions of the parallaxing background
            for (int i = 0; i < positions.Length; i++)
            {
                // We need the tiles to be side by side to create a tiling effect                
                positions[i] = new Vector2(i*texture.Width, 0); 
            }
        }

        public void Update()
        {
            // Update the positions of the background
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i].X += speed;
                // If the speed has the background moving to the left
                if (speed <= 0)
                {
                    // Check the texture is out of view then put that texture at the end of the screen
                    if (positions[i].X <= -texture.Width)
                        positions[i].X = texture.Width*(positions.Length - 1);
                }
                // If the speed has the background moving to the right
                else
                {
                    // Check if the texture is out of view then position it to the
                    // start of the screen
                    if (positions[i].X >= texture.Width * (positions.Length - 1))
                        positions[i].X = -texture.Width;
                }
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (var position in positions)
                sp.Draw(texture, position, Color.White);
        }
    }
}