# Argus Media Technical Task Notes

## How To Run:
Make sure you have Visual Studio or VS Code.

Make sure you have installed the following extensions installed:
- C#
- NuGet Package Manager
- .NET Extension Pack
- .NET Install Tool
- .NET Core Tools
- .NET Core Test Explorer
- SpecFlow Steps Definition Generator
- SpecFlow Tools

Optional Extensions to install:
- Cucumber (Gherkin) Full Support
- GitHub Codespaces
- C# Extensions
- C# Dev Kit
- .NET Watch

Simply download this repository then run the following commands:
```
dotnet clean
dotnet build 
```

Once you have built the suite, you can either run it through using `dotnet test` or run it through the Test Explorer, but please note the **Issues** section on this.

### Assumptions:

- For the scenarios where the time isn't mentioned; I have assumed that the time is after 19:00 to ensure I calculate the drinks total correctly. If this is wrong and I need to calculate the total before 19:00; I can do that, as I have already made sure my code checks against that time.

- I have assumed the number of people on these scenarios don't matter, as it's the number of Starters, Mains and Drinks that they order that matters for this task, but if this is not correct, then my tests will need to be adjusted for that.

- I have assumed that the time of day can only be HH:mm and not HH:mm:ss or HH:mm:ss.sss (i.e: 19:00 and not 19:00:00 or 19:00:00.000) and so cannot currently handle seconds or milliseconds. If this is a problem, it should be pretty easy to fix, but will require a change in the tests to adjust for this.

### Issues:

- I could not get the code to output the values of the breakdown of the cost of the Starters, Mains and Drinks along with the Service Charge or Final Bill using any kind of output unless I added a breakpoint into the code and then ran the "Debug Test" option in the Test Explorer.