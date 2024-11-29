using System;
using System.Collections.Generic;
 
class BankSystem
 {
     static void Main(string[] args)
     {
         Bank bank = new Bank();
         while (true)
         {
             Console.WriteLine("1. Create Account");
             Console.WriteLine("2. Deposit");
             Console.WriteLine("3. Withdraw");
             Console.WriteLine("4. Check Balance");
             Console.WriteLine("5. Exit");
             Console.Write("Select an option: ");

             int choice = int.Parse(Console.ReadLine());

             switch (choice)
             {
                 case 1:
                     bank.CreateAccount();
                     break;
                 case 2:
                     bank.Deposit();
                     break;
                 case 3:
                     bank.Withdraw();
                     break;
                 case 4:
                     bank.CheckBalance();
                     break;
                 case 5:
                     Console.WriteLine("Thank you for using the Bank System. Goodbye!");
                     return;
                 default:
                     Console.WriteLine("Invalid option. Please try again.");
                     break;
             }
         }
     }
 }

 public class Bank
 {
     private Dictionary<int, Account> accounts = new Dictionary<int, Account>();
     private int nextAccountNumber = 1;

     public void CreateAccount()
     {
         Console.Write("Enter your name: ");
         string name = Console.ReadLine();

         Console.Write("Enter initial deposit amount: ");
         decimal initialDeposit = decimal.Parse(Console.ReadLine());

         if (initialDeposit < 0)
         {
             Console.WriteLine("Initial deposit cannot be negative!");
             return;
         }

         Account newAccount = new Account(nextAccountNumber, name, initialDeposit);
         accounts.Add(nextAccountNumber, newAccount);

         Console.WriteLine("Account created successfully! Your account number is " + nextAccountNumber);
         nextAccountNumber++;
     }

     public void Deposit()
     {
         Console.Write("Enter account number: ");
         int accountNumber = int.Parse(Console.ReadLine());

         if (!accounts.ContainsKey(accountNumber))
         {
             Console.WriteLine("Account not found!");
             return;
         }

         Console.Write("Enter deposit amount: ");
         decimal amount = decimal.Parse(Console.ReadLine());

         if (amount <= 0)
         {
             Console.WriteLine("Deposit amount must be greater than zero!");
             return;
         }

         accounts[accountNumber].Deposit(amount);
         Console.WriteLine("Deposit successful!");
     }

     public void Withdraw()
     {
         Console.Write("Enter account number: ");
         int accountNumber = int.Parse(Console.ReadLine());

         if (!accounts.ContainsKey(accountNumber))
         {
             Console.WriteLine("Account not found!");
             return;
         }

         Console.Write("Enter withdrawal amount: ");
         decimal amount = decimal.Parse(Console.ReadLine());

         if (amount <= 0)
         {
             Console.WriteLine("Withdrawal amount must be greater than zero!");
             return;
         }

         if (accounts[accountNumber].Withdraw(amount))
         {
             Console.WriteLine("Withdrawal successful!");
         }
         else
         {
             Console.WriteLine("Insufficient balance!");
         }
     }

     public void CheckBalance()
     {
         Console.Write("Enter account number: ");
         int accountNumber = int.Parse(Console.ReadLine());

         if (!accounts.ContainsKey(accountNumber))
         {
             Console.WriteLine("Account not found!");
             return;
         }

         Console.WriteLine("Account Balance: $" + accounts[accountNumber].Balance);
     }
 }

 public class Account
 {
     public int AccountNumber { get; private set; }
     public string AccountHolder { get; private set; }
     public decimal Balance { get; private set; }

     public Account(int accountNumber, string accountHolder, decimal initialDeposit)
     {
         AccountNumber = accountNumber;
         AccountHolder = accountHolder;
         Balance = initialDeposit;
     }

     public void Deposit(decimal amount)
     {
         Balance += amount;
     }

     public bool Withdraw(decimal amount)
     {
         if (amount > Balance)
         {
             return false;
         }
         Balance -= amount;
         return true;
     }
 }