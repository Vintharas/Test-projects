using Microsoft.Xna.Framework;

namespace GameEngine.Core
{
    public class GameObjectBase
    {
        public GameHost Game { get; set; }
        public int UpdateCount { get; set; }

        public GameObjectBase(GameHost game)
        {
            this.Game = game;
        }

        public virtual void Update(GameTime gametime)
        {
            // Increment update count
            UpdateCount += 1;
        }

         
    }

    public class GameHost
    {
        
    }
}