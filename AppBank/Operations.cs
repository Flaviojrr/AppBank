using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBank {
    internal class Operations {
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
                confirm = confirmPassword(newPassword, newPassword2);
                if (confirm != true) {
                    Console.WriteLine("Different passwords!!!");
                }
            } while (confirm!=true);
            User newUser = new User(newFistName, newLastName, newCpf, newPhoneNumber, newPassword);
            Console.WriteLine("New account created successfully!!!");
        }
        private bool confirmPassword(int newPassword, int newPassword2) {
            return newPassword == newPassword2;
        }
    }
}
