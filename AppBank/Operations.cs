using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AppBank {
    internal class Operations {
        List<User> users = new List<User>();
        int newCpf;
        public void newAccount() {
            bool confirm;

            Console.WriteLine("//////////Central bank/////////// \nNew Account! \n(1) Fist name:");
            string newFistName = Console.ReadLine();
            Console.WriteLine("(2) Last name");
            string newLastName = Console.ReadLine();
            do {
                Console.WriteLine("(3) CPF");
                newCpf = int.Parse(Console.ReadLine());
            } while (cpfVerification(newCpf) == true);
            Console.WriteLine("(4) Phone number");
            int newPhoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("(5) Password");
            int newPassword = int.Parse(Console.ReadLine());
            do {
                Console.WriteLine("Confirm password:");
                int newPassword2 = int.Parse(Console.ReadLine());
                confirm = passwordConfirmation(newPassword, newPassword2);
                if (confirm != true) {
                    Console.WriteLine("Different passwords!!!");
                }
            } while (confirm != true);
            User newUser = new User(newFistName, newLastName, newCpf, newPhoneNumber, newPassword);
            users.Add(newUser);
            Console.WriteLine(newUser.ToString());
            Console.WriteLine("New account created successfully!!!");
        }
        private bool passwordConfirmation(int newPassword, int newPassword2) {
            return newPassword == newPassword2;
        }
        private bool cpfVerification(int newCpf) {
            User userTeste = users.Find(User => User.Cpf == newCpf);
            if (userTeste != null) { Console.WriteLine("Existing CPF"); return true; }
            return false;
        }
        public User Login(int numberAccount, int password) {
            User user = users.Find(u => u.NumberAccount == numberAccount && u.Password == password);
            if (user != null) {
                Console.WriteLine(user.FistName);
                LoginOperationsAccepted(user);
                return user;
            }
            Console.WriteLine("User not found or password incorrect.");
            return null;
        }
        private string CheckBalance(User user) {
            return "Balance: R$ " + user.Balance.ToString("F2");
        }
        private void BankTransfer(User userAccountMadeTheDeposit, int UserAccountNumberForTransfer, float deposit) {
            User userForTransfer = users.Find(uft => uft.NumberAccount == UserAccountNumberForTransfer);
            if (userForTransfer != null) {
                Console.WriteLine(userAccountMadeTheDeposit.transfer(deposit));
                userForTransfer.deposit(deposit);
                Console.WriteLine(CheckBalance(userAccountMadeTheDeposit));
            }
            else {
                Console.WriteLine("Bank transfer not completed");
            }
        }
        private void Payments(User userAccountMadeThePayment, int paymentAmount) {
            if (userAccountMadeThePayment.payment(paymentAmount)) {
                Console.WriteLine("Payment completed successfully");
            }
            Console.WriteLine("Payment not completed");
        }
        private void LoginOperationsAccepted(User verifiedUser) {
            Console.WriteLine("////////// Central Bank ////////// \nWelcome " + verifiedUser.FistName + "!!!");
            int op;
            do {
                Console.WriteLine("(1)Check balance \n(2)Bank transfer \n(3)Payments \n(4)Info \n(5)Exit");
                op = int.Parse(Console.ReadLine());
                switch (op) {
                    case 1:
                        Console.WriteLine(CheckBalance(verifiedUser));
                        break;
                    case 2:
                        Console.WriteLine("Account for deposit:");
                        int accountDeposit = int.Parse(Console.ReadLine());
                        Console.WriteLine("Deposit amount:");
                        float depositAmount = float.Parse(Console.ReadLine());
                        BankTransfer(verifiedUser, accountDeposit, depositAmount);
                        break;
                    case 3:
                        Console.WriteLine("Invoice number for payment: ");
                        int invoiceNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Amount for invoice:");
                        float amountInvoice = float.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine(verifiedUser.ToString());
                        break;
                }
            } while (op != 5);
        }

    }
}
