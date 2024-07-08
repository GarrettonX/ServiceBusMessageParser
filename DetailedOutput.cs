public class DetailedOutput
{
    private readonly List<Dictionary<string, string>> _extractedValues;

    public DetailedOutput(List<Dictionary<string, string>> extractedValues)
    {
        _extractedValues = extractedValues;
    }

    public void Output()
    {
        var index = 1;
        foreach (var extractedValue in _extractedValues)
        {
            Console.WriteLine($"Ergebnis {index}:");
            foreach (var kvp in extractedValue)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine();
            index++;
        }
    }
}

