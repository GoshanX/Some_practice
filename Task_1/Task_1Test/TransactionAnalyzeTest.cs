using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task_1Test
{
    [TestClass]
    public class TransactionAnalyzeTest
    {
        static List<string> trans1 = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "31.05.17", "CRD_5XK5TM", "548673++++++1028    21708201\\RUS\\MOSCOW\\Ryabin\\KUSCHAVEL              31.05.17 29.05.17       300.00  RUR(Apple Pay - 7666) MCC5814", "0", "300" };
        static List<string> trans2 = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "28.05.17", "CRD_7HN8BF", "548673++++++1028    809216  /RU/CARD2CARD ALFA_MOBILE>MOSCOW          28.05.17 28.05.17 5000.00       RUR MCC6536", "5000", "0" };
        static List<string> trans3 = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "31.05.17", "CRD_1U34U7", "548673++++++1028    809216 / RU / CARD2CARD ALFA_MOBILE > MOSCOW          31.05.17 31.05.17 1500.00       RUR MCC6536", "1500", "0" };
        static List<string> trans4 = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "20.05.17", "CRD_24Y3Y4", "548673++++++1028      210102\\643\\MOSKVA\\Alfa Iss                      20.05.17 19.05.17     33000.00  RUR MCC6011", "0", "33000" };
        static List<string> trans5 = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "20.05.17", "CRD_24Y3Y4", "548673++++++1028      210102\\643\\MOSKVA\\Alfa Iss                      20.05.17 19.05.17     33000.00  RUR MCC6011", "0", "33000" };
        List<Task_1.Transaction> transactions = new List<Task_1.Transaction>() { new Task_1.Transaction(trans1), new Task_1.Transaction(trans2), new Task_1.Transaction(trans3), new Task_1.Transaction(trans4), new Task_1.Transaction(trans5) };

        [TestMethod]
        public void GetSumIncomeTest()
        {
            //arrange
            Task_1.TransactionsAnalyze trA = new Task_1.TransactionsAnalyze(transactions);

            //action
            var sumIncome = trA.getSumIncome();

            //assert
            Assert.AreEqual(sumIncome, 6500);

        }
        [TestMethod]
        public void GetSumExpenseTest()
        {
            //arrange
            Task_1.TransactionsAnalyze trA = new Task_1.TransactionsAnalyze(transactions);

            //action
            var sumExpense = trA.getSumExpense();

            //assert
            Assert.AreEqual(sumExpense, 66300);

        }
        [TestMethod]
        public void GetDifferentOrganizationsTest()
        {
            //arrange
            Task_1.TransactionsAnalyze trA = new Task_1.TransactionsAnalyze(transactions);

            //action
            var orgs = trA.GetDifferentOrganizations();

            //assert
            Assert.AreEqual(orgs.SequenceEqual(new List<string>() { "RUS MOSCOW Ryabin KUSCHAVEL", "548673++++++1028809216/RU/CARD2CARDALFA_MOBILE>MOSCOW", "643 MOSKVA AlfaIss" }), true);

        }

    }
}
