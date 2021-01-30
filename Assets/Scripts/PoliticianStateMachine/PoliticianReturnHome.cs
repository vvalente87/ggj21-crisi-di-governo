using UnityEngine;

namespace PoliticianStateMachine {
    public class PoliticianReturnHome : PoliticianState {
        public PoliticianReturnHome(Politician politician) : base(politician) {
        }

        public override void FixedUpdate() {
            if (Vector2.Distance(Politician.StartPosition, Politician.MyRigidbody2D.position) > Politician.MINDistanceFromHome) {
                ReturnToHome();
            }
            else {
                ApplyIdleStatus();
            }
        }

        private void ApplyIdleStatus() {
            Politician.ChangeState(new PoliticianIdle(Politician));
        }

        private void ReturnToHome() {
            Politician.MyRigidbody2D.MovePosition(Politician.MyRigidbody2D.position + (Politician.StartPosition - Politician.MyRigidbody2D.position).normalized * (Politician.SpeedReturnHome * Time.deltaTime));
        }
    }
}