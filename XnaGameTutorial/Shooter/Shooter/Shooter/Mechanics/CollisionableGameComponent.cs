using Microsoft.Xna.Framework;

namespace Shooter.Mechanics
{
    public abstract class CollisionableGameComponent : DrawableGameComponent, ICollisionable
    {
        protected CollisionableGameComponent(Game game) : base(game) {}

        public bool CollidedWith(ICollisionable component)
        {
            return BoundingBox.Intersects(component.BoundingBox);
        }

        public abstract Rectangle BoundingBox { get; }
    }
}