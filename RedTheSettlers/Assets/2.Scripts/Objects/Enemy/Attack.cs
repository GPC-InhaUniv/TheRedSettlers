﻿namespace RedTheSettlers.Enemys
{
    public class Attack : EnemyState
    {
        public override void DoAction(Enemy enemy)
        {
            enemy.anim.SetTrigger("Attack");
        }
    }
}