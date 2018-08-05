﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy enemy;

    public abstract void DoAction(Enemy enemy);
}