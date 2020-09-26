using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace FeedReader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Feeds reader!");
            Console.WriteLine();

            var url = "https://devblogs.microsoft.com/visualstudio/feed/";
            ConsoleWrite($"URL", ConsoleColor.Cyan, false);
            ConsoleWrite($"\t\t\t{url}", ConsoleColor.Green);

            ConsoleWrite("Reading feed...", ConsoleColor.Cyan, false);
            using var reader = XmlReader.Create(url);
            ConsoleWrite("\t\tFeed read!", ConsoleColor.Yellow);

            ConsoleWrite("Loading feed...", ConsoleColor.Cyan, false);
            var feed = SyndicationFeed.Load(reader);
            ConsoleWrite("\t\tFeed loaded!", ConsoleColor.Yellow);

            ConsoleWrite("Items...", ConsoleColor.Cyan, false);
            ConsoleWrite($"\t\t({feed.Items.Count()})", ConsoleColor.Green);
            foreach (var item in feed.Items)
            {
                ConsoleWrite($"\tTitle", ConsoleColor.Cyan, false);
                ConsoleWrite($"\t\t{item.Title.Text}", ConsoleColor.Yellow);
                ConsoleWrite($"\tLink", ConsoleColor.Cyan, false);
                ConsoleWrite($"\t\t{item.Links[0].Uri}", ConsoleColor.Yellow);
                ConsoleWrite($"\tPublish Date", ConsoleColor.Cyan, false);
                ConsoleWrite($"\t{item.PublishDate}", ConsoleColor.Yellow);
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to close!");
            Console.ReadKey();
        }

        private static void ConsoleWrite(string text, ConsoleColor textColor, bool newLine = true)
        {
            Console.ForegroundColor = textColor;
            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);
            Console.ResetColor();
        }
    }
}