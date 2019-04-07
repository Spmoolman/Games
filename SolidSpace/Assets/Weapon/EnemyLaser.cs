using Assets.Interfaces;
using UnityEngine;

public class EnemyLaser : MonoBehaviour, IVerticalMovement, IDestroyable
{
    private float _dropoffPosition = 5f;
    public float speed = -0.02f;

    public void DestroyGameObject()
    {
        if (gameObject.name.Contains("Left"))
        {
            if (transform.position.y > _dropoffPosition)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.y < -_dropoffPosition)
            {
                Destroy(gameObject);
            }
        }
    }

    public void MoveVertical()
    {
        transform.Translate(0, speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();
        DestroyGameObject();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        Destroy(gameObject);
        Destroy(trigger.gameObject);
    }
}
