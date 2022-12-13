using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.XR.Management;
using UnityEditor.XR.Management.Metadata;

namespace YYSX
{
    class YYSXPackage : IXRPackage
    {
        class YYSXLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName { get; set; }
            public string loaderType { get; set; }
            public List<BuildTargetGroup> supportedBuildTargets { get; set; }
        }

        class YYSXPackageMetadata : IXRPackageMetadata
        {
            public string packageName { get; set; }
            public string packageId { get; set; }
            public string settingsType { get; set; }
            public List<IXRLoaderMetadata> loaderMetadata { get; set; }
        }

        static IXRPackageMetadata s_Metadata = new YYSXPackageMetadata() {
                packageName = "YYSX",
                packageId = "com.unity.xr.yysx",
                settingsType = typeof(YYSXSettings).FullName,

                loaderMetadata = new List<IXRLoaderMetadata>() {
                    new YYSXLoaderMetadata() {
                        loaderName = "YYSX",
                        loaderType = typeof(YYSXLoader).FullName,
                        supportedBuildTargets = new List<BuildTargetGroup>() {
                            BuildTargetGroup.Standalone
                        }
                    },
                    new YYSXLoaderMetadata() {
                        loaderName = "YYSX",
                        loaderType = typeof(YYSXLoader).FullName,
                        supportedBuildTargets = new List<BuildTargetGroup>() {
                            BuildTargetGroup.Android
                        }
                    }
                }
        };

        const string k_PackageNotificationTooltip =
@"This loader is purely a sample and will not load any XR Device.

This message is a part of sample code to show how to register a loader that might contain issues or require additonal
context. One example could be that the package that contains this loader is being deprecated and any user who intends to
use the package needs to be aware of deprecation.

Click this icon to be taken to the XR Plug-in Management documentation home page.";
        const string k_PackageNotificationIcon = "console.warnicon.sml";
        const string k_PackageNotificationManagementDocsURL = @"https://docs.unity3d.com/Packages/com.unity.xr.management@latest/index.html";
        public IXRPackageMetadata metadata
        {
            get
            {
                //// Register package notification information anytime the metadata is asked requested.
                //var packageNotificationInfo = new PackageNotificationInfo(
                //    EditorGUIUtility.IconContent(k_PackageNotificationIcon),
                //    k_PackageNotificationTooltip,
                //    k_PackageNotificationManagementDocsURL);
                //PackageNotificationUtils.RegisterPackageNotificationInformation(s_Metadata.packageId, packageNotificationInfo);
                return s_Metadata;
            }
        }

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            return true;
        }

    }
}
