
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine.Events;
using UnityEngine.XR;

public abstract class HandInput : MonoBehaviour
{
    public UnityEvent onTriggerDown;
    public UnityEvent onTriggerUp;
    private bool _lastTriggerValue = false;
    
    public UnityEvent onGripDown;
    public UnityEvent onGripUp;
    private bool _lastGripValue = false;

    public UnityEvent<Vector2> onJoystickUpdate;
    private Vector2 _lastJoystickValue;

    public UnityEvent<Vector3> controllerVelocityTracker;

    private InputDevice _controller;
    private bool _controllerIntialized = false;

    private InputDeviceCharacteristics _desiredCharacteristics;
    private bool _initialized = false;
    
    protected void Initialize(InputDeviceCharacteristics inputCharacteristics)
    {
        _desiredCharacteristics = inputCharacteristics;
        _initialized = true;
    }

    private bool AttachController()
    {
        var controllers = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(_desiredCharacteristics, controllers);

        if (controllers.Count == 1)
        {
            _controller = controllers[0];
            return _controllerIntialized = true;
        }
        
        if (controllers.Count > 1)
        {
            Debug.Log("Multiple controllers found with the desired characteristics.");
        }
        
        return false;
    }

    void Update()
    {
        if (!_initialized || (!_controllerIntialized && !AttachController()))
        {
            return;
        }
        
        bool triggerValue;
        
        //Try to get button press
        if (_controller.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue))
        {
            //See if button has changed
            if (triggerValue != _lastTriggerValue)
            {
                //If down/up
                if (triggerValue && onTriggerDown != null)
                {
                    onTriggerDown.Invoke();
                }
                else if (onTriggerUp != null)
                {
                    onTriggerUp.Invoke();
                }

                _lastTriggerValue = triggerValue;
            }
        }
        
        bool gripValue;
        
        //Try to get button press
        if (_controller.TryGetFeatureValue(CommonUsages.gripButton, out gripValue))
        {
            //See if button has changed
            if (gripValue != _lastGripValue)
            {
                //If down/up
                if (gripValue && onGripDown != null)
                {
                    onGripDown.Invoke();
                }
                else if (onGripUp != null)
                {
                    onGripUp.Invoke();
                }

                _lastGripValue = gripValue;
            }
        }
        
        Vector2 joystickValue;
        if (_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickValue))
        {
            //See if button has changed
            if (!joystickValue.Equals(_lastJoystickValue))
            {
                onJoystickUpdate.Invoke(joystickValue);
                _lastJoystickValue = joystickValue;
            }
        }
        
        
    }

}
