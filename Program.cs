// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic; // Add this namespace for List<>
using System.Linq; // Add this namespace for FirstOrDefault()

public class cardHolder
{
    public String cardNum;
    public int pin;
    public String firstName;
    public String lastName;
    public double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Please enter the amount you would like to deposit: ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money, Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money you want to withdraw: ");
            double withdrawal = double.Parse(Console.ReadLine());

            // check if user has enough money
            if (withdrawal > currentUser.getBalance())
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                double newBalance = currentUser.getBalance() - withdrawal;
                currentUser.setBalance(newBalance);
                Console.WriteLine("You are good to go! Thank You :)");
            }
        }

        void Balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("12348798798", 1234, "John", "Doe", 1000));
        cardHolders.Add(new cardHolder("56781234879", 5678, "Ayush", "Singh", 2000));
        cardHolders.Add(new cardHolder("91016781234", 9101, "Arjun", "Kumar", 3000));
        cardHolders.Add(new cardHolder("11216781234", 1121, "Lolu", "Singh", 4000));
        cardHolders.Add(new cardHolder("31412167812", 3141, "Nisha", "Singh", 5000));

        // prompt user
        Console.WriteLine("Welcome to simpleATM");
        Console.WriteLine("Please enter your card number: ");
        String debitCardNum = "";
        cardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();

                // check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card Not recognized, Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card Not recognized, Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                // "WE ALREADY HAVE CURRENT USER"
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Pin, Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Invalid Pin, Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + " :)");

        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch
            {
                option = 0;
            }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                Balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, Please try again");
            }
        } while (option != 4);
        Console.WriteLine("Thank You! Have a nice day :)");
    }
}
