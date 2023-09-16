using System;

// Клас Address
class Address
{
    public string Index { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string Apartment { get; set; }
}

// Клас Converter
class Converter
{
    public double USD { get; private set; }
    public double EUR { get; private set; }
    public double PLN { get; private set; }

    public Converter(double usd, double eur, double pln)
    {
        USD = usd;
        EUR = eur;
        PLN = pln;
    }

    public double UahToUsd(double amount)
    {
        return amount / USD;
    }

    public double UahToEur(double amount)
    {
        return amount / EUR;
    }

    public double UahToPln(double amount)
    {
        return amount / PLN;
    }

    public double UsdToUah(double amount)
    {
        return amount * USD;
    }

    public double EurToUah(double amount)
    {
        return amount * EUR;
    }

    public double PlnToUah(double amount)
    {
        return amount * PLN;
    }
}

// Клас Employee
class Employee
{
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Employee(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }

    public (double Salary, double Tax) CalculateSalary(string position, int experience)
    {
        double salary = 0;
        double tax = 0;
        if (position == "Менеджер")
        {
            salary = 30000 + experience * 1000;
            tax = 0.15 * salary;
        }
        else if (position == "Програміст")
        {
            salary = 40000 + experience * 1500;
            tax = 0.20 * salary;
        }
        return (salary, tax);
    }
}

// Клас User
class User
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime RegistrationDate { get; }

    public User(string login, string firstName, string lastName, int age)
    {
        Login = login;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        RegistrationDate = DateTime.Now;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Логін: " + Login);
        Console.WriteLine("Ім'я: " + FirstName);
        Console.WriteLine("Прізвище: " + LastName);
        Console.WriteLine("Вік: " + Age);
        Console.WriteLine("Дата заповнення анкети: " + RegistrationDate.ToString("dd.MM.yyyy HH:mm:ss"));
    }
}

class Program
{
    static void Main()
    {
        // Використання класів Address, Converter, Employee і User

        // Клас Address
        Address address = new Address
        {
            Index = "02092",
            Country = "Україна",
            City = "Київ",
            Street = "Вулиця Алматинська",
            House = "15А",
            Apartment = "8"
        };

        Console.WriteLine("Поштова адреса:");
        Console.WriteLine("Індекс: " + address.Index);
        Console.WriteLine("Країна: " + address.Country);
        Console.WriteLine("Місто: " + address.City);
        Console.WriteLine("Вулиця: " + address.Street);
        Console.WriteLine("Будинок: " + address.House);
        Console.WriteLine("Квартира: " + address.Apartment);

        // Клас Converter
        Converter converter = new Converter(36.6, 39.3, 8.4);
        double amountUah = 1000;
        Console.WriteLine("\nКонвертація з UAH:");
        Console.WriteLine($"{amountUah} UAH = {converter.UahToUsd(amountUah):F2} USD");
        Console.WriteLine($"{amountUah} UAH = {converter.UahToEur(amountUah):F2} EUR");
        Console.WriteLine($"{amountUah} UAH = {converter.UahToPln(amountUah):F2} PLN");

        double amountUsd = 50;
        Console.WriteLine("\nКонвертація в UAH:");
        Console.WriteLine($"{amountUsd} USD = {converter.UsdToUah(amountUsd):F2} UAH");
        double amountEur = 40;
        Console.WriteLine($"{amountEur} EUR = {converter.EurToUah(amountEur):F2} UAH");
        double amountPln = 70;
        Console.WriteLine($"{amountPln} PLN = {converter.PlnToUah(amountPln):F2} UAH");

        // Клас Employee
        Employee employee = new Employee("Донець", "Борис");
        string position = "Менеджер";
        int experience = 3;
        var (salary, tax) = employee.CalculateSalary(position, experience);
        Console.WriteLine("\nІнформація про співробітника:");
        Console.WriteLine("Прізвище: " + employee.LastName);
        Console.WriteLine("Ім'я: " + employee.FirstName);
        Console.WriteLine("Посада: " + position);
        Console.WriteLine("Оклад: " + salary.ToString("F2") + " UAH");
        Console.WriteLine("Податковий збір: " + tax.ToString("F2") + " UAH");

        // Клас User
        User user = new User("user123", "Борис", "Донець", 30);
        Console.WriteLine("\nІнформація про користувача:");
        user.DisplayInfo();
    }
}