﻿using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public class Move : EnemyState
    {
        const float speedCorrection = 50f;

        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetFloat("Speed", Vector3.Distance(enemy.destinationPoint, enemy.currentPoint));

            Vector3 normalVector = (enemy.destinationPoint - enemy.currentPoint).normalized;
            enemy.transform.rotation = Quaternion.LookRotation(normalVector);
            enemy.rigidbodyComponent.velocity = normalVector * GameTimeManager.Instance.DeltaTime * enemy.MoveSpeed * speedCorrection;
        }
    }
}