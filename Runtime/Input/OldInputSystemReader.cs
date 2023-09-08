using System.Collections.Generic;
using System.Linq;
using VermillionVanguard.Comprehensive2DController.Controller;
using UnityEngine;

namespace VermillionVanguard.Comprehensive2DController.InputReading
{
    public class OldInputSystemReader : MonoBehaviour
    {
        #region Serialized fields

        [SerializeField] private bool _preventInputs;
        [SerializeField] private List<InputCommand> _inputs;

        #endregion

        #region Non-serialized fields

        private PlayerController _controller;
        private PlayerInputAction _inputAction;
        private InputCommand _horizontalInput;
        private InputCommand _verticalInput;

        #endregion

        #region Properties

        public bool PreventInputs
        {
            get => _preventInputs;
            set => _preventInputs = value;
        }

        #endregion

        #region Unity events

        private void Awake()
        {
            _controller = GetComponent<PlayerController>();
        }

        private void Reset()
        {
            AddDefaultInputs();
            ResetToDefaults();
        }

        private void Start()
        {
            ValidateInputs();
            SetUpInputs();
        }

        private void SetUpInputs()
        {
            _horizontalInput = new InputCommand("Horizontal", "Horizontal", EInputAxis.Horizontal);
            _inputs.Add(_horizontalInput);
            _verticalInput = new InputCommand("Vertical", "Vertical", EInputAxis.Vertical);
            _inputs.Add(_verticalInput);
        }

        private void Update()
        {
            ProcessInputs();
            SendInputsToController();
        }

        #endregion

        #region Public methods

        public void ClearInputs()
        {
            _inputs.Clear();
        }

        public void ResetToDefaults()
        {
            AddDefaultInputs();
            _preventInputs = false;
        }

        #endregion

        #region Private methods

        private void ProcessInputs()
        {
            if (PreventInputs)
                return;

            foreach (var input in _inputs)
            {
                input.Process();
            }
        }

        private void SendInputsToController()
        {
            _inputAction = new PlayerInputAction();
            _inputAction.HorizontalMovement = _horizontalInput;
            _inputAction.VerticalMovement = _verticalInput;
            _controller.ProcessInputActions(_inputAction);
        }

        private void ValidateInputs()
        {
            if ((_inputs != null) && (_inputs.Count != 0)) return;

            Debug.LogError("No inputs assigned.");
        }

        private IEnumerable<InputCommand> FindInputButtons(EInputAction action)
        {
            return _inputs.Where(i => i.IsAxis == false && i.AssignedAction == action);
        }

        private IEnumerable<InputCommand> FindInputAxis(EInputAxis axis)
        {
            return _inputs.Where(i => i.IsAxis && i.Axis == axis);
        }

        private void AddDefaultInputs()
        {
            if (_inputs != null)
            {
                _inputs.Clear();
            }
            else
            {
                _inputs = new List<InputCommand>();
            }

            if (_inputs.Count != 0) return;

            var input = new InputCommand("Horizontal", "Horizontal", EInputAxis.Horizontal);
            _inputs.Add(input);
            input = new InputCommand("Vertical", "Vertical", EInputAxis.Vertical);
            _inputs.Add(input);
        }

        #endregion
    }
}