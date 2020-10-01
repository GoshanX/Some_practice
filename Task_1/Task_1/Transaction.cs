using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Describe operation
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Тип счета
        /// </summary>
        public string AccountType { get; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber { get; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string Currency { get; }
        /// <summary>
        /// Дата операции
        /// </summary>
        public DateTime DateTransaction { get; }
        /// <summary>
        /// Референс проводки
        /// </summary>
        public string ReferenceWiring { get; }
        /// <summary>
        /// Описание операции
        /// </summary>
        public string OperationDescription { get; }
        /// <summary>
        /// Приход
        /// </summary>
        public double Income { get; }
        /// <summary>
        /// Расход
        /// </summary>
        public double Expense { get; }
        public Transaction(List<string> transactionDescription)
        {
            AccountType = transactionDescription[0];
            AccountNumber = transactionDescription[1];
            Currency = transactionDescription[2];
            DateTransaction = Convert.ToDateTime(transactionDescription[3]);
            ReferenceWiring = transactionDescription[4];
            OperationDescription = transactionDescription[5];
            Income = Convert.ToDouble(transactionDescription[6]);
            Expense = Convert.ToDouble(transactionDescription[7]);
        }
       
        /// <summary>
        /// defining the organization where possible
        /// </summary>
        /// <returns>organization name</returns>
        public string GetOrganizationForAnalyzeExpense()
        {
            string result = "";

            var startIndex = OperationDescription.IndexOf('\\');
            var endIndex = OperationDescription.IndexOf('.');
            result = OperationDescription.Substring(startIndex + 1, endIndex - startIndex - 3).Replace(" ", "").Replace("\\", " ");
            return result;
        }
    }
}
