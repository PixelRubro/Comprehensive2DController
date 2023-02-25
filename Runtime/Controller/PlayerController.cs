using System;
using PixelSpark.Comprehensive2DController.InputReading;
using PixelSpark.Comprehensive2DController.InspectorAttributes;
using UnityEngine;

namespace PixelSpark.Comprehensive2DController.Controller
{
    public abstract class PlayerController : MonoBehaviour
    {
        [SerializeField] [DisableInPlayMode] private bool _hasMovingAbility;
        [SerializeField] [DisableInPlayMode] private bool _hasFlyingAbility;

        #region Unity events

        private void Start()
        {
            AddAbilities();
        }

        #endregion

        #region Public methods
        
        public void ProcessInputActions(PlayerInputAction inputAction)
        {
            ProcessAbilities();
        }

        public void AddAbility()
        {
            
        }

        #endregion

        #region Private 

        private void AddAbilities()
        {
            throw new NotImplementedException();
        }

        private void ProcessAbilities()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
