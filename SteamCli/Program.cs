using System;
using System.Diagnostics;
using FuzzySharp;
using Process = System.Diagnostics.Process;

namespace SteamCli {
      class Program
      {
          public const string VERSION="0.0.2";
           static void Main(string[] args)
           {
               AppDataAnalyzer appDataAnalyzer = new AppDataAnalyzer();
               Console.WriteLine("SteamCli "+VERSION);
            Console.WriteLine("\n# Type !help to view help menu");
            Console.WriteLine("# !run \"gamename\"          runs a game");
            Console.WriteLine("# !update \"gamename\"       updates a game");
            /*
            try
            {
                Process.Start("nohup","steam -no-browser steam://open/minigameslist");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            try
            {
                Process.Start("nohup","steam steam://rungameid/304930");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            */
            appDataAnalyzer.RefreshGameList();
           }
      }
};