using System;
using System.Collections.Generic;

namespace bank
{
    class bank
    {
        static void Main(string[] args)
        {
            Account acc = new Account();

            while (true)
            {
                acc.create();
            }
        }
    }

    public class Account
    {
        public string name;
        public int pin;
        public int balance;

        static List<Account> accounts = new List<Account>();

        public static Account currentaccount = null;

        public void create()
        {
            Console.WriteLine("----------");
            Console.WriteLine("1.LOG IN");
            Console.WriteLine("2.REGISTER");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            { 

                Console.WriteLine("enter password ");

                int ypin = int.Parse(Console.ReadLine());

                while (ypin < 1000 || ypin > 9999)
                {
                    Console.WriteLine("invalid format ");

                    ypin = int.Parse(Console.ReadLine());
                }

                bool found = false;

                foreach (Account acc in accounts)
                {
                    if (ypin == acc.pin)
                    {
                        Console.WriteLine("account found log in successful ");

                        found = true;

                        currentaccount = acc;

                        manage man = new manage();
                        man.manager();

                        break;
                    }
                }

                if (found == false)
                {
                    Console.WriteLine("account not found log in unsuccessful ");
                }
            }

            else if (choice == 2)
            {
                Account newacc = new Account();

                Console.WriteLine("enter your name ");

                newacc.name = Console.ReadLine();

                Console.WriteLine("enter pin");

                newacc.pin = int.Parse(Console.ReadLine());

                while (newacc.pin < 1000 || newacc.pin > 9999)
                {
                    Console.WriteLine("invalid format ");

                    newacc.pin = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("enter balance ");

                newacc.balance = int.Parse(Console.ReadLine());

                accounts.Add(newacc);

                Console.WriteLine("account registered successfully ");
            }
        }
    }

    public class manage : Account
    {
        public void manager()
        {
            int amount;

            Console.WriteLine("----------");
            Console.WriteLine("3.Depsoit");
            Console.WriteLine("4.Withdraw");
            Console.WriteLine("5.View Balance ");

            int nchoice = int.Parse(Console.ReadLine());

            if (nchoice == 3)
            {
                Console.WriteLine("enter amount you want to deposit");

                amount = int.Parse(Console.ReadLine());

                currentaccount.balance = currentaccount.balance + amount;

                Console.WriteLine("deposit successful ");
            }

            else if (nchoice == 4)
            {
                Console.WriteLine("enter amount you want to withdraw");

                amount = int.Parse(Console.ReadLine());

                if (amount <= currentaccount.balance)
                {
                    currentaccount.balance = currentaccount.balance - amount;

                    Console.WriteLine("withdraw successful ");
                }
                else
                {
                    Console.WriteLine("insufficient balance ");
                }
            }

            else if (nchoice == 5)
            {
                Console.WriteLine(currentaccount.balance);
            }
        }
    }
}
