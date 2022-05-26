using System.Diagnostics;

namespace SteamCli;

public class SteamInteractions
{
    public void RunGame(Game game)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = "nohup";
        processStartInfo.Arguments = "steam steam://rungameid/"+game.appid +" > "+game.appid+".txt";
        processStartInfo.RedirectStandardOutput = true;
        //processStartInfo.UseShellExecute = true;
        Process.Start(processStartInfo);
        //Process.Start("nohup","steam steam://rungameid/"+game.appid +" > "+game.appid+".txt");
        Console.WriteLine("nohup steam steam://rungameid/"+game.appid +" > "+game.name+game.appid+".txt");
    }
}