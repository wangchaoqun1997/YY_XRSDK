using UnityEditor;

using UnityEngine;

namespace YYSX
{
    /// <summary>
    /// Simple custom editor used to show how to enable custom UI for XR Management
    /// configuraton data.
    /// </summary>
    //[CustomEditor(typeof(YYSXSettings))]
    public class YYSXSettingsEditor : Editor
    {
        static string k_RequiresProperty = "m_stereoRenderingModeAndroid";

        static GUIContent k_ShowBuildSettingsLabel = new GUIContent("Build Settings");
        static GUIContent k_RequiresLabel = new GUIContent("Item Requirement");

        bool m_ShowBuildSettings = true;

        SerializedProperty m_RequiesItemProperty;

        /// <summary>Override of Editor callback.</summary>
        public override void OnInspectorGUI()
        {
            if (serializedObject == null || serializedObject.targetObject == null)
                return;

            if (m_RequiesItemProperty == null) m_RequiesItemProperty = serializedObject.FindProperty(k_RequiresProperty);

            serializedObject.Update();
            m_ShowBuildSettings = EditorGUILayout.Foldout(m_ShowBuildSettings, k_ShowBuildSettingsLabel);
            if (m_ShowBuildSettings)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_RequiesItemProperty, k_RequiresLabel);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
