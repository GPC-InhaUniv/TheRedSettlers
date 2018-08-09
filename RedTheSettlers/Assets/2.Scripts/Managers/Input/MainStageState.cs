﻿using RedTheSettlers.GameSystem;
using UnityEngine;

/// <summary>
/// 담당자 박상원
/// State 패턴 구현부
/// Board Game 부분 버튼 기능 및 카메라 이동
/// </summary>
public class MainStageState : InputState
{
    private Vector3 firstClick;
    private Vector3 dragPosition;
    private Vector3 dragDirection;
    private float cameraZoom;
    private const int reversValue = -1;

    public override void TouchOrClickButton(InputButtonType inputButtonType)
    {
        switch (inputButtonType)
        {
            case InputButtonType.Battle:
                break;
            case InputButtonType.Trade:
                break;
            case InputButtonType.TurnEnd:
                break;
            case InputButtonType.Status:
                break;
            case InputButtonType.Map:
                break;
            case InputButtonType.EquipAndSkill:
                break;
        }
    }

    public override void DragMove(float speed)
    {
        //TemporaryGameManager.Instance.CameraMove();
        //LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "넘어왔나");

        if (Input.GetMouseButtonDown(0))
        {
            /*Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                firstClick = new Vector3(rayPoint.origin.x, rayPoint.origin.y ,rayPoint.origin.z);
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "클릭 위치 : " + firstClick);
            }*/
            firstClick = Input.mousePosition;
            LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "시작 좌표 : " + firstClick);
        }
        else if (Input.GetMouseButton(0))
        {
            /*Ray rayPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkCollision;

            if (Physics.Raycast(rayPoint, out checkCollision, Mathf.Infinity))
            {
                dragPosition = new Vector3(rayPoint.origin.x, rayPoint.origin.y, rayPoint.origin.z);
                dragDirection = (dragPosition - firstClick).normalized * Speed * Time.deltaTime;
                //GameManager.Instance.CameraMove(dragDirection);
                //TemporaryGameManager.Instance.CameraMove(dragDirection);
                LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "좌표 : " + dragPosition);
            }*/
            dragPosition = Input.mousePosition;
            dragDirection = (((dragPosition - firstClick).normalized * speed) * reversValue) * Time.deltaTime;
            TemporaryGameManager.Instance.CameraMove(dragDirection);
            LogManager.Instance.UserDebug(LogColor.Blue, GetType().Name, "좌표 : " + dragPosition);
        }
        else if (!Input.GetMouseButton(0))
        {
            dragPosition = Vector3.zero;
            firstClick = Vector3.zero;
            dragDirection = (dragPosition - firstClick).normalized;
        }
    }
    public override void ZoomOrOut(float speed)
    {
        cameraZoom = (Input.GetAxis("Mouse ScrollWheel") * speed) * reversValue;
        TemporaryGameManager.Instance.CameraZoom(cameraZoom);
    }
}
