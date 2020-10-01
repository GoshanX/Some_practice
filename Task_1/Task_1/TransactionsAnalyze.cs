using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class TransactionsAnalyze
    {
        List<Transaction> transactions;
        public TransactionsAnalyze(List<Transaction> movementData)
        {
            this.transactions = movementData;
        }
        /// <summary>
        /// Calculate the amount of income
        /// </summary>
        /// <returns>income sum</returns>
        public double getSumIncome()
        {
            double sumIncome = 0;
            foreach (var tr in transactions)
            {
                sumIncome += tr.Income;
            }
            return sumIncome;
        }
        /// <summary>
        /// Calculate the amount of expense
        /// </summary>
        /// <returns>expense sum</returns>
        public double getSumExpense()
        {
            double sumExpense = 0;
            foreach (var tr in transactions)
            {
                sumExpense += tr.Expense;
            }
            return sumExpense;
        }
        /// <summary>
        /// creation of summary data on expenses of organizations
        /// </summary>
        /// <returns>a dictionary in which the key is an organization, value - expenes</returns>
        public Dictionary<string, double> DetailingOfExpenses()
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            var organizations = GetDifferentOrganizations();

            foreach (var org in organizations)
            {
                double sumExpenses = 0;
                if (!org.Equals(""))
                {
                    foreach (var tr in transactions)
                    {
                        if (tr.GetOrganizationForAnalyzeExpense().Equals(org))
                        {
                            if (tr.ReferenceWiring.Contains("CRD"))
                            {
                                sumExpenses += tr.Expense;
                            }
                        }
                    }
                    if (sumExpenses > 0)
                        result.Add(org, sumExpenses);
                }
            }
            return result;
        }
        /// <summary>
        /// makes a list of non-repeating organizations
        /// </summary>
        /// <returns>list of different organizations</returns>
        public List<string> GetDifferentOrganizations()
        {
            List<string> organizations = new List<string>();

            foreach (var tr in transactions)
            {
                organizations.Add(tr.GetOrganizationForAnalyzeExpense());
            }

            return organizations.Distinct().ToList();
        }
        /// <summary>
        /// Transaction summary
        /// </summary>
        public void VisualizationDetaling()
        {
            Console.WriteLine($"Сумма расходов: {getSumIncome()}");
            Console.WriteLine($"Сумма доходов: {getSumExpense()}");
            Console.WriteLine("Сумма расходов по организациям:");
            var maxWidth = DetailingOfExpenses().Keys.Max(s => s.Length);
            var formatString = string.Format("{{0, -{0}}}", maxWidth);
            foreach (var d in DetailingOfExpenses())
            {
                Console.Write(formatString, d.Key);
                Console.WriteLine($" - {d.Value}");
            }

        }
    }
}

