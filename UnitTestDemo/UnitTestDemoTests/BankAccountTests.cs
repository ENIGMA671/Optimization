using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void TestExceptionCase()
        {
            BankAccount bank = new BankAccount("Имя", 0);
            try
            {
                bank.Debit(2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "сумма <= 0 or сумма > баланс");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "баланс = 0");
                return;
            }
            Assert.Fail("Исключение не было выдано");
        }
        [TestMethod()]
        public void TestCreditCase()
        {
            BankAccount bank = new BankAccount("Имя", 2);
            bank.Credit(2);
            Assert.AreEqual(4, bank.Balance);
        }
        [TestMethod()]
        public void TestDebitCase()
        {
            BankAccount bank = new BankAccount("Имя", 2);
            bank.Debit(2);
            Assert.AreEqual(0, bank.Balance);
        }
        [TestMethod()]
        public void TestCreditDebitCase()
        {
            BankAccount bank = new BankAccount("Имя", 2);
            bank.Debit(2);
            bank.Credit(2);
            Assert.AreEqual(2, bank.Balance);
        }
    }
}