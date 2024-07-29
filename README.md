# TwistedFizzBuzz
A C# library for executing a more comprehensive version of the FizzBuzz algorithm.

## Description
This library includes the following features:

1. Execution of the original FizzBuzz algorithm;
2. Execution of the FizzBuzz algorithm with a custom set of Tokens and Divisors, as well as any range of integers;
3. Execution of the FizzBuzz algorithm for a non-sequential list of integers;
4. retrieval of a custom set of Tokens and Divisors from an external API and using them to execute the FizzBuzz Algorithm.

## TokenMap
The TokenMap property is a dictionary of type <string, int> where tokens and their corresponding divisors are stored. This property can be updated using the UpdateTokenMap method. By default, it is configured for the original FizzBuzz algorithm:
{ "Fizz", 3 },
{ "Buzz", 5 };

## Available Methods
### Execute(int start, int end):
    Takes two integers as parameters and executes the FizzBuzz algorithm for all integers between them, inclusive. Returns a list of integers.
### Execute(List<int> inputList):
    Takes a list of integers as a parameter and executes the FizzBuzz algorithm. Returns a list of integers.
### UpdateTokenMap(Dictionary<string, int> tokenMap):
    Takes a dictionary of type <string, int>, updating the TokenMap parameter with its values. Null or empty dictionaries and the divisor 0 (zero) are not accepted. Does not return a value.
### GetTokenMap():
    Retrieves the content of the TokenMap variable, but read-only.
### UpdateTokenMapWithAPIGeneratedData():
    Retrieves a dictionary of type <string, int> from an external API (https://rich-red-cocoon-veil.cyclic.app/) and updates the TokenMap property with the result.

## Usage Example
```csharp
public static void Main()
{
    ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

    var result = fizzBuzz.Execute(1, 100);

    foreach(var res in result)
    {
        Console.WriteLine(res);
    }
}
```

## Console Applications
### StandardFizzBuzz (ConsoleApp1):
    Standard execution of the FizzBuzz algorithm.
### CustomFizzBuzz (ConsoleApp2):
    Execution of the FizzBuzz algorithm using custom Tokens and Divisors, with an input range from -20 to 127.
### NonSequentialInputFizzBuzz (ConsoleApp3):
    Execution of the FizzBuzz algorithm with a non-sequential list of integers as input: -5, 6, 300, 12, 25.
### APIGeneratedTokensFizzBuzz (ConsoleApp4):
    Execution of the FizzBuzz algorithm using custom Tokens and Divisors retrieved from an external API (https://rich-red-cocoon-veil.cyclic.app/).

## Test Project
The library tests were developed using XUnit and can be found in the **TwistedFizzBuzzLibraryTests** project. Unit tests were developed for all public methods of the library, as well as for its Factory.