using Assets.Interfaces;
using UnityEngine;

public class EnemyRight : MonoBehaviour, IShip, IHorizontalMovement, IVerticalMovement, IDestroyable
{
    private float _dropoffPosition = -9f;

    public int Health { get; set; } = 1;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    public void MoveHorizontal()
    {
        transform.Translate(0.02f, 0f, 0f);
    }

    public void MoveVertical()
    {
        transform.Translate(0, 0.02f, 0f);
    }

    public void Shoot()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
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

}
