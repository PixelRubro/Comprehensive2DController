using UnityEngine;

namespace VermillionVanguard.Comprehensive2DController.InputReading
{
    public enum EInputState
    {
        Idle,
        Pressed,
        Hold,
        Released,
        Unused,
        Disabled
    }

    public enum EInputAction
    {
        ActionButton,
        JumpButton,
        RunButton,
        DashButton,
        GrabButton,
        GuardButton,
        ShootingButton,
        AimButton,
        LightAttackButton,
        HeavyAttackButton
    }

    public enum EInputAxis
    {
        Horizontal,
        Vertical
    }
    
    public class PlayerInputAction
    {
        public InputCommand HorizontalMovement;
        public InputCommand VerticalMovement;
    }

    [System.Serializable]
    public class InputCommand
    {
        #region Static fields

        /// <summary>
        /// Triggers an action when releasing a button after holding it.
        /// EInputAction: input action, float: time holding button.
        /// </summary>
        public System.Action<EInputAction, float> OnHoldingTimeUp;

        #endregion

        #region Public fields

        public string Label;

        // [Input]
        public string InputName;

        // [ShowIf(nameof(HasStandardInput))]
        // [LeftToggle]
        public bool HasAlternativeInput;

        // [ShowIf(nameof(HasAlternativeInput))]
        // [Label("Alt Input Name")]
        // [Input]
        public string AlternativeInputName;

        // [LeftToggle]
        public bool IsActive = true;

        // [LeftToggle]
        public bool IsAxis;

        // [ShowIf(nameof(IsAxis))]
        public EInputAxis Axis;

        // [ShowIf(nameof(IsAxis), false)]
        public EInputAction AssignedAction;

        // [ShowIf(nameof(IsAxis))]
        // [ReadOnly]
        public float Value;

        // [ShowIf(nameof(IsAxis), false)]
        // [ReadOnly]
        public EInputState State;

        // [HideIf(nameof(IsAxis))]
        // [ReadOnly]
        public float HoldingTimeDuration;

        #endregion

        #region Private fields

        private bool _inputHoldingRequested;
        private float _timeHoldingRequested;

        #endregion

        #region Constant fields

        private const string EmptyInputValue = "<none>";

        #endregion

        #region Properties

        public bool IsPressed => Value != 0f;
        private bool HasStandardInput => !IsAxis && InputName != null && !InputName.Equals(EmptyInputValue);

        #endregion

        #region Constructors

        public InputCommand(string label, string inputName, EInputAxis axis)
        {
            Label = label;
            InputName = inputName;
            IsAxis = true;
            Axis = axis;
            IsActive = true;
            HasAlternativeInput = false;
            AlternativeInputName = EmptyInputValue;
        }

        public InputCommand(string label, string inputName, EInputAction assignedAction)
        {
            Label = label;
            InputName = inputName;
            AssignedAction = assignedAction;
            IsAxis = false;
            IsActive = true;
            HasAlternativeInput = false;
            AlternativeInputName = EmptyInputValue;
        }

        #endregion

        #region Public methods

        public void Process()
        {
            if (!IsActive)
                return;

            if (IsAxis)
            {
                UpdateAxisValue();
            }
            else
            {
                UpdateState();
            }

            CountHoldingTime();
        }

        public void RequestInputHolding(float duration)
        {
            _inputHoldingRequested = true;
            _timeHoldingRequested = duration;
        }

        #endregion

        #region Private methods

        private void UpdateAxisValue()
        {
            Value = Input.GetAxisRaw(InputName);
        }

        private void UpdateState()
        {
            if ((State == EInputState.Disabled) || (State == EInputState.Unused))
                return;
            
            if (CheckForButtonPress())
                State = EInputState.Pressed;
            else if (CheckForButtonHold())
                State = EInputState.Hold;
            else if (CheckForButtonRelease())
                State = EInputState.Released;
            else
                State = EInputState.Idle;
        }

        private bool CheckForButtonPress()
        {
            if (Input.GetButtonDown(InputName))
            {
                return true;
            }
                
            return (HasAlternativeInput) && (Input.GetButtonDown(AlternativeInputName));
        }

        private bool CheckForButtonHold()
        {
            if (Input.GetButton(InputName))
            {
                return true;
            }

            return (HasAlternativeInput) && (UnityEngine.Input.GetButton(AlternativeInputName));
        }

        private bool CheckForButtonRelease()
        {
            if (Input.GetButtonUp(InputName))
            {
                return true;
            }

            return (HasAlternativeInput) && (UnityEngine.Input.GetButtonUp(AlternativeInputName));
        }

        private void CountHoldingTime()
        {
            if (State == EInputState.Hold)
            {
                HoldingTimeDuration += Time.deltaTime;
            }
            else
            {
                if ((_inputHoldingRequested) && (HoldingTimeDuration >= _timeHoldingRequested))
                {
                    _inputHoldingRequested = false;
                    _timeHoldingRequested = 0f;
                    OnHoldingTimeUp?.Invoke(AssignedAction, HoldingTimeDuration);
                }

                HoldingTimeDuration = 0f;
            }
        }

        #endregion
    }
}