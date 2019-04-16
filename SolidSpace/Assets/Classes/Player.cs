using System;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IShip, IHorizontalMovement
{
    private float nextFire;
    private int weaponCycler = 0;

    public GameObject[] shot;
    public Transform shotSpawn;
    public float fireRate;
    public Slider healthSlider;

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
            Instantiate(shot[weaponCycler], shotSpawn.position, shotSpawn.rotation);
        }
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        MoveHorizontal();
        Shoot();
        SwitchWeapons();
    }

    private void SwitchWeapons()
    {
        if (Input.GetButton("Fire2"))
        {
            if (shot.Length == weaponCycler+1)
                weaponCycler = 0;
            else
                weaponCycler++;
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name.Contains("Heart") )
        {
            if(Health < 10)
                Health++;
        }
        else
        {
            TakeDamage();
        }
        
        Destroy(trigger.gameObject);
        healthSlider.value = Health;
    }

    public void TakeDamage()
    {
        Health--;
        print(Health);

        if (Health == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

}

