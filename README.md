# POO Challenge — Hotel Reservation (C# OOP Demo)

This console app demonstrates core **Object-Oriented Programming** (OOP) concepts in C# using a hotel reservation scenario. You'll see **abstraction**, **encapsulation**, **exception handling**, and basic **data modeling** in action.

---

## 🎯 Goals
- Model hotel domain entities: `Suite`, `Person`, and `Reservation`.
- Allow users to select suites, enter guest info, and book nights interactively.
- Validate user input and handle errors with custom exceptions.
- Practice object composition and collection management.

---

## 📁 Project Structure
```
hotel/
├── Program.cs
├── Models/
│   ├── Person.cs
│   ├── Reservation.cs
│   └── Suite.cs
├── Exceptions/
│   ├── BookedNightsLowerThanZeroException.cs
│   ├── ExceedSuiteCapacityException.cs
│   ├── GuestIsNullException.cs
│   └── SuiteCapacityLowerThanGuestsException.cs
│   └── SuiteIsNullException.cs
├── Files/
│   └── suites.json
├── hotel.csproj
└── ...
```

---

## 🧠 Key Concepts in This Codebase

### 1) Abstraction & Encapsulation
- `Suite`, `Person`, and `Reservation` classes encapsulate state and behavior relevant to hotel bookings.
- Properties are exposed via public getters, with validation logic in constructors and methods.

### 2) Exception Handling
- Custom exceptions in `Exceptions/` provide clear error messages for invalid operations:
  - Booking zero or negative nights
  - Adding more guests than suite capacity
  - Null guest or suite references

### 3) Composition & Collections
- A `Reservation` is composed of a `Suite` and a list of `Person` guests.
- The app collects guest info interactively and adds each to the reservation.

### 4) Data Loading & Serialization
- Suites are loaded from a JSON file (`Files/suites.json`) using `Newtonsoft.Json`.

---

## 🧩 Files Overview

### `Models/Suite.cs`
- Represents a hotel suite with `SuiteType`, `Capacity`, and `PricePerNight`.
- Immutable properties, deconstructor for tuple support.

### `Models/Person.cs`
- Represents a guest with `FirstName` and `LastName`.

### `Models/Reservation.cs`
- Manages booking logic:
  - Tracks booked nights, suite, and guests.
  - Methods to add suite and guests, calculate rates, and validate constraints.
  - Throws custom exceptions for invalid operations.

### `Exceptions/`
- Custom exception classes for domain-specific validation errors, e.g.:
  - `BookedNightsLowerThanZeroException`
  - `ExceedSuiteCapacityException`
  - `GuestIsNullException`
  - `SuiteCapacityLowerThanGuestsException`
  - `SuiteIsNullException`

### `Program.cs`
- Main entry point and user interface:
  - Loads suites from JSON.
  - Displays menu, handles user input, and manages the reservation workflow.
  - Collects guest info and booking details interactively.
  - Handles exceptions and prints user-friendly messages.

---

## ▶️ How to Run

**Requirements:** .NET SDK 9

From the project root:
```bash
dotnet build
dotnet run
```

---

## 🖥️ What `Program.cs` Does
1. Loads available suites from a JSON file.
2. Presents a menu for the user to select a suite.
3. Prompts for the number of guests and collects their names.
4. Prompts for the number of nights to book.
5. Creates a reservation, adds guests, and calculates the total rate.
6. Handles invalid input and domain errors gracefully.

---

## 🧪 Example Output (trimmed)
```
Select a suite by number:
1 - Deluxe Suite
2 - Family Suite
99 - Exit
> 1

Suite: Deluxe Suite
Capacity: 2 guests
Price: $150.00 per night

Enter total guests (max 2): 2
Enter first name of guest 1: Alice
Enter last name of guest 1: Smith
Enter first name of guest 2: Bob
Enter last name of guest 2: Jones
Enter number of nights to book: 3

Guest count: 2
Total rate for 3 nights: $450.00

Press any key to continue...
```

---

## 🧾 License
Use freely for learning and teaching. No warranty.