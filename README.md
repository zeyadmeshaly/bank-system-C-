# Console Bank Account System (C#)

A console banking program written in C# . Users can register an account, log in with a 4-digit PIN, then deposit, withdraw or view their balance.

## Features
- **Register** an account (name, 4-digit PIN, starting balance)
- **Log in** with the PIN (must be between 1000 and 9999)
- **Deposit** money
- **Withdraw** money (refused if the balance is too low)
- **View balance**

## Run

Requires the [.NET SDK](https://dotnet.microsoft.com/download) (or Visual Studio).

**Visual Studio:** create a new *Console App* project, replace the contents of `Program.cs` with this file, then press F5.

**Command line:**
```
dotnet new console -n BankApp
# replace BankApp/Program.cs with this repo's Program.cs
cd BankApp
dotnet run
```

You may see compiler warnings about `null`; they are warnings, not errors.

## Menus

```
1.LOG IN
2.REGISTER
```
After a successful login:
```
3.Depsoit
4.Withdraw
5.View Balance
```

## How it works
- `Account` stores a name, PIN and balance, and keeps a static `List<Account>` of all registered accounts.
- `create()` shows the login/register menu. Logging in searches the list for a matching PIN and stores the match in the static `currentaccount`.
- `manage` (inherits from `Account`) handles one transaction for `currentaccount`.
- `Main` calls `create()` in an endless loop.


## Possible improvements
- Validate input with `int.TryParse` and reject negative amounts
- Check for duplicate PINs, or log in with name + PIN
- Add an exit option and stay logged in until logout
- Save accounts to a file
