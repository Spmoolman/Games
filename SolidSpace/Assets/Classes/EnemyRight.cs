using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : MonoBehaviour, IShip, IHorizontalMovement, IVerticalMovement, IDestroyable
{
    private float _dropoffPosition = 9f;
    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DestroyGameObject()
    {
        if (transform.position.x > _dropoffPosition)
        {
            Destroy(gameObject);
        }
    }

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
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
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
    }
}
