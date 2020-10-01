using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task_1Test
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void GetOrganizationForAnalyzeExpenseTest()
        {
            //arrange
            List<string> trans = new List<string>() { "Текущий счёт", "40817813206170024534", "RUR", "31.05.17", "CRD_5XK5TM", "548673++++++1028    21708201\\RUS\\MOSCOW\\Ryabin\\KUSCHAVEL              31.05.17 29.05.17       300.00  RUR(Apple Pay - 7666) MCC5814", "0", "300" };
            Task_1.Transaction transaction = new Task_1.Transaction(trans);
            //action
            var organization = transaction.GetOrganizationForAnalyzeExpense();
            //assert
            Assert.AreEqual(organization, "RUS MOSCOW Ryabin KUSCHAVEL");
        }
    }
}
