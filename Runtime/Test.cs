using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;


public class Test : MonoBehaviour {

    [DllImport("unitydisplayprovider")]
    public static extern void NativeAPI_SetActivity(IntPtr native);

    Coroutine t; 
    
    public string match = "Display Sample";

#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#endif
    static void EditorInit()
    {
        UnityEngine.InputSystem.InputSystem.RegisterLayout<XRController>(
                  matches: new InputDeviceMatcher()
                      .WithInterface(XRUtilities.InterfaceMatchAnyVersion)
                      .WithProduct("YYSX Controller")
                      );

        UnityEngine.InputSystem.InputSystem.RegisterLayoutMatcher<XRHMD>(
          new InputDeviceMatcher()
              //.WithInterface(XRUtilities.InterfaceMatchAnyVersion)
              .WithProduct("YYSX HMD")
              );

    }

    public void ControlInvoke(UnityEngine.InputSystem.InputAction.CallbackContext CallbackContext) {
       // Debug.Log("wangcq327 --------- ControlInvoke ==============================:"+ CallbackContext.control.name);
    }
    IEnumerator xx() {
        while (true)
        {
            yield return new WaitForEndOfFrame();
           // Debug.Log(Time.frameCount + "============>Q: WaitForEndOfFrame");
        }
    }
    private void OnEnable()
    {
        StartCoroutine(xx());
        EditorInit();
        buttonAction.Enable();
        buttonAction.performed += buttionActionPerformed;

        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;


        UnityEngine.InputSystem.InputSystem.onDeviceChange +=
    (device, change) =>
    {
        switch (change)
        {
            case UnityEngine.InputSystem.InputDeviceChange.Added:
                Debug.Log("wangcq327 -------------------------- New device added: " + device+" isNative:"+device.native+" "+device.description.product+" |" + device.description.interfaceName + " |" + device.description.manufacturer + " |" + device.description.ToJson());
                break;

            case UnityEngine.InputSystem.InputDeviceChange.Removed:
                Debug.Log("wangcq327 -------------------------- Device removed: " + device + " isNative:" + device.native);
                break;
        }
    };





        //if (t != null)
        //{
        //    StopCoroutine(wait());
        //}
        //t = StartCoroutine(wait());
        //YYSX.YYSXLoader.instanct.Startx();

    }
    //IEnumerator wait()
    //{
    //    yield return new WaitForSeconds(10);
    //    Startx();
    //}
    private void buttionActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       // Debug.Log("wangcq327 ---------+++" + obj.control.name+"  "+ obj.ReadValue<Quaternion>());
    }

    // Start is called before the first frame update
    void Start() {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            NativeAPI_SetActivity(activity.GetRawObject());
        }
        //Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnEnable:" + activity.GetRawObject());

        //Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO Start");

        List<XRDisplaySubsystemDescriptor> displays = new List<XRDisplaySubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(displays);
        Debug.Log("wangcq327 --- Number of display providers found: " + displays.Count);

        foreach (var d in displays)
        {
            //if (d.id.Contains(match)) {
            Debug.Log("wangcq327 ---Creating display " + d.id);
            XRDisplaySubsystem dispInst = d.Create();

            if (dispInst != null)
            {
                Debug.Log("wangcq327 ---Starting display " + d.id);
                dispInst.Start();
                dispInst.singlePassRenderingDisabled = true;
                Debug.Log("wangcq327 --- " + dispInst.supportedTextureLayouts);
            }
            //}
        }



        List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new List<XRInputSubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(s_InputSubsystemDescriptors);
        Debug.Log("wangcq327 --- Number of tracking providers found: " + s_InputSubsystemDescriptors.Count);

        foreach (var d in s_InputSubsystemDescriptors)
        {
            //if (d.id == "Head Tracking Sample")
            {
                Debug.Log("wangcq327 ---Creating input " + d.id);
                XRInputSubsystem trackingInst = d.Create();

                if (trackingInst != null)
                {
                    Debug.Log("wangcq327 ---Starting input " + d.id);
                    trackingInst.Start();
                }
            }
        }


        //foreach (var device in UnityEngine.InputSystem.InputSystem.devices) {
        //    Debug.Log("wangcq327 -----------------:" + device);
        //}

        buttonAction.performed += buttionActionPerformed;


    }

    public PrimaryButtonEvent primaryButtonPress;

    private List<InputDevice> devicesWithPrimaryButton;

    private void InputDevices_deviceConnected(InputDevice device)
    {
        Debug.Log("wangcq327 ---InputDevices_deviceConnected:"+ device.name);


        //bool discardedValue;
        //if (device.TryGetFeatureValue(CommonUsages.primaryButton, out discardedValue))
        //{
        //    devicesWithPrimaryButton.Add(device); // Add any devices that have a primary button.
        //}
        Debug.Log("wangcq327 ---InputDevices_deviceConnected END:" + device.name);
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        Debug.Log("wangcq327 ---InputDevices_deviceDisconnected");
        if (devicesWithPrimaryButton.Contains(device))
            devicesWithPrimaryButton.Remove(device);
    }


    public UnityEngine.InputSystem.InputAction buttonAction;
    void Update()
    {

        //foreach (var device in UnityEngine.InputSystem.InputSystem.devices)
        //{
        //    Debug.Log(Time.frameCount+"  wangcq327 -----------------+++++++++++:" + device);
        //    foreach (var control in device.allControls) {
        //        Debug.Log(Time.frameCount + "  wangcq327 -----------------:" + control.name+" "+control.layout+" "+control.path+" "+control.device.name+" "+control.usages.Count);
        //        foreach (var usage in control.usages)
        //        {
        //            Debug.Log(Time.frameCount + "  wangcq327 ----------------usageusageusage-:" + usage);
        //        }
        //    }
        //}
        //if (buttonAction == null)
        //{
        //    //buttonAction = new UnityEngine.InputSystem.InputAction("fire", binding: "/YYController/controllergripbutton");
        //    //buttonAction.Add("< ControllerLayout >/ GripButton");
        //    buttonAction = new UnityEngine.InputSystem.InputAction("fire", binding: "<ControllerLayout>{LeftHand}/ControllerGripButton");
        //}
        //Debug.Log("wangcq327 --------+++++:" + buttonAction.IsPressed() + "  " + buttonAction.WasPressedThisFrame() + " " + buttonAction.ReadValue<Quaternion>());


        //var inputDevices = new List<UnityEngine.XR.InputDevice>();
        //UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        //Debug.Log("wangcq327 ---GetDevices: " + inputDevices.Count);
        //foreach (var device in inputDevices)
        //{
        //    Debug.Log(string.Format("wangcq327 --- Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        //}



        //var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        //var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.TrackedDevice | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        //UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);

        //Debug.Log("wangcq327 ---GetDevicesWithCharacteristics: " + leftHandedControllers.Count);
        //foreach (var device in leftHandedControllers)
        //{
        //    Debug.Log(string.Format("wangcq327 --- Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        //}

        ////获取已经连接的上的，且XRNode 指定的inputDevice：
        //var leftControllerDevices = new List<UnityEngine.XR.InputDevice>();
        //UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.GameController, leftControllerDevices);

        //if (leftControllerDevices.Count == 1)
        //{
        //    UnityEngine.XR.InputDevice device = leftControllerDevices[0];
        //    Debug.Log(string.Format("wangcq327 --- Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        //}
        //else if (leftControllerDevices.Count > 1)
        //{
        //    Debug.Log("Found more than one left hand!");
        //}

        ////访问inputDevice的某个feature值
        //bool triggerValue;
        //leftControllerDevices[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue);
        //if (triggerValue){
        //    Debug.Log(Time.frameCount + " wangcq327 --- Trigger button is pressed.");
        //}else {
        //    Debug.Log(Time.frameCount + " wangcq327 --- Trigger button is release.");
        //}


    }

    //// Update is called once per frame
    //void Update() {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO Update");

    //}

    //private void LateUpdate() {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO LateUpdate");
    //}

    //private void OnPreCull() {

    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnPreCull");
    //}

    //private void OnPreRender() {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnPreRender");
    //}

    //private void OnRenderObject() {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnRenderObject");
    //}

    //private void OnPostRender() {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnPostRender");
    //}

    //private void OnRenderImage(RenderTexture source, RenderTexture destination) {
    //    Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO OnRenderImage");
    //    Graphics.Blit(source, destination);
    //}

    //IEnumerator endofframe() {
    //    while (true) {
    //        yield return new WaitForEndOfFrame();
    //        Debug.Log(Time.frameCount + " wangcq327 --- CameraMONO endofframe");
    //    }
    //}
}
public class PrimaryButtonEvent : UnityEvent<bool> { }