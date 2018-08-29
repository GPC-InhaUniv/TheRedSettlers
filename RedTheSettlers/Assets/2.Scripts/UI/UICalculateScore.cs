﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RedTheSettlers.GameSystem;



namespace RedTheSettlers.UI
{
    /// <summary>
    /// 작성자 : 김하정
    /// 마지막에 점수 계산을 해주는 UI
    /// 나중에 델리게이트로 받을예정
    /// </summary>
    public class UICalculateScore : MonoBehaviour
    {
        private GameData gameData;
       
        [SerializeField]
        private int playerIndex;
        private float scoreDelayTime = 0.05f;
        private int totalScore = 0;
        private int riseValue = 10000;

        [System.Serializable]
        struct Texts
        {
            public Text[] CardTexts;
            public Text AttackText;
            public Text ShieldText;
            public Text TentText;
            public Text monsterKillText;
            public Text TotalText;
        }

        [SerializeField]
        private Texts infoTexts;

        [SerializeField]
        private Text cardWeight, equipmentWeight, bonusWeight;

        private void Start()
        {
            TotalScore();
            ShowWeightValue();
            StartCoroutine(ShowCardScore());
        }

        IEnumerator ShowCardScore()
        {
            GameManager data = GameManager.Instance;

            for (int i = 0; i < infoTexts.CardTexts.Length; i++)
            {
                for (int j = 0; j <= data.GetPlayerItemCount((UserType)playerIndex,(ItemType)i); j++)
                {
                    infoTexts.CardTexts[i].text = j.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            int scoreCount = 0;
            for (int i = 0; i < GlobalVariables.MaxEquipmentUpgradeLevel; i++)
            {
              /*  if (scoreCount <= playerData.StatData.WeaponLevel)*/  //공격 레벨
                {
                    scoreCount++;
                    infoTexts.AttackText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }

               /* if (scoreCount <= playerData.StatData.ShieldLevel)  *///방어 레벨
                {
                    scoreCount++;
                    infoTexts.ShieldText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            scoreCount = 0;
            for (int i = 0; i <= GlobalVariables.MaxTileCount; i++)
            {
                if (scoreCount <= data.GetPlayerTileCountAll((UserType)playerIndex))
                {
                    scoreCount++;
                    infoTexts.TentText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }

                /*if (scoreCount <= playerData.BossKillCount)*/ //보스 죽인 수
                {
                    scoreCount++;
                    infoTexts.monsterKillText.text = scoreCount.ToString("D2");
                    yield return new WaitForSeconds(scoreDelayTime);
                }
            }

            for (int i = 0; i <= totalScore; i += riseValue)
            {
                infoTexts.TotalText.text = i.ToString();
                yield return new WaitForSeconds(scoreDelayTime);
            }
            yield break;
        }

        private void TotalScore()
        {
            totalScore = GameManager.Instance.GetPlayerItemCountAll((UserType)playerIndex)
            * (GlobalVariables.CardWeightValue + GlobalVariables.EquipmentWeightValue + GlobalVariables.BonusWeightValue);
        }

        private void ShowWeightValue()
        {
            cardWeight.text = "X" + GlobalVariables.CardWeightValue.ToString();
            equipmentWeight.text = "X" + GlobalVariables.EquipmentWeightValue.ToString();
            bonusWeight.text = "X" + GlobalVariables.BonusWeightValue.ToString();
        }
    }
}