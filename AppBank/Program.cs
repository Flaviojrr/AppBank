namespace AppBank {
    internal class Program {
        static Operations newOperation = new Operations();
        static void Main(string[] args) {
            run();
        }
        private static void run() {
            int op;
            do {
                Console.WriteLine("////////// Central Bank /////////// \n(1) Login \n(2) Create a new account \n(3) Exit");
                op = int.Parse(Console.ReadLine());
                switch (op) {
                    case 1:
                        Console.WriteLine("/////////// Login ////////// \n(1) Number Account:");
                        int loginNumberAccount = int.Parse(Console.ReadLine());
                        Console.WriteLine("(2) Password: ");
                        int loginPassword=int.Parse(Console.ReadLine());
                        newOperation.Login(loginNumberAccount, loginPassword);
                        break;
                    case 2:
                        newOperation.newAccount();
                        break;
                }
            } while(op!=3);
            
        }
    }
}
