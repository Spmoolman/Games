using Assets.Weapon;
using Assets.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour, IShip, IHorizontalMovement
{
    private IWeapon weapon;

    public int Health
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
            throw new System.NotImplementedException();
        }
    }

    public void MoveHorizontal()
    {
        transform.Translate(Input.GetAxis("Horizontal")*0.2f,0f,0f);
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
}
