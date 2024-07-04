using UnityEditor;
using UnityEngine;

namespace AudioSystem
{
    [CustomPropertyDrawer(typeof(PitchReference))]
    public class PitchReferenceDrawer : PropertyDrawer
    {
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
            var minLimFloat = property.FindPropertyRelative("_minLimit");
            var maxLimFloat = property.FindPropertyRelative("_maxLimit");
            var minValFloat = property.FindPropertyRelative("_minValue");
            var maxValFloat = property.FindPropertyRelative("_maxValue");

            var minVal = minValFloat.floatValue;
            var maxVal = maxValFloat.floatValue;

            // Calculate rects
            var boolRect = new Rect(position.x, position.y, 30, position.height);
            var constRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);

            float spacing = 10f;
            var minRect = new Rect(boolRect.x + 20, position.y, 30, position.height);
            var sliderect = new Rect(minRect.x + minRect.width + spacing, position.y, position.width - boolRect.width - spacing - minRect.width * 2, position.height);
            var maxRect = new Rect(sliderect.x + sliderect.width + spacing, position.y, 30, position.height);

            // Draw fields - pass GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(boolRect, constantBool, GUIContent.none);
            if (constantBool.boolValue)
                constValueFloat.floatValue = EditorGUI.Slider(constRect, constValueFloat.floatValue, minLimFloat.floatValue, maxLimFloat.floatValue);
            else
            {
                minVal = EditorGUI.FloatField(minRect, minValFloat.floatValue);
                maxVal = EditorGUI.FloatField(maxRect, maxValFloat.floatValue);
                EditorGUI.MinMaxSlider(sliderect, ref minVal, ref maxVal, minLimFloat.floatValue, maxLimFloat.floatValue);
            }

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            // And finally update the variables
            if (EditorGUI.EndChangeCheck())
            {
                minValFloat.floatValue = (float)System.Math.Round(minVal, 3);
                maxValFloat.floatValue = (float)System.Math.Round(maxVal, 3);
            }
            EditorGUI.EndProperty();
        }
    }
}
