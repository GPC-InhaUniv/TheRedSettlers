﻿using RedTheSettlers.GameSystem;
using RedTheSettlers.Users;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct UIPlayerSprite
{
    public string SpriteName;
    public Sprite UISprite;
}

namespace RedTheSettlers.UI
{
    public class UIAITurn : MonoBehaviour
    {
        [SerializeField]
        private Image aiPlayerImage;
        [SerializeField]
        private Image turnCircleImage;
        [SerializeField]
        private Text aiPlayerNameText;
        [SerializeField]
        private Text aiTurnContentText;
        [SerializeField]
        private UIPlayerSprite[] spriteArray;

        public Queue<string> ContentStringQueue;
        private WaitForSeconds waitForSeconds;
        private int aiTurnCount = 1;

        IEnumerator ChangeSliderFillAmount()
        {

            ChangeAiPlayerNameText(aiTurnCount);
            turnCircleImage.fillAmount = 0;
            while (turnCircleImage.fillAmount < 1)
            {
                //turnCircleImage.fillAmount += 0.002f; 기존
                if (turnCircleImage.fillAmount == 0)
                    ChangeAiPlayerImage(aiTurnCount, 0);
                else if (turnCircleImage.fillAmount > 0.2f && turnCircleImage.fillAmount < 0.8f)
                    ChangeAiPlayerImage(aiTurnCount, 1);
                else if (turnCircleImage.fillAmount > 0.8f)
                    ChangeAiPlayerImage(aiTurnCount, 2);

                turnCircleImage.fillAmount += 0.002f;
                yield return null;
            }
            aiTurnCount++;
            Debug.Log("Exit");
            if (aiTurnCount < GlobalVariables.MaxPlayerNumber)
                StartCoroutine(ChangeSliderFillAmount());
        }

        IEnumerator ChangeAiTurnContentText()
        {


            yield return null;
        }

        private void Start()
        {
            StartCoroutine(ChangeSliderFillAmount());
        }

        private void ChangeAiPlayerNameText(int turnCount)
        {
            switch (turnCount)
            {
                case 1:
                    aiPlayerNameText.text = "First AI";
                    aiPlayerNameText.color = new Color32(219, 31, 31, 255);
                    break;
                case 2:
                    aiPlayerNameText.text = "Second AI";
                    aiPlayerNameText.color = new Color32(31, 79, 219, 255);
                    break;
                case 3:
                    aiPlayerNameText.text = "Third AI";
                    aiPlayerNameText.color = new Color32(79, 146, 25, 255);
                    break;
            }
        }

        private void ChangeAiPlayerImage(int turnCount, int imageCount)
        {
            int index;
            switch (turnCount)
            {
                case 1:
                    index = imageCount;
                    aiPlayerImage.sprite = spriteArray[index].UISprite;
                    break;
                case 2:
                    index = imageCount + 3;
                    aiPlayerImage.sprite = spriteArray[index].UISprite;
                    break;
                case 3:
                    index = imageCount + 6;
                    aiPlayerImage.sprite = spriteArray[index].UISprite;
                    break;
            }
        }

    }
}
