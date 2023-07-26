using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DesktopNotifications;
using DesktopNotifications.Apple;
using DesktopNotifications.FreeDesktop;
using DesktopNotifications.Windows;
using FuzzySharp;
using Process = System.Diagnostics.Process;

namespace SteamCli {
      class Program
      {
          private static INotificationManager CreateManager()
          {
              if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
              {
                  return new FreeDesktopNotificationManager();
              }
   
              if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
              {
                  return new WindowsNotificationManager();
              }

              if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
              {
                  return new AppleNotificationManager();
              }

              throw new PlatformNotSupportedException();
          }
          public const string VERSION="0.0.2";
           static async Task Main(string[] args)
           {
               using var manager = CreateManager();
               await manager.Initialize();

               manager.NotificationActivated += ManagerOnNotificationActivated;
               manager.NotificationDismissed += ManagerOnNotificationDismissed;

               AppDataAnalyzer appDataAnalyzer = new AppDataAnalyzer();
               SteamInteractions steamInteractions = new SteamInteractions();
               string command;

               Console.Title = "SteamCLI" + VERSION;
               Console.Clear();
               Console.WriteLine("SteamCli "+VERSION);
               Console.WriteLine("\n# Type                      !help to view help menu");
               Console.WriteLine("# !start                      starts steam in smoool mode");
               Console.WriteLine("# !run \"gamename\"           runs a game");
               Console.WriteLine("# !update \"gamename\"        updates a game");
               Console.WriteLine("# !refresh                    downloads and reloads steam game list");
               Console.WriteLine("# !reload                     reloads steam game list");
               Console.WriteLine("# !quit                       shuts down SteamCLI");
               for (;;) 
               {
                   command =Console.ReadLine();
                   if (command.Contains("!start"))
                   {    
                       steamInteractions.RunSteam();
                       var notification = new Notification
                       {
                           Title = "SteamCLI",
                           Body = "Starting Steam in small mode"
                       };
                       await manager.ShowNotification(notification);

                   }
                   if (command.Contains("!run"))
                   {
                       var result =
                           appDataAnalyzer.FindMatch(command.Substring(command.IndexOf("!run") + 5, command.Length - 5))[0];
                       steamInteractions.RunGame(result);
                       var notification = new Notification
                       {
                           Title = "SteamCLI",
                           Body = $"Running {result.name}"
                       };
                       await manager.ShowNotification(notification);
                   }else if (command.Contains("!update"))
                   {
                       
                   }else if (command.Contains("!refresh"))
                   {
                       appDataAnalyzer.RefreshGameList();
                       var notification = new Notification
                       {
                           Title = "SteamCLI",
                           Body = $"Refreshed game list"
                       };
                       await manager.ShowNotification(notification);
                   }else if (command.Contains("!reload"))
                   {
                       appDataAnalyzer.AnalizeJson();
                       var notification = new Notification
                       {
                           Title = "SteamCLI",
                           Body = $"Reloaded game list"
                       };
                       await manager.ShowNotification(notification);
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
           private static void ManagerOnNotificationDismissed(object? sender, NotificationDismissedEventArgs e)
           {
               Console.WriteLine($"Notification dismissed: {e.Reason}");
           }

           private static void ManagerOnNotificationActivated(object? sender, NotificationActivatedEventArgs e)
           {
               Console.WriteLine($"Notification activated: {e.ActionId}");
           }
      }
};