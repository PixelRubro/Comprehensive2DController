using UnityEngine;

namespace VermillionVanguard.Shmup.Samples
{
    // [RequireComponent(typeof(ShmupController))]
    public class KeyboardInput : MonoBehaviour
    {
        #region Actions
        #endregion

        #region Serialized fields
        #endregion

        #region Non-serialized fields

        // private ShmupController _controller;

        private float _verticalInput;

        private float _horizontalInput;

        #endregion

        #region Properties
        #endregion

        #region Unity events

        private void Awake()
        {
            // _controller = GetComponent<ShmupController>();
        }

        private void Update()
        {
            _verticalInput = 0f;

            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                _verticalInput += 1f;
            }

            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                _verticalInput -= 1f;
            }

            _horizontalInput = 0f;

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                _horizontalInput += 1f;
            }

            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                _horizontalInput -= 1f;
            }

            
        }

        private void FixedUpdate()
        {
            // _controller.Move(new Vector2(_horizontalInput, _verticalInput));
        }

        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion    
    }
}
