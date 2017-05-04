namespace ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        private static List<TeamStatistics> allTeamsStatistics;

        public static void Main()
        {
            allTeamsStatistics = new List<TeamStatistics>();

            string inputLine = StringManipulator.GetInputLine();
            while (inputLine != "stop")
            {
                string[] matchInfo = StringManipulator.SplitString(inputLine, Constants.Pipe, Constants.trimFunc);

                MatchStatistics currentMatchStatistics = new MatchStatistics(matchInfo);

                string winnerTeamName = currentMatchStatistics.WinnerTeamName;
                string loserTeamName = currentMatchStatistics.LoserTeamName;

                FillTheStatisticsForAllTheTeams(winnerTeamName, loserTeamName, true);
                FillTheStatisticsForAllTheTeams(loserTeamName, winnerTeamName, false);

                inputLine = StringManipulator.GetInputLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            StringBuilder result = new StringBuilder();

            foreach (TeamStatistics teamStats in allTeamsStatistics
                                                    .OrderByDescending(t => t.TotalWins)
                                                    .ThenBy(t => t.TeamName))
            {
                result.AppendLine(teamStats.TeamName);

                result.AppendLine($"- Wins: {teamStats.TotalWins}");

                result.AppendLine($"- Opponents: {string.Join(", ", teamStats.OpponentsNames.OrderBy(x => x))}");
            }

            Console.Write(result);
        }

        private static void FillTheStatisticsForAllTheTeams(string teamName, string opponent, bool isWinner)
        {
            TeamStatistics currentTeamStatistics = allTeamsStatistics
                                                    .FirstOrDefault(t => t.TeamName == teamName);

            bool teamAlreadyExists = true;
            if (currentTeamStatistics == default(TeamStatistics))
            {
                teamAlreadyExists = false;

                currentTeamStatistics = new TeamStatistics(teamName);
            }

            currentTeamStatistics.OpponentsNames.Add(opponent);

            if (isWinner)
            {
                currentTeamStatistics.TotalWins++;
            }

            if (!teamAlreadyExists)
            {
                allTeamsStatistics.Add(currentTeamStatistics);
            }
        }
    }
}
