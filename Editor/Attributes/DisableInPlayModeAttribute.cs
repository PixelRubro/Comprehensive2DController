﻿using System;

namespace VermillionVanguard.Comprehensive2DController.InspectorAttributes
{
    /// <summary>
    /// Make the field read-only when the editor is in play mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public sealed class DisableInPlayModeAttribute : CustomAttribute
    {
    }
}
