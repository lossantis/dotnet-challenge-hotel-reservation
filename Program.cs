using hotel.Models;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        try
        {
            List<Suite> availableSuites = LoadSuites("Files/suites.json");

            if (availableSuites == null || availableSuites.Count == 0)
            {
                Console.WriteLine("No suites available.");
                return;
            }

            string? input;
            do
            {
                Console.Clear();
                var suiteMenuOptions = BuildSuiteMenuOptions(availableSuites);
                DisplayMenu(suiteMenuOptions);

                input = Console.ReadLine();

                if (input == "99") break;

                if (int.TryParse(input, out int selectedOption) && suiteMenuOptions.ContainsKey(selectedOption))
                {
                    var selectedSuite = availableSuites[selectedOption - 1];
                    HandleReservation(selectedSuite);
                }
                else
                {
                    Console.WriteLine("\nInvalid selection. Please try again.");
                    Pause();
                }

            } while (input != "99");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
            Pause();
        }
    }

    static List<Suite> LoadSuites(string path)
    {
        string suitesJson = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<List<Suite>>(suitesJson) ?? new List<Suite>();
    }

    static Dictionary<int, string> BuildSuiteMenuOptions(List<Suite> suites)
    {
        Dictionary<int, string> menu = new();

        int menuOption = 0;

        foreach (Suite suite in suites)
        {
            menu.Add(++menuOption, suite.SuiteType ?? "Unknown Suite");
        }

        return menu;
    }

    static void DisplayMenu(Dictionary<int, string> suiteMenuOptions)
    {
        Console.WriteLine("\nSelect a suite by number:");

        foreach (var option in suiteMenuOptions)
        {
            Console.WriteLine($"{option.Key} - {option.Value}");
        }

        Console.WriteLine("99 - Exit");
    }

    static void HandleReservation(Suite suite)
    {
        Console.Clear();
        Console.WriteLine($"Suite: {suite.SuiteType}");
        Console.WriteLine($"Capacity: {suite.Capacity} guests");
        Console.WriteLine($"Price: {suite.PricePerNight:C} per night");

        Console.Write($"\nEnter total guests (max {suite.Capacity}): ");

        int guestsInput;

        while (!int.TryParse(Console.ReadLine(), out guestsInput) || guestsInput <= 0 || guestsInput > suite.Capacity)
        {
            Console.Write($"Invalid input. Enter total guests (max {suite.Capacity}): ");
        }

        Console.Write("Enter number of nights to book: ");

        int bookedNights;

        while (!int.TryParse(Console.ReadLine(), out bookedNights) || bookedNights <= 0)
        {
            Console.Write("Invalid input. Enter number of nights to book: ");
        }

        Reservation reservation = new Reservation(bookedNights);
        reservation.AddSuite(suite);

        for (int i = 0; i < guestsInput; i++)
        {
            Console.Write($"Enter first name of guest {i + 1}: ");
            string? firstName = Console.ReadLine();

            Console.Write($"Enter last name of guest {i + 1}: ");
            string? lastName = Console.ReadLine();

            reservation.AddGuest(new Person(firstName ?? string.Empty, lastName ?? string.Empty));
        }

        Console.WriteLine($"\nGuest count: {reservation.GetGuestCount()}");

        Console.WriteLine("Guests:");
        IEnumerable<Person> guests = reservation.Guests;
        foreach (Person guest in guests)
        {
            Console.WriteLine($"- {guest.FirstName} {guest.LastName}");
        }

        Console.WriteLine($"Total rate for {bookedNights} nights: {reservation.CalculateDailyRate():C}");

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}