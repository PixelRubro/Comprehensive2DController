using UnityEditor;
using UnityEngine;

namespace VermillionVanguard.Comprehensive2DController.InspectorAttributes
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfAttributeDrawer : ConditionalAttributeDrawer
    {
        protected override PropertyDrawing GetPropertyDrawing()
        {
            return PropertyDrawing.Show;
        }
    }
}