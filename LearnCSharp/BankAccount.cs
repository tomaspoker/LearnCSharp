using System;
using System.Collections.Generic;

namespace LearnCSharp
{
    public class BankAccount
    {
        private static int s_AccountNumberSeed = 1234567890;

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in m_AllTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> m_AllTransactions = new List<Transaction>();

        public BankAccount(string name, decimal balance)
        {
            Number = (s_AccountNumberSeed++).ToString();
            Owner = name;

            MakeDeposit(balance, DateTime.Now, "Initial balance");
        }

        /// <summary>
        /// 存款：存款数值不能为负
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            m_AllTransactions.Add(deposit);
        }

        /// <summary>
        /// 取款：取款后余额不能小于0
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            m_AllTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach(var item in m_AllTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
