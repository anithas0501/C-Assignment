using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Account1
    {
        public int AccountNo { get; set; }
        public string AccountName { get; set; }
        public int Balance { get; protected set; } = 5000;
    }

    class SBAccount : Account1
    {
        public void Credit(int amount) => Balance += amount;

        public void Debit(int amount) => Balance -= amount;

    }

    class RDAccount : Account1
    {
        int amount = 5000;
        public void MakePayment()
        {
            Console.WriteLine($"Payment of Rs. {amount} is done");
            Balance += amount;
        }
    }

    class BaseClass
    {
        public void BaseFunc() => Console.WriteLine("Base func");
    }

    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func");
    }



    class Ex09_Inheritence
    {
        static void Main(string[] args)
        {
            BaseClass cls = new BaseClass();
            cls.BaseFunc();

            DerivedClass cls2 = new DerivedClass();
            cls2.DerivedFunc();
            cls2.BaseFunc();

            SBAccount acc = new SBAccount { AccountName = "testName", AccountNo = 123 };
            acc.Credit(45000);
            acc.Debit(5000);
            Console.WriteLine("The Balance : " + acc.Balance);
        }

    }
}
