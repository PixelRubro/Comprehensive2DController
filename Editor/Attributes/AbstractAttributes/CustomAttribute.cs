using UnityEngine;

namespace PixelSpark.Comprehensive2DController.InspectorAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public abstract class CustomAttribute : PropertyAttribute
    {
    }
}
