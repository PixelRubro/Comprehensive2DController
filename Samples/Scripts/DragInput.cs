using UnityEngine;

namespace SoftBoiledGames.Shmup.Samples
{
    [RequireComponent(typeof(Collider2D))]
    public class DragInput : MonoBehaviour
    {
        #region Actions
        #endregion

        #region Serialized fields
        #endregion

        #region Non-serialized fields

        private Camera _mainCamera;

        private ShmupController _controller;

        private Transform _transform;

        #endregion

        #region Constant fields

        private const float MinimumDistanceToCursor = 0.1f;

        #endregion

        #region Unity events

        private void Awake()
        {
            _controller = GetComponent<ShmupController>();
            _transform = transform;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDrag()
        {
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mouseWorldPosition, _transform.position) > MinimumDistanceToCursor)
            {
                var directionToMouse = mouseWorldPosition - _transform.position;
                _controller.Move(directionToMouse);
            }
        }
        
        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion    
    }
}
