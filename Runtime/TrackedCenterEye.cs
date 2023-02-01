using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrackedCenterEye : MonoBehaviour
{

    InputAction leftEyePoistionAction, rightEyePositionAction, leftEyeRotationAction;
    Vector3 leftEyePoistion, rightEyePosition;
    Quaternion leftEyeRotation;

    //private void OnEnable()
    //{
    //    BindActions();
    //}

    //private void OnDisable()
    //{
    //    UnbindActions();
    //}

    // Start is called before the first frame update
    void Start()
    {
        BindActions();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = (leftEyePoistion + rightEyePosition) / 2;
        transform.localRotation = leftEyeRotation;
    }

    private void OnDestroy()
    {
        UnbindActions();
    }

    void BindActions()
    {
        leftEyePoistionAction = new InputAction();
        leftEyePoistionAction.AddBinding("<XRHMD>/leftEyePosition");
        leftEyePoistionAction.performed += OnLeftPositionPerformed;
        leftEyePoistionAction.Enable();

        rightEyePositionAction = new InputAction();
        rightEyePositionAction.AddBinding("<XRHMD>/rightEyePosition");
        rightEyePositionAction.performed += OnRightPositionPerformed;
        rightEyePositionAction.Enable();

        leftEyeRotationAction = new InputAction();
        leftEyeRotationAction.AddBinding("<XRHMD>/leftEyeRotation");
        leftEyeRotationAction.performed += OnLeftRotationPerformed;
        leftEyeRotationAction.Enable();
    }
    
    void UnbindActions()
    {
        leftEyePoistionAction.performed -= OnLeftPositionPerformed;
        leftEyePoistionAction.Disable();

        rightEyePositionAction.performed -= OnRightPositionPerformed;
        rightEyePositionAction.Disable();

        leftEyeRotationAction.performed -= OnLeftRotationPerformed;
        leftEyeRotationAction.Disable();
    }


    void OnLeftPositionPerformed(InputAction.CallbackContext context)
    {
        leftEyePoistion = context.ReadValue<Vector3>();
    }

    void OnRightPositionPerformed(InputAction.CallbackContext context)
    {
        rightEyePosition = context.ReadValue<Vector3>();
    }

    void OnLeftRotationPerformed(InputAction.CallbackContext context)
    {
        leftEyeRotation = context.ReadValue<Quaternion>();
    }


}
