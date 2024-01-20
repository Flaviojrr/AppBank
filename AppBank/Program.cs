namespace AppBank {
    internal class Program {
        static Operations teste = new Operations();
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            run();
        }
        private static void run() {
            Console.WriteLine("////////// Central Bank ///////////"+"(1) Login"+"(2) Create a new account");
            int op = int.Parse(Console.ReadLine());
                switch (op) {
                    case 1:
                        teste.Login(1, 1);
                        break;
                    case 2:
                        teste.newAccount();
                        break;
                }
        }
    }
}
