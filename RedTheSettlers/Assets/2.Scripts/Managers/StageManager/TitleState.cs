﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 담당자 : 이재환
/// 수정시 간략 설명과 수정 날짜 
/// {
///   Ex : 함수명 변경 18/07/15
///     
/// }
/// </summary>

namespace RedTheSettlers.GameSystem
{
    class TitleState : State
    {
        
        public override void ContinueGame(bool canLoadData)
        {
            if (canLoadData)
            {
                StageManager.Instance.JudgeLoadingData(canLoadData);
            }
        }

        public override void Enter()
        {
           
        }
        
        public override void Exit(StageType stageType)
        {
            StageManager.Instance.ChangeStage(StageType.LoadingStageState);
        }

    }

}

