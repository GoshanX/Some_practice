using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Program
    {
        public static void Main()
        {
            var data = CsvTransactionsReader.ReadFromPath("movementList.csv");
            TransactionsAnalyze transAnalyze = new TransactionsAnalyze(data);
            transAnalyze.VisualizationDetaling();
        }
    }
}
