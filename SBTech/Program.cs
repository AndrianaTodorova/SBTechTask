using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SBTech
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {

                string s = client.DownloadString("https://www.math.utah.edu/~pa/math/e.html");
                int start = s.IndexOf("<EM>e</EM>");
                int end = s.IndexOf("...");
                int count = s.Substring(end).Length;
                int val = s.Length - (start + count + 15);
                var paragraph = s.Substring(start + 15, val).Replace(" ", "");
                Regex allDigits = new Regex("\\d+");
                Regex ascii = new Regex(@"((83)\d*?(66)\d*?(84)\d*?(101)\d*?(99)\d*?(104).*)");
                var matchNums = allDigits.Matches(paragraph);
                var sb = new StringBuilder();

                for (int i = 0; i < matchNums.Count; i++)
                {
                    sb.AppendLine(matchNums[i].ToString());
                }

                var numbers = sb.ToString();
                numbers = numbers.Replace("\r\n", "");

                var matchSbTech = ascii.Matches(numbers);
                var sb2 = new StringBuilder();
                foreach (Match m in matchSbTech)
                {
                    for (int i = 2; i <= 7; i++)
                    {
                        var sbTech = (char)int.Parse(m.Groups[i].Value);
                        sb2.Append(sbTech);
                    }
                }

                Console.WriteLine(sb2.ToString());
            }
        }
    }
}
