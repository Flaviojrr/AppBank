﻿using System;
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
        private float _balance;
        private int _numberAccount;
        Random rnd = new Random();
        public float Balance {
            get { return _balance; }
            private set { _balance += value; }
        }

        public User(string fistName, string lastName, int cpf, int phoneNumber, int password) {
            _fistName = fistName;
            _lastName = lastName;
            _cpf = cpf;
            _phoneNumber = phoneNumber;
            _password = password;
            _numberAccount = rnd.Next(10000);
        }

    }
}
