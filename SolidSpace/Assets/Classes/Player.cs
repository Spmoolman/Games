using Assets.Weapon;
using Assets.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour, IShip, IHorizontalMovement
{
    private IWeapon weapon;

    public int Health { get; set; } = 3;

    public void MoveHorizontal()
    {
        transform.Translate(Input.GetAxis("Horizontal")*0.2f,0f,0f);
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -6, 6));
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
    
    // Use this for initialization
    void Start () {
        weapon = new Laser();
    }
	
	// Update is called once per frame
	void Update () {
        MoveHorizontal();
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

