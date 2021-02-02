namespace PoliticianStateMachine {
    public class PoliticianIdle : PoliticianState {
        public PoliticianIdle(Politician politician) : base(politician) {
        }

        public override void OnEnable() {
            Politician.Group.AddPolitician(Politician);
            Politician.Animator.SetFloat("Speed", 0);
            Politician.gameObject.layer = 2; //layer ignore raycast
        }

        public override void OnDisable() {
            Politician.Group.RemovePolitician(Politician);
        }
    }
}