using System;

namespace ManagementCommons
{
    public class ListDisplayLayout
    {
        static readonly int tableWidth = 84;
        public static void PrintTableLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintTableRow(params string[] columns)
        {

            int width = (tableWidth - 6) / 4;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignContentCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignContentCentre(string data, int width)
        {
            data = data.Length > width ? data.Substring(0, width - 3) + "..." : data;

            if (string.IsNullOrEmpty(data))
            {
                return new string(' ', width);
            }
            else
            {
                return data.PadRight(width - (width - data.Length) / 2).PadLeft(width);
            }
        }
    }

}
