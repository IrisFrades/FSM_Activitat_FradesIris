using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorController : MonoBehaviour
{
    public enum DoorState { CLOSED, OPENING, OPENED, CLOSING}


    [SerializeField] DoorState doorState = DoorState.CLOSED;

    public GameObject leftDoor;
    public GameObject rightDoor;

    [SerializeField] float timeToGetReady = 1.0f;
    float timeInCurrentState = 0;
    public float openingDistance = 3f;

    Transform pos;

    Vector3 posIniRightDoor;
    Vector3 posFinRightDoor;
    Vector3 posIniLeftDoor;
    Vector3 posFinLeftDoor;
    private void Start()
    {
        posIniRightDoor = rightDoor.transform.position;
        posFinRightDoor = rightDoor.transform.position + new Vector3(2, 0, 0);

        posIniLeftDoor = leftDoor.transform.position;
        posFinLeftDoor = leftDoor.transform.position + new Vector3(-2, 0, 0);
    }

    private void Update()
    {
        timeInCurrentState += Time.deltaTime;
        UpdateCurrentState();
    }

    public void OnButtonClicked()
    {
        switch (doorState)
        {
            case DoorState.CLOSED:
                ChangeState(DoorState.OPENING);
                break;
            case DoorState.OPENING:
                break;
            case DoorState.OPENED:
                ChangeState(DoorState.CLOSING);
                break;
            case DoorState.CLOSING:
                break;
        }
    }

    void UpdateCurrentState()
    {
      

        switch (doorState)
        {
            case DoorState.CLOSED:
                break;

            case DoorState.OPENING:
                
                if (timeInCurrentState < timeToGetReady)
                {
                    
                    float progress = timeInCurrentState / timeToGetReady;
                    rightDoor.transform.position = Vector3.Lerp(posIniRightDoor, posFinRightDoor, progress);

                    leftDoor.transform.position = Vector3.Lerp(posIniLeftDoor, posFinLeftDoor, progress);

                }
                else
                {
                    ChangeState(DoorState.OPENED);
                }
                break;

            case DoorState.OPENED:
                break;

            case DoorState.CLOSING:
                
                if (timeInCurrentState < timeToGetReady)
                {
                    float progress = timeInCurrentState / timeToGetReady;
                    rightDoor.transform.position = Vector3.Lerp(posFinRightDoor, posIniRightDoor, progress);

                    leftDoor.transform.position = Vector3.Lerp(posFinLeftDoor,  posIniLeftDoor, progress);
                }
                else
                {
                    ChangeState(DoorState.CLOSED);
                }
                break;
        }
    }

    void ChangeState(DoorState newState)
    {
        ExitState();
        EnterState(newState);
        doorState = newState;
        timeInCurrentState = 0;
    }

    private void EnterState(DoorState newState)
    {
        switch (doorState)
        {
            case DoorState.CLOSED:
                doorState = DoorState.OPENING;
                break;
            case DoorState.OPENING:
                break;
            case DoorState.OPENED:
                doorState = DoorState.CLOSING;
                break;
            case DoorState.CLOSING:
                break;
        }
    }

    private void ExitState()
    {
        switch (doorState)
        {
            case DoorState.CLOSED:
                break;
            case DoorState.OPENING:
                break;
            case DoorState.OPENED:
                break;
            case DoorState.CLOSING:
                break;
        }
    }




}
