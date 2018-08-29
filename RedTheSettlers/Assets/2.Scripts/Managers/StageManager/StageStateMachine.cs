﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 이재환
/// 수정시 간략 설명과 수정 날짜 
/// {
///   Ex : 함수명 변경 18/07/15
///   Context 부분 
///   
/// }
/// </summary>


namespace RedTheSettlers.GameSystem
{
    public class StageStateMachine
    {
        private State currentState;
        public State CurrentState { get { return currentState; } }

        public StageStateMachine()
        {
            currentState = new TitleState();
            Debug.Log("현재 상태" + currentState);
        }

        public void ContinueGame(bool canLoadData)
        {
            if (currentState != null)
            {
                currentState.ContinueGame(canLoadData);
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "와이 널" + currentState.GetType());
            }
            else
                LogManager.Instance.UserDebug(LogColor.Navy, "StageStateMachine", "현재 상태가 없습니다.");
        }

        public void Enter(StageType stageType)
        {
            if (currentState != null) currentState.Enter(stageType);
            else
                LogManager.Instance.UserDebug(LogColor.Navy, "StageStateMachine", "현재 상태가 없습니다.");
        }

        public void Exit(StageType stageType)
        {
            if (currentState != null) currentState.Exit(stageType);
            else
                LogManager.Instance.UserDebug(LogColor.Navy, "StageStateMachine", "현재 상태가 없습니다.");
        }
    }
}