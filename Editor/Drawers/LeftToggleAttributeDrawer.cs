﻿using UnityEngine;
using UnityEditor;

namespace VermillionVanguard.Comprehensive2DController.InspectorAttributes
{
    [CustomPropertyDrawer(typeof(LeftToggleAttribute))]
    public class LeftToggleAttributeDrawer : BasePropertyDrawer 
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            DrawFieldWithToggleOnTheLeft(position, property, label);
        }
    }

}