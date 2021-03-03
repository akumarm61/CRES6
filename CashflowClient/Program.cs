using System;
using System.IO;
using CRES.Cashflow;

namespace CashflowClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CashflowEngine ce = new CashflowEngine();

            string json = File.ReadAllText(@"C:\temp\Deal.json");
            //ce.GenerateCashFlow(json);
            ce.GetEndingBalance();

            Console.WriteLine(ce.Status());
            Console.Read();
        
        }
    }
}
