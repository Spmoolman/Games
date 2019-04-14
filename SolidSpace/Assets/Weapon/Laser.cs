﻿using Assets.Interfaces;
using UnityEngine;

namespace Assets.Weapon
{
    class Laser : MonoBehaviour, IVerticalMovement, IDestroyable
    {
        private float _dropoffPosition = 5f;
        public float speed = 0.02f;

        public void DestroyGameObject()
        {
            if (transform.position.y > _dropoffPosition)
            {
                Destroy(gameObject);
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
    }
}
