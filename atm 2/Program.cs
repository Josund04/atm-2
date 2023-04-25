// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        var atm = new Atm();
        while (true)
        {
            int option;

            Console.WriteLine();
            Console.WriteLine("Meny:");
            Console.WriteLine("1. Skapa konto");
            Console.WriteLine("2. Insättning");
            Console.WriteLine();
            Console.Write("Var vänlig välj ett alternativ ");

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
            }
        }
    }
}

class Account
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public double Balance { get; set; }
}

class Atm
{
    public List<Account> Accounts { get; set; }

    public Atm()
    {
        Accounts = new List<Account>();
    }

    public void CreateAccount()
    {
        var account = new Account();

        Console.WriteLine("Skapa ett konto!");
        Console.WriteLine();
        Console.Write("Skriv första namn ");
        account.FirstName = Console.ReadLine();
        Console.Write("Skriv efternamn: ");
        account.LastName = Console.ReadLine();
        Console.Write("Skriv in födelsedag: ");
        account.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Skriv in telefonnummer: ");
        account.PhoneNumber = Console.ReadLine();

        account.Balance = 0.0;
        account.Id = Accounts.Count + 1;

        Accounts.Add(account);
    }

    public void Deposit()
    {
        int accountId;

        Console.Write("Enter your account number: ");
        int.TryParse(Console.ReadLine(), out accountId);


        var account = Accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            double amount;
            Console.Write("Enter amount to deposit: ");
            double.TryParse(Console.ReadLine(), out amount);
            account.Balance += amount;
            Console.Write("Your new balance is {0}", account.Balance);
        }
        else
        {
            Console.WriteLine("That account does not exist!");
        }
    }
}
