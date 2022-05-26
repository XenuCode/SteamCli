using System.Collections;
using FuzzySharp;

namespace SteamCli;

public class SearchGameList
{
    public static Game[] SearchBy(List<Game> games , string searchedPhrase)
    {
        long totalRatio = 0;
        long averageNum;
        foreach (var game in games)
        {
            game.matchValue = Fuzz.Ratio(game.name, searchedPhrase);
            totalRatio += game.matchValue;
        }
        averageNum = totalRatio / games.Count;
        games.Sort();
        Game[] matchingGames = new Game[5];
        for (int i = 0; i < 5; i++)
        {
            matchingGames[i] = games[games.Count - i -1];
        }
        return matchingGames;
    }
}