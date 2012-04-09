using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Model
{
    public class GameText : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont scoreFont;
        private Vector2 position;
        public string Text { get; set; }


        public GameText(Game game, string text, Vector2 position) : base(game)
        {
            Text = text;
            this.position = position;
        }

        protected override void LoadContent()
        {
            spriteBatch = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch));
            scoreFont = Game.Content.Load<SpriteFont>("gameFont");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.DrawString(scoreFont, Text, position, Color.White);
            base.Draw(gameTime);
        }
    }
}