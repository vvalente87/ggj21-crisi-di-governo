using UnityEngine;

namespace PoliticianStateMachine {
    public class PoliticianEscape : PoliticianState {
        private Vector2 _lastPosition;

        private bool _isCheckFlipSprite = true;

        public PoliticianEscape(Politician politician) : base(politician) {
        }

        public override void OnEnable() {
            Politician.Group.RemovePolitician(Politician);
            Politician.gameObject.layer = 0; //layer default
        }


        // Update is called once per frame
        public override void FixedUpdate() {
            if (GameState.Instance.CurrentState == GameState.State.Run) {
                AddForce();
                Politician.Animator.SetFloat("Speed", 1);
                if (_isCheckFlipSprite) {
                    Politician.SpriteRenderer.flipX = Politician.MyRigidbody2D.position.x < _lastPosition.x;
                }

                _lastPosition = Politician.MyRigidbody2D.position;
            }
        }


        private void AddForce() {
            var exit = new Vector2(Politician.Exit.transform.position.x, Politician.Exit.transform.position.y);
            var direction = (exit - Politician.MyRigidbody2D.position).normalized;
            Politician.MyRigidbody2D.MovePosition(Politician.MyRigidbody2D.position + direction * (Politician.SpeedEscape * Time.deltaTime));
        }

        public override void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                Politician.ChangeState(new PoliticianCalm(Politician));
            }
            else if (other.GetComponent<Politician>() != null) {
                _isCheckFlipSprite = false;
            }
        }

        public override void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.GetComponent<Politician>() != null) {
                _isCheckFlipSprite = false;
            }
        }

        public override void OnCollisionExit2D(Collision2D other) {
            if (other.gameObject.GetComponent<Politician>() == null) {
                _isCheckFlipSprite = true;
            }
        }
    }
}