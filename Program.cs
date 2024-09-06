using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input Notification:");
        string input = Console.ReadLine();

        List<string> channelsResult = ChannelParser(input);
        Console.WriteLine($"Receive channels: {string.Join(", ", channelsResult)}");
    }
    static List<string> ChannelParser(string notificationInput)
    {
        List<string> allChannels = new List<string> { "BE", "FE", "QA", "Urgent" };
        List<string> result = new List<string>();

        int i = 0;
        while (true)
        {
            int openBracketPosition;
            int closeBracketPosition;
            string tag;

            openBracketPosition = notificationInput.IndexOf('[', i);
            if (openBracketPosition == -1) {
                break;
            }
            closeBracketPosition = notificationInput.IndexOf(']', openBracketPosition);
            if (closeBracketPosition == -1) {
                break;
            }
            tag = notificationInput.Substring(openBracketPosition + 1, closeBracketPosition - openBracketPosition - 1);
            if (allChannels.Contains(tag))
            {
                result.Add(tag);
            }
            i = closeBracketPosition + 1;
        }
        return result.Distinct().ToList();
    }
}