using System;
using UnityEditor;
using UnityEngine;

namespace PoliticianStateMachine {
    public class Politician : MonoBehaviour {
        [SerializeField] private GameObject exit;
        [SerializeField] private float speedEscape = 1f;
        [SerializeField] private float speedReturnHome = 1f;
        [SerializeField] private float keepCalm = 5f;
        [SerializeField] private float minDistanceFromHome = 0.1f;
        private PoliticianState _state;
        private PoliticianGroup _group;
        private Rigidbody2D _myRigidbody2D;
        private Collider2D _collider2D;
        private Vector2 _startPosition;

        public PoliticianGroup Group {
            get => _group;
            set => _group = value;
        }

        public GameObject Exit {
            get => exit;
            set => exit = value;
        }

        public Rigidbody2D MyRigidbody2D => _myRigidbody2D;

        public float SpeedEscape {
            get {
                if (Group != null)
                    return Group.SpeedEscape;
                else return speedEscape;
            }
        }

        public float KeepCalm => keepCalm;

        public float MINDistanceFromHome => minDistanceFromHome;

        public Vector2 StartPosition => _startPosition;

        public float SpeedReturnHome => speedReturnHome;

        // Start is called before the first frame update
        void Awake() {
            _myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
            _group = transform.parent.GetComponent<PoliticianGroup>();
            _collider2D = GetComponent<Collider2D>();
        }

        void Start() {
            ChangeState(new PoliticianIdle(this));
        }

        private void OnEnable() {
            if (_state != null)
                _state.OnEnable();
        }

        private void OnDisable() {
            _state.OnDisable();
        }

        // Update is called once per frame
        void Update() {
            _state.Update();
        }

        void FixedUpdate() {
            _state.FixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            _state.OnTriggerEnter2D(other);
        }

        private void OnTriggerExit2D(Collider2D other) {
            _state.OnTriggerExit2D(other);
        }

        public void ForceEscape() {
            ChangeState(new PoliticianEscape(this));
        }

        public void ChangeState(PoliticianState state) {
            if (_state != null) {
                _state.OnDisable();
            }

            _state = state;
            _state.OnEnable();
        }

        void OnDrawGizmos() {
            //    if (Application.isPlaying)
            //        Handles.Label(transform.position, _state.ToString());
            // Draw a yellow sphere at the transform's position
        }
    }
}