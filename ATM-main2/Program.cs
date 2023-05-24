using system;

class Program

{
    static void Main()
    {
        var atm = new Atm();
        while (true)
        {
            int option;

            MenuMethod();

            var input = int.TryParse(Console.ReadLine(), out option);

            Console.WriteLine("-----------------");

            switch (option)
            {
                case 1:
                    atm.CreateAccount();
                    break;
                case 2:
                    atm.Deposit();
                    break;
                case 3:
                    MenuMethod();
                    break;

            }
        }
    }

    private static void MenuMethod()
    {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Skapa Konto");
            Console.WriteLine("2. Deposit");
            Console.WriteLine();
            Console.Write("Var snäll ock gör ett val: ");
    }
}

internal class Atm

{
    public List<Account> Accounts { get; set; }

    public Atm()
    {
        Accounts = new List<Account>();
    }

    public void CreateAccount()
    {
        var account = new Account();

        Console.WriteLine("Skapar ett nytt konto!!!");
        Console.WriteLine();
        Console.Write("Skriv ditt förstanamn: ");
        account.FirstName = Console.ReadLine();
        Console.Write("Skriv ditt efternamn: ");
        account.LastName = Console.ReadLine();
        Console.Write("Skriv Födelsedatum: ");
        account.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Skriv ditt telefonummer: ");
        account.PhoneNumber = Console.ReadLine();

        account.Balance = 0.0;
        account.Id = Accounts.Count + 1;

        Accounts.Add(account);
    }

    public void Deposit()
    {
        int accountId;

        Console.Write("Skriv kontonummer: ");
        int.TryParse(Console.ReadLine(), out accountId);

        var account = Accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            double amount;
            Console.Write("Skriv mängd du vill insätta: ");
            double.TryParse(Console.ReadLine(), out amount);
            account.Balance += amount;
            Console.Write("Ditt kontos balance är: {0}", account.Balance);
        }
        else
        {
            Console.WriteLine("Detta konto fungerar inte eller är avstängt!");
        }
    }
}
