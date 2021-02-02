using UnityEngine;

namespace PoliticianStateMachine {
    public abstract class PoliticianState {
        public Politician Politician { get; set; }

        public PoliticianState(Politician politician) {
            Politician = politician;
        }

        public virtual void FixedUpdate() {
        }

        public virtual void Update() {
        }

        public virtual void OnTriggerEnter2D(Collider2D other) {
        }

        public virtual void OnTriggerExit2D(Collider2D other) {
        }

        public virtual void OnCollisionEnter2D(Collision2D other) {
        }

        public virtual void OnCollisionExit2D(Collision2D other) {
        }

        public virtual void OnEnable() {
        }


        public virtual void OnDisable() {
        }

        public virtual void OnTriggerStay2D(Collider2D other) {
        }
    }
}