using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Graphics;
using Shooter.Mechanics;

namespace Shooter.Model
{
    public class Enemy : CollisionableGameComponent
    {

        private Animation animation;  // Animation representing the enemy
        private SpriteBatch sp;

        public Vector2 Position { get { return position; } set { position = value; } }  // The position of the enemy
        private Vector2 position;
        public bool Active { get; set; }  // The state of the enemy
        public int  Health { get; set; }  // The hit points of the enemy
        public int Damage { get; set; }  // The amount of damage the enemy inflicts on the player ship
        public int Value { get; set; }  // The amount of score the enemy will give to the player
        public float Speed { get; set; }  // The speed of the enemy

        public int Width { get { return animation.FrameWidth; } }  // Width of the enemy
        public int Height { get { return animation.FrameHeight; } }  // Height of the enemy

        public Enemy(Game game, Vector2 position)
            : base(game)
        {
            this.position = position;
            Active = true;
            Health = 10;
            Speed = 6f;
            Value = 100;
            Damage = 10;
        }

        protected override void LoadContent()
        {
            sp = (SpriteBatch) Game.Services.GetService(typeof (SpriteBatch));
            // Load enemy resources
            Texture2D texture = Game.Content.Load<Texture2D>("mineAnimation");
            animation = new Animation();
            animation.Initialize(texture, Vector2.Zero, 47, 61, 8, 30, Color.White, 1f, true);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
             // The enemy always moves to the left (so we decrement the x position)
            position.X -= Speed;
            // Update animation
            animation.Position = Position;
            animation.Update(gameTime);
            // If the enemy is past the screen or its health reaches 0 then deactivate it
            if (Position.X < -Width || Health <= 0)
                Active = false;
        }

        public override void Draw(GameTime gameTime)
        {
            animation.Draw(sp);
        }

        public override Rectangle BoundingBox
        {
            get { return new Rectangle((int) Position.X, (int) Position.Y, Width, Height); }
        }

    }
}