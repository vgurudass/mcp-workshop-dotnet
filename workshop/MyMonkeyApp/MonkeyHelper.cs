namespace MyMonkeyApp;

/// <summary>
/// Provides static methods to manage and retrieve monkey data from the Monkey MCP server.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static readonly object lockObj = new();
    private static int randomAccessCount = 0;

    /// <summary>
    /// Gets all monkeys from the MCP server (cached after first call).
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        EnsureMonkeysLoaded();
        return monkeys!;
    }

    /// <summary>
    /// Gets a monkey by name (case-insensitive).
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        EnsureMonkeysLoaded();
        return monkeys!.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey and increments the access count.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        EnsureMonkeysLoaded();
        var rand = new Random();
        lock (lockObj)
        {
            randomAccessCount++;
        }
        return monkeys![rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomAccessCount()
    {
        lock (lockObj)
        {
            return randomAccessCount;
        }
    }

    // Loads monkeys from the MCP server (placeholder for actual HTTP call)
    private static void EnsureMonkeysLoaded()
    {
        if (monkeys != null) return;
        lock (lockObj)
        {
            if (monkeys == null)
            {
                // TODO: Replace with actual HTTP call to MCP server
                monkeys = new List<Monkey>
                {
                    new Monkey { Name = "Capuchin", Location = "Central & South America", Population = 100000, Description = "Small, intelligent, and social monkeys." },
                    new Monkey { Name = "Mandrill", Location = "Central Africa", Population = 20000, Description = "Largest monkey species, colorful face." },
                    new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 3500, Description = "Bright orange fur, endangered." },
                    new Monkey { Name = "Japanese Macaque", Location = "Japan", Population = 114000, Description = "Also known as snow monkeys." },
                    new Monkey { Name = "Howler Monkey", Location = "Central & South America", Population = 1000000, Description = "Loudest land animal, prehensile tail." }
                };
            }
        }
    }
}
