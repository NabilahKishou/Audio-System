using UnityEditor;
using UnityEngine;

namespace AudioSystem
{
    [CustomPropertyDrawer(typeof(VolumeReference))]
    public class VolumeReferenceDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var constantBool = property.FindPropertyRelative("_useConstant");
            var constValueFloat = property.FindPropertyRelative("_constantValue");
            var presetField = property.FindPropertyRelative("_preset");

            // Calculate rects
            var boolRect = new Rect(position.x, position.y, 30, position.height);
            var valueRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);
            var presetRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);

            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(boolRect, constantBool, GUIContent.none);
            if (constantBool.boolValue)
                constValueFloat.floatValue = EditorGUI.Slider(valueRect, constValueFloat.floatValue, 0, 1);
            else
                EditorGUI.PropertyField(presetRect, presetField, GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
