namespace Interfaces
{
    public interface IShip
    {
        int Health { get; set; }

        void Shoot();
        void TakeDamage();
    }
}
