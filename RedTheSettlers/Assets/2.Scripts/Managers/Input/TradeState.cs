﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeState : InputState
{
    public override void UIMover(Vector3 position)
    {
        TemporaryGameManager.Instance.UserTrade(position);
    }
}
