using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_1
{
    /// <summary>
    /// Сlass allows you to read csv format files.
    /// </summary>
    public class CsvTransactionsReader
    {
        /// <summary>
        /// type of delimiter
        /// </summary>
        public enum Delimiter
        {
            Comma,
            Tab
        }

        static readonly Dictionary<Delimiter, char> Delimiters = new Dictionary<Delimiter, char>() { { Delimiter.Comma, ',' }, { Delimiter.Tab, '\t' } };
        static Transaction transaction;
       
        /// <summary>
        /// Read CSV data from path.
        /// </summary>
        /// <param name="path">CSV file path.</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <param name="encoding">Type of text encoding. (default UTF-8)</param>
        /// <returns>Nested list that CSV parsed.</returns>
        public static List<Transaction> ReadFromPath(string path, Delimiter delimiter = Delimiter.Comma, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var data = File.ReadAllText(path, encoding);
            return Parse(data, delimiter);
        }

        /// <summary>
        /// Parse csv file and fill list of transactions
        /// </summary>
        /// <param name="data">data from file</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <returns>List of transactions</returns>
        static List<Transaction> Parse(string data, Delimiter delimiter)
        {

            var result = new List<Transaction>();
            var row = new List<string>();
            var cell = new StringBuilder();
            var insideQuoteCell = false;
            var header = true;
            var delimiterChar = Delimiters[delimiter];

            //end of line unification
            ConvertToLf(ref data);

            foreach (var character in data)
            {
                //Inside the quotation marks.
                if (insideQuoteCell)
                {
                    if (character == '"')
                    {
                        insideQuoteCell = false;
                    }
                    else
                    {
                        cell.Append(character);
                    }
                }
                else
                {
                    // Outside the quotation marks.
                    if (character == delimiterChar)
                    {
                        AddCell(row, cell);
                    }
                    else if (character == '\n')
                    {
                        AddCell(row, cell);
                        if (!header)
                        {
                            AddRow(result, ref row);
                        }
                        else
                        {
                            row = new List<string>();
                            header = false;
                        }
                    }
                    else if (character == '"')
                    {
                        insideQuoteCell = true;
                    }
                    else
                    {
                        cell.Append(character);
                    }
                }
            }

            // Add last line except blank line
            if (row.Count != 0 || cell.Length != 0)
            {
                AddCell(row, cell);
                AddRow(result, ref row);
            }

            return result;
        }

        static void AddCell(List<string> row, StringBuilder cell)
        {
            row.Add(cell.ToString());
            cell.Clear();
        }

        static void AddRow(List<Transaction> result, ref List<string> row)
        {
            //Create new transaction
            transaction = new Transaction(row);
            result.Add(transaction);
            row = new List<string>();
        }

        static void ConvertToLf(ref string data)
        {
            data = Regex.Replace(data, @"\r\n|\r|\n", "\n");
        }
    }
}
