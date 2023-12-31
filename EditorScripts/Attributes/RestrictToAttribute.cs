using System;
using UnityEngine;
using UnityEditor;

namespace ArchitectureLibrary
{
    public class RestrictToAttribute : PropertyAttribute
    {
        public Type type;
        public RestrictToAttribute(Type type) => this.type = type;
    }

    [CustomPropertyDrawer(typeof(RestrictToAttribute))]
    public class RestrictToDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RestrictToAttribute restrictTo = attribute as RestrictToAttribute;

            property.objectReferenceValue = EditorGUI.ObjectField(position, StringFormatter.ToTitleCase(property.name), property.objectReferenceValue, restrictTo.type, true);
        }
    }
}