using System;
using System.Collections.Generic;
using System.Text;

/**
 * Optimizing memory by identifying similar objects. [First name, last name]
*/


namespace FlyweightPattern
{
    // Optimizing memory during text editing.
    public class FormattedText
    {
        private string PlainText { get; }
        private bool[] capatalize; // we are specifying ever letter formation. which is bad.

        public FormattedText(string plainText)
        {
            PlainText = plainText;
            capatalize = new bool[plainText.Length];
        }

        public void Capatalize(int start, int end)
        {
            for (int i = start; i < end; i++)
                capatalize[i] = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < PlainText.Length; i++)
            {
                char c = PlainText[i];
                sb.Append(capatalize[i] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }

    public class BetterFormattedText
    {
        private string Plaintext { get; }
        private List<TextRange> Formating = new List<TextRange>();

        public BetterFormattedText(string Plaintext)
        {
            this.Plaintext = Plaintext;
        }

        public TextRange AddRange(int Start, int End)
        {
            TextRange range = new TextRange() { Start = Start, End = End };
            Formating.Add(range);
            return range;
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capatalize, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Plaintext.Length; i++)
            {
                char c = Plaintext[i];
                string fc = c + "";
                foreach (var range in Formating)
                {
                    if (range.Covers(i))
                    {
                        if (range.Capatalize) fc = char.ToUpper(c) + "";
                        else if (range.Bold) fc = sb.Bold(c);
                        else if (range.Italic) fc = sb.Italic(c);
                    }
                }
                sb.Append(fc);
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capatalize(10, 15);
            Console.WriteLine(ft);

            var Bft = new BetterFormattedText("This is a brave new world");
            Bft.AddRange(0, 3).Capatalize = true;
            Bft.AddRange(10, 14).Bold = true;
            Bft.AddRange(16, 18).Italic = true;
            Console.WriteLine(Bft);
        }
    }

    public static class ExtersionBuilder
    {
        public static string Bold(this StringBuilder sb, char c) 
        {
            return $"*{c}*";
        }

        public static string Italic(this StringBuilder sb, char c)
        {
            return $"_{c}";
        }
    }
}
