using UnityEngine;
using UnityEngine.XR.Management;

namespace YYSX
{
    /// <summary>
    /// Simple YYSX settings showing how to create custom configuration data for your package.
    /// </summary>
    // Uncomment below line to have the settings appear in unified settings.
    [XRConfigurationData("YYSX", YYSXConstants.k_SettingsKey)]
    [System.Serializable]
    public class YYSXSettings : ScriptableObject
    {
#if !UNITY_EDITOR
        /// <summary>Static instance that will hold the runtime asset instance we created in our build process.</summary>
        /// <see cref="YYSXBuildProcessor"/>
        public static YYSXSettings s_RuntimeInstance = null;
#endif

        public enum StereoRenderingModeAndroid
        {
            MultiPass,
            Multiview
        }

        [SerializeField, Tooltip("Changes item requirement.")]
        StereoRenderingModeAndroid m_StereoRenderingModeAndroid;

        /// <summary>Whether or not the item is required.</summary>
        public StereoRenderingModeAndroid stereoRenderingModeAndroid
        {
            get { return m_StereoRenderingModeAndroid; }
            set { m_StereoRenderingModeAndroid = value; }
        }


        void Awake()
        {
            #if !UNITY_EDITOR
            s_RuntimeInstance = this;
            #endif
        }
    }
}
