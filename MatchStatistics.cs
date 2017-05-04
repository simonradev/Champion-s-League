namespace ChampionsLeague
{
    public class MatchStatistics
    {
        private TeamScore firstTeamScore;
        private TeamScore secondTeamScore;

        private string winnerTeamName;
        private string loserTeamName;

        public MatchStatistics(string[] matchInfoToAggregate)
        {
            this.firstTeamScore = new TeamScore(matchInfoToAggregate[0]);
            this.secondTeamScore = new TeamScore(matchInfoToAggregate[1]);

            this.AggregateMatchInfo(matchInfoToAggregate);
            this.DecideWhoIsTheWinner();
        }

        public string WinnerTeamName
        {
            get { return this.winnerTeamName; }
        }

        public string LoserTeamName
        {
            get { return this.loserTeamName; }
        }

        private void AggregateMatchInfo(string[] matchInfoToAggregate)
        {
            int[] firstMatchGoals = StringManipulator.SplitString(matchInfoToAggregate[2], Constants.Column, Constants.parseFunc);
            int[] secondMatchGoals = StringManipulator.SplitString(matchInfoToAggregate[3], Constants.Column, Constants.parseFunc);

            FillTheGoalsForATeam(this.firstTeamScore, firstMatchGoals[0], secondMatchGoals[1]);
            FillTheGoalsForATeam(this.secondTeamScore, secondMatchGoals[0], firstMatchGoals[1]);
        }

        private void FillTheGoalsForATeam(TeamScore team, int onSoilGoals, int awaySoilGoals)
        {
            team.TeamAwaySoilGoals = awaySoilGoals;
            team.TeamOnSoilGoals = onSoilGoals;
        }

        private void DecideWhoIsTheWinner()
        {
            bool theFirstTeamIsTheWinner = true;
            
            if (this.firstTeamScore.TotalGoals < this.secondTeamScore.TotalGoals)
            {
                theFirstTeamIsTheWinner = false;
            }
            else if (this.firstTeamScore.TotalGoals == this.secondTeamScore.TotalGoals)
            {
                if (this.firstTeamScore.TeamAwaySoilGoals < this.secondTeamScore.TeamAwaySoilGoals)
                {
                    theFirstTeamIsTheWinner = false;
                }
            }

            if (theFirstTeamIsTheWinner)
            {
                this.winnerTeamName = this.firstTeamScore.TeamName;
                this.loserTeamName = this.secondTeamScore.TeamName;
            }
            else
            {
                this.winnerTeamName = this.secondTeamScore.TeamName;
                this.loserTeamName = this.firstTeamScore.TeamName;
            }
        }
    }
}
