using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.Net.WebRequestMethods.File;

namespace Wordle.Model
{
    static public class Library
    {
        static readonly List<string> possibleWords = DownloadList().GetAwaiter().GetResult().
            Split(new string[] { "\r\n", "\r", "\n" },StringSplitOptions.None).
            ToList();

        static async Task<string> DownloadList()
        {
            HttpClient client = new();
            string path = @"https://raw.githubusercontent.com/tabatkins/wordle-list/main/words";
            Stream stream = await client.GetStreamAsync(path);
            StreamReader reader = new(stream);

            return reader.ReadToEnd();
        }

        static public string Get()
        {
           int index = Utilities.random.Next(possibleWords.Count);
           return possibleWords[index];
        }

        static public bool Contains(string input)
        {
            return possibleWords.Contains(input);
        }

    }
}
