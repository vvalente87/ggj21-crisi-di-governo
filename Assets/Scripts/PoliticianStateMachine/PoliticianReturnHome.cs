using UnityEngine;

namespace PoliticianStateMachine {
    public class PoliticianReturnHome : PoliticianState {
        public PoliticianReturnHome(Politician politician) : base(politician) {
        }

        private Vector2 fromPosition;

        private float time = 2;
        private float currentTime = 0;

        public override void OnEnable() {
            fromPosition = Politician.MyRigidbody2D.position;
            var totalDistance = Vector2.Distance(fromPosition, Politician.StartPosition);
            time = totalDistance / 2.0f;
        }

        public override void FixedUpdate() {
            //if (Mathf.Abs(Vector2.Distance(Politician.StartPosition, Politician.MyRigidbody2D.position)) > 0.01f) {
            if (Politician.MyRigidbody2D.position != Politician.StartPosition) {
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
            //  Politician.MyRigidbody2D.position = Politician.StartPosition;
            var totalDistance = Vector2.Distance(fromPosition, Politician.StartPosition);
            var currentDistance = Vector3.Distance(Politician.MyRigidbody2D.position, fromPosition);
            Debug.Log(currentDistance + " " + totalDistance);
            Debug.Log((totalDistance - currentDistance) / totalDistance);
            Politician.MyRigidbody2D.velocity = Vector2.zero;
            Politician.MyRigidbody2D.MovePosition(Vector2.Lerp(fromPosition, Politician.StartPosition, currentTime / time));
            currentTime += Time.deltaTime;
            //Politician.MyRigidbody2D.MovePosition(Politician.MyRigidbody2D.position + distance * Politician.SpeedReturnHome * Time.deltaTime);
            Politician.Animator.SetFloat("Speed", 1);
        }
    }
}