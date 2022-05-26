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
               SteamInteractions steamInteractions = new SteamInteractions();
               string command;

               Console.Title = "SteamCLI" + VERSION;
               Console.Clear();
               Console.WriteLine("SteamCli "+VERSION);
               Console.WriteLine("\n# Type                      !help to view help menu");
               Console.WriteLine("# !run \"gamename\"           runs a game");
               Console.WriteLine("# !update \"gamename\"        updates a game");
               Console.WriteLine("# !refresh                    downloads and reloads steam game list");
               Console.WriteLine("# !reload                     reloads steam game list");
               Console.WriteLine("# !quit                       shuts down SteamCLI");
               for (;;) 
               {
                   command =Console.ReadLine();
                   if (command.Contains("!run"))
                   {
                       steamInteractions.RunGame(appDataAnalyzer.FindMatch(command.Substring(command.IndexOf("!run")+ 5,command.Length-5))[0]);
                   }else if (command.Contains("!update"))
                   {
                       
                   }else if (command.Contains("!refresh"))
                   {
                       appDataAnalyzer.RefreshGameList();
                   }else if (command.Contains("!reload"))
                   {
                       appDataAnalyzer.AnalizeJson();
                   }
                   else if (command.Contains("!quit"))
                   {
                       return;
                   }
               }
               
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