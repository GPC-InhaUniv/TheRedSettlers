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
<<<<<<< HEAD
        public override State Camera(StageType stageType)
        {
            throw new System.NotImplementedException();
        }

        public override State Execute(StageType stageType)
=======
        public override State ChangeStage(StageType stageType)
>>>>>>> 676814679227a1f9f2a56ca77747758cbbb6fc46
        {
            SceneManager.LoadSceneAsync((int)StageType.LoadingStageState);
            return new LoadingState();
        }

        

        //public IEnumerator ChangeStage()
        //{
        //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);

        //    asyncOperation.allowSceneActivation = false;

        //    yield return asyncOperation;

        //    asyncOperation.allowSceneActivation = true;
        //}

       
    }

}

