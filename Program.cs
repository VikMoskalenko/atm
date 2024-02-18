using System;
using System.Collections.Specialized;

namespace atm
{
    internal class Program
    {
      
    }
    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        string phone;
        double balance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, string phone, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.balance = balance;
        }
        public string getNum()
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin; 
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(string newLastName)
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
                Console.WriteLine("Please choose from one of the following options: ");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Wirthdraw ");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit"); 
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit? ");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit);
                Console.WriteLine("Thank for your time. Your current balance is :" + currentUser.getBalance());
            }
            void wirthdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to wirthdraw? ");
                double withdraw = double.Parse(Console.ReadLine());
                currentUser.setBalance(withdraw);
                // check if user has enough money 
                if (currentUser.getBalance() > withdraw)
                {
                    Console.WriteLine("Balalance is low :( ");
                }
                else
                {
                    
                  // currentUser.setBalance((double)withdraw);
                  currentUser.setBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("You are good to go");
                }
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance: " + currentUser.getBalance());
            }
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4567673489005634", 1234, "Mike", "Robinson","0987654211", 150.2));
            cardHolders.Add(new cardHolder("4111673489003333", 1111, "Misha", "Rydenko", "0999999999", 1530.2));
            cardHolders.Add(new cardHolder("4112673489000000", 2222, "Mila", "Roshenko", "0222222222", 1350.2));


            //Promt
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("Please insert your card");
            string debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null)
                    {
                        break;
                            
                    } else { Console.WriteLine("Card is not recognized. Please try again later. ");  }
                }
                catch 
                {
                    Console.WriteLine("Card is not recognized. Please try again later. ");
                }
            }
            Console.WriteLine("Please enter your pin");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    
                    if (currentUser.getPin() == userPin)
                    {
                        break;

                    }
                    else { Console.WriteLine(" Incorrect pin "); }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin. Please try again later. ");
                }
            }
            Console.WriteLine("Welcome" + " " + currentUser.getFirstName() + ":)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                } catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { wirthdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            } while (option != 4);
            Console.WriteLine("Thank you");

        }

    }
}

