using UnityEngine;

namespace PoliticianStateMachine {
    public class PoliticianEscape : PoliticianState {
        public PoliticianEscape(Politician politician) : base(politician) {
        }


        // Update is called once per frame
        public override void FixedUpdate() {
            AddForce();
        }


        private void AddForce() {
            var exit = new Vector2(Politician.Exit.transform.position.x, Politician.Exit.transform.position.y);
            var direction = (exit - Politician.MyRigidbody2D.position).normalized;

            Politician.MyRigidbody2D.MovePosition(Politician.MyRigidbody2D.position + direction * (Politician.SpeedEscape * Time.deltaTime));
            //  Politician.MyRigidbody2D.AddForce((Politician.Exit.transform.position - Politician.transform.position).normalized * Politician.SpeedEscape * Time.deltaTime);
        }

        public override void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                Politician.ChangeState(new PoliticianCalm(Politician));
            }
        }
    }
}