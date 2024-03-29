using System.Diagnostics;

namespace SteamCli;

public class SteamInteractions
{
    public void RunGame(Game game)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = "nohup";
        processStartInfo.Arguments = "steam -no-browser steam://rungameid/"+game.appid +" > "+game.appid+".txt";
        processStartInfo.RedirectStandardOutput = true;
        //processStartInfo.UseShellExecute = true;
        Process.Start(processStartInfo);
        //Process.Start("nohup","steam steam://rungameid/"+game.appid +" > "+game.appid+".txt");
        Console.WriteLine("nohup steam steam://rungameid/"+game.appid +" > "+game.name+game.appid+".txt");
    }

    public void RunSteam()
    {
        // +open steam://open/minigameslist
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = "nohup";
        processStartInfo.Arguments = "steam -no-browser +open steam://open/minigameslist > steam.txt";
        processStartInfo.RedirectStandardOutput = true;
        //processStartInfo.UseShellExecute = true;
        Process.Start(processStartInfo);
        //Process.Start("nohup","steam steam://rungameid/"+game.appid +" > "+game.appid+".txt");
    }
}