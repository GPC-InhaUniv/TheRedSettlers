﻿using UnityEngine;

namespace RedTheSettlers
{
    namespace System
    {

        public class Idle : EnemyState
        {
            public override void DoAction(Enemy enemy)
            {
                enemy.anim.SetFloat("Speed", Vector3.Distance(enemy.destinationPoint, enemy.currentPoint));
            }
        }
    }
}