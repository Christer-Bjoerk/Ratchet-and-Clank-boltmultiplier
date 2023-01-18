using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchVCAM : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 10;
    
    [SerializeField] private Canvas thirdPersonCanvas;
    [SerializeField] private Canvas aimPersonCanvas;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }
    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
        aimPersonCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        aimPersonCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }
}
