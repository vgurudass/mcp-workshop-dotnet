using MyMonkeyApp;
using System;
using System.Collections.Generic;

var asciiArts = new[]
{
	@"  (o)(o)   (o)(o)   (o)(o)   (o)(o)   (o)(o)",
	@"   (__)     (__)     (__)     (__)     (__)",
	@"  /    \   /    \   /    \   /    \   /    \",
	@" (      ) (      ) (      ) (      ) (      )",
	@"  \____/   \____/   \____/   \____/   \____/",
	@"   //\\      //\\      //\\      //\\      //\\",
	@"   (''')     (''')     (''')     (''')     (''')",
	@"   Monkey business! 🐒"
};

void ShowRandomAsciiArt()
{
	var rand = new Random();
	var art = asciiArts[rand.Next(asciiArts.Length)];
	Console.WriteLine();
	Console.WriteLine(art);
	Console.WriteLine();
}

void PrintMonkeyTable(IEnumerable<Monkey> monkeys)
{
	Console.WriteLine($"| {"Name",-22} | {"Location",-24} | {"Population",10} | {"Description",-30} |");
	Console.WriteLine(new string('-', 98));
	foreach (var monkey in monkeys)
	{
		Console.WriteLine($"| {monkey.Name,-22} | {monkey.Location,-24} | {monkey.Population,10} | {monkey.Description,-30} |");
	}
	Console.WriteLine();
}

while (true)
{
	Console.Clear();
	Console.WriteLine(@"  __  __             _        _         _         _");
	Console.WriteLine(@" |  \/  |           | |      | |       | |       | |");
	Console.WriteLine(@" | \  / | ___  _ __ | | _____| |__   __| | ___   | |__   ___ _ __");
	Console.WriteLine(@" | |\/| |/ _ \| '_ \| |/ / __| '_ \ / _` |/ _ \  | '_ \ / _ \ '__|");
	Console.WriteLine(@" | |  | | (_) | | | |   <\__ \ | | | (_| |  __/  | | | |  __/ |");
	Console.WriteLine(@" |_|  |_|\___/|_| |_|_|\_\___/_| |_|\__,_|\___|  |_| |_|\___|_|");
	Console.WriteLine();
	ShowRandomAsciiArt();
	Console.WriteLine("Monkey Console App");
	Console.WriteLine("==================");
	Console.WriteLine("1. List all monkeys");
	Console.WriteLine("2. Get details for a specific monkey by name");
	Console.WriteLine("3. Get a random monkey");
	Console.WriteLine("4. Exit app");
	Console.Write("Select an option (1-4): ");
	var input = Console.ReadLine();
	Console.WriteLine();

	switch (input)
	{
		case "1":
			var monkeys = MonkeyHelper.GetMonkeys();
			PrintMonkeyTable(monkeys);
			Console.WriteLine($"Total monkeys: {monkeys.Count}");
			break;
		case "2":
			Console.Write("Enter monkey name: ");
			var name = Console.ReadLine();
			var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
			if (monkey != null)
			{
				PrintMonkeyTable(new[] { monkey });
			}
			else
			{
				Console.WriteLine("Monkey not found.");
			}
			break;
		case "3":
			var randomMonkey = MonkeyHelper.GetRandomMonkey();
			Console.WriteLine("Random Monkey:");
			PrintMonkeyTable(new[] { randomMonkey });
			Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomAccessCount()} times.");
			break;
		case "4":
			Console.WriteLine("Goodbye!");
			return;
		default:
			Console.WriteLine("Invalid option. Please try again.");
			break;
	}
	Console.WriteLine("Press Enter to continue...");
	Console.ReadLine();
}
