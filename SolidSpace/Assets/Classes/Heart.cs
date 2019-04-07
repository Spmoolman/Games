using Assets.Interfaces;
using UnityEngine;

public class Heart : MonoBehaviour, IVerticalMovement, IDestroyable
{
    private float _dropoffPosition = -5f;

    public void DestroyGameObject()
    {
        if (transform.position.y < _dropoffPosition)
        {
            Destroy(gameObject);
        }
    }

    public void MoveVertical()
    {
        transform.Translate(0, -0.02f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();
        DestroyGameObject();
    }
}
