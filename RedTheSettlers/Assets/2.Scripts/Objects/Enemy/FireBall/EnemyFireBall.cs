﻿using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class EnemyFireBall : MonoBehaviour
    {
        public Rigidbody rigidbodyComponent;

        private void Awake()
        {
            rigidbodyComponent = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            rigidbodyComponent.velocity = Vector3.zero;
        }
    }
}