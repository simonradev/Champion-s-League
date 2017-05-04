namespace ChampionsLeague
{
    using System.Collections.Generic;
    public class TeamStatistics
    {
        private string teamName;
        private int totalWins;
        private List<string> opponontsNames;

        public TeamStatistics(string teamName)
        {
            this.teamName = teamName;
            this.totalWins = 0;
            this.opponontsNames = new List<string>();
        }

        public string TeamName
        {
            get { return this.teamName; }
        }

        public int TotalWins
        {
            get { return this.totalWins; }
            set { this.totalWins = value; }
        }

        public List<string> OpponentsNames
        {
            get { return this.opponontsNames; }
            set { this.opponontsNames = value; }
        }
    }
}
