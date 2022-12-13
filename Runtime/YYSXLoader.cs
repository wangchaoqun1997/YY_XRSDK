using System.Collections.Generic;

using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem.Layouts;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.Management;
#endif

namespace YYSX
{

    /// <summary>
    /// YYSX loader implentation showing how to create simple loader.
    /// NOTE: You have to rename this class to make it appear in the loader list for
    /// XRManager.
    /// </summary>
#if UNITY_EDITOR
    [XRSupportedBuildTarget(BuildTargetGroup.Standalone, new BuildTarget[]{ BuildTarget.StandaloneWindows, BuildTarget.StandaloneWindows64})]
    [XRSupportedBuildTarget(BuildTargetGroup.Android)]
#endif
    public class YYSXLoader : XRLoaderHelper
    {
        [DllImport("unitydisplayprovider")]
        public static extern void NativeAPI_SetActivity(IntPtr native);

        static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new List<XRInputSubsystemDescriptor>();
        static List<XRDisplaySubsystemDescriptor> s_DisplaySubsystemDescriptors = new List<XRDisplaySubsystemDescriptor>();
        
        /// <summary>Return the currently active Input Subsystem intance, if any.</summary>
        public XRInputSubsystem inputSubsystem
        {
            get { return GetLoadedSubsystem<XRInputSubsystem>(); }
        }
        public XRDisplaySubsystem displaySubsystem
        {
            get { return GetLoadedSubsystem<XRDisplaySubsystem>(); }
        }

        YYSXSettings GetSettings()
        {
            YYSXSettings settings = null;
            // When running in the Unity Editor, we have to load user's customization of configuration data directly from
            // EditorBuildSettings. At runtime, we need to grab it from the static instance field instead.
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject(YYSXConstants.k_SettingsKey, out settings);
#else
            settings = YYSXSettings.s_RuntimeInstance;
#endif
            return settings;
        }

        public static YYSXLoader instanct;

#region XRLoader API Implementation

        /// <summary>Implementaion of <see cref="XRLoader.Initialize"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Initialize()
        {
            instanct = this;
            YYSXSettings settings = GetSettings();
            if (settings != null)
            {
                // TODO: Pass settings off to plugin prior to subsystem init.
            }
            LayoutMatcherRegister();

            CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(s_DisplaySubsystemDescriptors, "YYSX Display");
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, "YYSX Input");

            return true;

            //List<XRDisplaySubsystemDescriptor> displays = new List<XRDisplaySubsystemDescriptor>();

            //SubsystemManager.GetSubsystemDescriptors(displays);
            //Debug.Log("wangcq327 --- Number of display providers found: " + displays.Count);

            //foreach (var d in displays)
            //{
            //    //if (d.id.Contains(match)) {
            //    Debug.Log("wangcq327 ---Creating display " + d.id);
            //    XRDisplaySubsystem dispInst = d.Create();

            //    if (dispInst != null)
            //    {
            //        Debug.Log("wangcq327 ---Starting display " + d.id);
            //        dispInst.Start();
            //        dispInst.singlePassRenderingDisabled = true;
            //        Debug.Log("wangcq327 --- " + dispInst.supportedTextureLayouts);
            //    }
            //}

        }

        /// <summary>Implementaion of <see cref="XRLoader.Start"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Start()
        {
            if (Application.platform == RuntimePlatform.Android){
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                NativeAPI_SetActivity(activity.GetRawObject());
            }



            StartSubsystem<XRDisplaySubsystem>();
            StartSubsystem<XRInputSubsystem>();

            return true;
        }

        /// <summary>Implementaion of <see cref="XRLoader.Stop"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Stop()
        {
            StopSubsystem<XRDisplaySubsystem>();
            StopSubsystem<XRInputSubsystem>();
            return true;
        }

        /// <summary>Implementaion of <see cref="XRLoader.Deinitialize"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Deinitialize()
        {
            DestroySubsystem<XRDisplaySubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            return base.Deinitialize();
        }

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#endif
        static void LayoutMatcherRegister()
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

        #endregion
    }
}
