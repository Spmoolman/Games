using Assets.Interfaces;
using UnityEngine;

public class Enemy : MonoBehaviour, IShip, IHorizontalMovement, IVerticalMovement, IDestroyable
{
    private float _dropoffPosition = -9f;
    private float nextFire;

    public int Health { get; set; } = 1;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public bool fromLeft;

    public void MoveHorizontal()
    {
        if(fromLeft)
            transform.Translate(-0.02f, 0f, 0f);
        else
            transform.Translate(0.02f, 0f, 0f);
    }

    public void MoveVertical()
    {
        transform.Translate(0, 0.02f, 0f);
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        DestroyGameObject();
        Shoot();
    }

    public void DestroyGameObject()
    {
        if (transform.position.x < _dropoffPosition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        Health--;
        if (Health == 0)
            Destroy(gameObject);
    }
}
