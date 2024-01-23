using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBank {
    internal class User {
        private string _fistName;
        private string _lastName;
        private int _cpf;
        private int _phoneNumber;
        private int _password;
        private float _balance=20F;
        private int _numberAccount;
        Random rnd = new Random();
        public float Balance {
            get { return _balance; }
            set { _balance = value; }
        }
        public int Cpf {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public int NumberAccount {
            get { return _numberAccount; }
        }
        public int Password {
            get { return _password; }
        }
        public string FistName {
            get { return _fistName; }
        }
        public User(string fistName, string lastName, int cpf, int phoneNumber, int password) {
            _fistName = fistName;
            _lastName = lastName;
            _cpf = cpf;
            _phoneNumber = phoneNumber;
            _password = password;
            _numberAccount = rnd.Next(10000);
        }
        public void deposit(float deposit) {
            Balance += deposit;
        }
        public string transfer(float transfer) {
            if(Balance<=0) return "Insufficient balance";
            Balance -=transfer;
            return "Bank transfer completed";
        }
        public bool payment(float amount) {
            if (Balance < amount) return false;
            Balance -= amount;
            return true;
        }
        public override string ToString() {
            return "Fist name: " + _fistName
                + "\nLast name: " + _lastName
                + "\nNumber account: " + +NumberAccount
                + "\nCPF: " + _cpf
                + "\nPhone number: " + _phoneNumber;
        }
    }
}
