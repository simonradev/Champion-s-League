namespace ChampionsLeague
{
    public class TeamScore
    {
        private string teamName;
        private int teamOnSoilGoals;
        private int teamAwaySoilGoals;

        public TeamScore(string teamName)
        {
            this.teamName = teamName;
        }

        public string TeamName
        {
            get { return this.teamName; }
        }

        public int TeamOnSoilGoals
        {
            get { return this.teamOnSoilGoals; }
            set { this.teamOnSoilGoals = value; }
        }

        public int TeamAwaySoilGoals
        {
            get { return this.teamAwaySoilGoals; }
            set { this.teamAwaySoilGoals = value; }
        }

        public int TotalGoals
        {
            get { return (this.teamOnSoilGoals + this.teamAwaySoilGoals); }
        }
    }
}
