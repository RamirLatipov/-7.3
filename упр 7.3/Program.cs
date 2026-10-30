using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упр_7._3
{
  
       
        public enum BankAccountType
        {
            Current,   // текущий
            Savings    // сберегательный
        }

        public class BankAccount
        {
            private static long _nextAccountNumber = 1_000_000L;

            private readonly long _accountNumber;
            private double _balance;
            private BankAccountType _type;

            public BankAccount(BankAccountType type, double initialBalance)
            {
                _accountNumber = _nextAccountNumber++;
                Type = type;
                Balance = initialBalance;
            }

            public long AccountNumber => _accountNumber;

            public double Balance
            {
                get => _balance;
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Баланс не может быть отрицательным");
                    _balance = value;
                }
            }

            public BankAccountType Type
            {
                get => _type;
                set => _type = value;
            }

            // Положить на счет
            public void Deposit(double amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма пополнения должна быть больше 0");
                _balance += amount;
            }

            // Снять со счета: проверяем возможность, при успехе меняем баланс
            public bool Withdraw(double amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Сумма снятия должна быть больше 0");

                if (_balance < amount)
                    return false; // недостаточно средств — баланс не меняется

                _balance -= amount;
                return true;
            }

            public override string ToString()
            {
                return $"BankAccount{{accountNumber={_accountNumber}, balance={_balance}, type={_type}}}";
            }
        }

        class Program
        {
            static void Main()
            {
                BankAccount account = new BankAccount(BankAccountType.Savings, 1000.0);
                Console.WriteLine("До операций: " + account);

                // Положить на счет
                account.Deposit(500.0);
                Console.WriteLine("После Deposit(500): " + account);

                // Снять сумму в пределах баланса
                bool ok1 = account.Withdraw(300.0);
                Console.WriteLine($"Withdraw(300) -> {ok1}, баланс: {account.Balance}");

                // Попытка снять больше баланса
                bool ok2 = account.Withdraw(5000.0);
                Console.WriteLine($"Withdraw(5000) -> {ok2}, баланс: {account.Balance}");
            }
        }










    
    
}
