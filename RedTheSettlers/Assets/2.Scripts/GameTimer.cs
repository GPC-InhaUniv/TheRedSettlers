﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타이머의 기반 클래스
/// </summary>
public class GameTimer
{
    //울릴 시간
    float snoozeTime;
    //울리기 까지의 시간 카운트
    float sumTime;

    bool isCounting = false;
    bool isRepeat = false;

    /// <summary>
    /// 타이머에 시간을 지정합니다. time : 시간, repeat : 반복 호출 여부
    /// </summary>
    public void SetTimer(float time, bool repeat)
    {
        snoozeTime = time;
        isRepeat = repeat;
    }

    /// <summary>
    /// 타이머를 처음부터 작동시킵니다.
    /// </summary>
    public void StartTimer()
    {
        isCounting = true;
        sumTime = 0f;
    }

    /// <summary>
    /// 타이머를 일시정시 시킵니다. 다시 호출하면 재개됩니다.
    /// </summary>
    public void SleepTimer()
    {
        isCounting = !isCounting;
    }

    /// <summary>
    /// 타이머를 정지시킵니다. 다시 재개할 수 없습니다.
    /// </summary>
    public void StopTimer()
    {
        isCounting = false;
        sumTime = 0f;
    }

    private void Update()
    {
        if (isCounting)
        {
            if (sumTime < snoozeTime)
            {
                sumTime += GameTimeManager.DeltaTime;
            }
            else
            {
                //알람이 울렸다.

                if (isRepeat)
                {
                    StartTimer();
                }
                else
                {
                    StopTimer();
                }
            }
        }
    }

}
