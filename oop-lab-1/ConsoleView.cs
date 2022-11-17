using System;
using System.Collections.Generic;

namespace oop_lab_1
{
    internal class ConsoleView
    {
        static readonly string INFO = "Commands: add, delete, find, print, clear, exit.";
        readonly int MAX_NUMBER_OF_ACCOUNTS;
        readonly List<Account> accounts;

        public ConsoleView()
        {
            accounts = new List<Account>(1);
            MAX_NUMBER_OF_ACCOUNTS = InitMaxNumberOfAccounts();
        }

        private int InitMaxNumberOfAccounts()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the maximum number of accounts: ");
                    string str = Console.ReadLine().Split(' ')[0];
                    int val = int.Parse(str);
                    if (val > 0)
                        return val;
                }
                catch
                {
                    continue;
                }
            }
        }

        public void Run()
        {
            
            Console.WriteLine(INFO);
            while (true)
            {
                string command = Console.ReadLine().Split(' ')[0];
                switch (command)
                {
                    case "add":
                        AccountAdd();
                        break;
                    case "delete":
                        AccountDelete();
                        break;
                    case "find":
                        AccountFind();
                        break;
                    case "print":
                        AccountPrint();
                        break;
                    case "clear":
                        accounts.Clear();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(INFO);
                        break;
                }
            }
        }

        private void AccountAdd()
        {
            if (accounts.Count >= MAX_NUMBER_OF_ACCOUNTS)
            {
                Console.WriteLine("Unable to create new account.");
                return;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Print new account info (login, pass, email, balance, role(user/admin/manager)): ");

                    string[] accInfo = Console.ReadLine().Split(' ');
                    string login = accInfo[0];
                    if (login.Equals("exit"))
                    {
                        return;
                    }
                    foreach (Account account in accounts)
                    {
                        if (account.Login.Equals(login)) throw new ArgumentException();
                    }

                    Password pass = new Password(accInfo[1]);
                    string email = accInfo[2];
                    long balance = long.Parse(accInfo[3]);
                    Role role = (Role)Enum.Parse(typeof(Role), accInfo[4], true);

                    accounts.Add(new Account(login, pass, email, balance, role));
                    Console.WriteLine("Account succesfully created.");
                    break;
                }
                catch
                {
                    Console.WriteLine("Information is incorrect, please try again.");
                }
            }
        }

        private void AccountDelete()
        {
            if (accounts.Count > 0)
            {
                Console.Write("Print login to delete: ");
                string loginToDelete = Console.ReadLine().Split(' ')[0];
                foreach (Account a in accounts)
                {
                    if (a.Login.Equals(loginToDelete))
                    {
                        accounts.Remove(a);
                        break;
                    }
                }
            }
        }

        private void AccountFind()
        {
            if (accounts.Count > 0)
            {
                Console.Write("Find by: login/email/balance/role: ");
                string[] cmds = Console.ReadLine().Split(' ');
                try
                {
                    switch (cmds[0])
                    {
                        case "login":
                            foreach (Account account in accounts)
                            {
                                if (cmds[1].Equals(account.Login))
                                {
                                    Console.WriteLine(account);
                                }
                            }
                            break;
                        case "email":
                            foreach (Account account in accounts)
                            {
                                if (cmds[1].Equals(account.Email))
                                {
                                    Console.WriteLine(account);
                                }
                            }
                            break;
                        case "balance":
                            foreach (Account account in accounts)
                            {
                                if (long.Parse(cmds[1]).Equals(account.Balance))
                                {
                                    Console.WriteLine(account);
                                }
                            }
                            break;
                        case "role":
                            Role role = (Role)Enum.Parse(typeof(Role), cmds[1], true);
                            foreach (Account account in accounts)
                            {
                                if (role.Equals(account.Role))
                                {
                                    Console.WriteLine(account);
                                }
                            }
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("Bad input. Example: role admin, login newlogin123");
                }
            }
        }

        private void AccountPrint()
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine($"{account}");
            }
        }
    }
}