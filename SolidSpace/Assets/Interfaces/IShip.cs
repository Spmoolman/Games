using System;

namespace Assets.Interfaces
{
    public interface IShip
    {
        int Health { get; set; }

        void Shoot();

        void TakeDamage();
    }
}
