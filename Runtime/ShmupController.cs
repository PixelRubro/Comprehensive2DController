using UnityEngine;

namespace SoftBoiledGames.Shmup
{
    [RequireComponent(typeof(Rigidbody2D))]
    abstract public class ShmupController : MonoBehaviour
    {
        #region Actions
        #endregion

        #region Serialized fields

        [SerializeField]
        private float _movingSpeed = 6.5f;

        #endregion

        #region Non-serialized fields

        private Rigidbody2D _rb2d;

        #endregion

        #region Properties
        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            AssignComponents();
        }

        protected virtual void Start()
        {
            ConfigureComponents();
        }

        #endregion

        #region Public methods

        public virtual void Move(Vector2 movementInput)
        {
            var movement = _movingSpeed * Time.deltaTime * movementInput.normalized;
            _rb2d.MovePosition(_rb2d.position + movement);
        }

        #endregion

        #region Internal methods
        #endregion

        #region Protected methods

        protected virtual void AssignComponents()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        protected virtual void ConfigureComponents()
        {
            _rb2d.isKinematic = true;
        }

        #endregion

        #region Private methods
        #endregion    
    }
}
