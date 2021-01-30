using UnityEngine;

namespace PoliticianStateMachine {
    public class PoliticianCalm : PoliticianState {
        [SerializeField] private Vector2 force = new Vector2(1, 0);
        [SerializeField] private float repeatRate = 0.5f;

        private float _timer;
        public PoliticianCalm(Politician politician) : base(politician) {
        }

        public override void OnEnable() {
            _timer = Politician.KeepCalm;
        }

        

        public override void FixedUpdate() {
            force *= -1;
            Politician.MyRigidbody2D.AddForce(force * Politician.SpeedEscape * Time.deltaTime);
            _timer -= Time.deltaTime;
            if (_timer <= 0) {
                ChangeStatus();
            }
        }

        private void ChangeStatus() {
            Politician.ChangeState(new PoliticianEscape(Politician));
        }
        
        public override void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Home") && other.transform == Politician.Group.transform) {
                Politician.ChangeState(new PoliticianReturnHome(Politician));
            }
        }
    }
}