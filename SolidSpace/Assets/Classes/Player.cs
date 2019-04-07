using Assets.Weapon;
using Assets.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour, IShip, IHorizontalMovement
{
    private IWeapon weapon;
    private float nextFire;

    public GameObject[] shot;
    public Transform shotSpawn;
    public float fireRate;

    public int Health { get; set; } = 3;

    public void MoveHorizontal()
    {
        transform.Translate(Input.GetAxis("Horizontal")*0.2f,0f,0f);
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -6, 6));
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot[1], shotSpawn.position, shotSpawn.rotation);
        }
    }

    // Use this for initialization
    void Start () {
        //check if can get prefab
        //weapon = Resources.Load("");
    }
	
	// Update is called once per frame
	void Update () {
        MoveHorizontal();
        Shoot();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name.Contains("Heart"))
            Health++;
        else
            Health--;

        print(Health);
        Destroy(trigger.gameObject);
    }

}

