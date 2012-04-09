using Microsoft.Xna.Framework;

namespace Shooter.Mechanics
{
    /// <summary>
    /// Interface that encapsulates the collision behavior of a game component
    /// </summary>
    public interface ICollisionable
    {
        bool CollidedWith(ICollisionable component);
        Rectangle BoundingBox { get; }
    }
}