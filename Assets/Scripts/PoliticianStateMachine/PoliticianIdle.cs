namespace PoliticianStateMachine {
    public class PoliticianIdle : PoliticianState {
        public PoliticianIdle(Politician politician) : base(politician) {
        }

        public override void OnEnable() {
            Politician.Group.AddPolitician(Politician);
        }

        public override void OnDisable() {
            Politician.Group.RemovePolitician(Politician);
        }
    }
}