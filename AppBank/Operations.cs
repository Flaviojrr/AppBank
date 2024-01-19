using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBank {
    internal class Operations {
        List<User> users;
        User userName;
       public void newAccount() {
            bool confirm;
            Console.WriteLine("//////////Central bank///////////" + "\nNew Account!" + "\n(1) Fist name:");
            string newFistName = Console.ReadLine();
            Console.WriteLine("(2) Last name");
            string newLastName = Console.ReadLine();
            Console.WriteLine("(3) CPF");
            int newCpf = int.Parse(Console.ReadLine());
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
            } while (confirm!=true);
            User newUser = new User(newFistName, newLastName, newCpf, newPhoneNumber, newPassword);
            users.Add(newUser);
            Console.WriteLine("New account created successfully!!!");
        }
        private bool passwordConfirmation(int newPassword, int newPassword2) {
            return newPassword == newPassword2;
        }
        private bool cpfVerification(int newCpf) {
            User userTeste = users.Find(User => User.Cpf == newCpf);
            if(userTeste != null) { return true; }
            return false;
        }
        public bool login(int numberAccount, int password) {
            User userNumberAccount = users.Find(User => User.NumberAccount == numberAccount);
            User userPassword = users.Find(User => User.Password == password);
            if(userNumberAccount != null) {
                if(userPassword != null) { return true; }
                return false;
            }
            return false;
        }
    }
}
