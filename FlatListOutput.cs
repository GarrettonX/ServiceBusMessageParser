public class FlatListOutput
{
    private readonly List<Dictionary<string, string>> _extractedValues;
    private readonly string _propertyToFlatList;
    private readonly bool _filterDuplicates;

    public FlatListOutput(List<Dictionary<string, string>> extractedValues, string propertyToFlatList, bool filterDuplicates)
    {
        _extractedValues = extractedValues;
        _propertyToFlatList = propertyToFlatList;
        _filterDuplicates = filterDuplicates;
    }

    public void Output()
    {
        var flatList = ExtractFlatList(_extractedValues, _propertyToFlatList, _filterDuplicates);
        Console.WriteLine($"Flache Liste von {_propertyToFlatList}:");
        foreach (var item in flatList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Anzahl der Ergebnisse: {flatList.Count}");
    }

    private List<string> ExtractFlatList(List<Dictionary<string, string>> extractedValues, string propertyToFlatList, bool filterDuplicates)
    {
        var flatList = new List<string>();
        var uniqueValues = new HashSet<string>(); // Verwenden Sie HashSet, um Duplikate zu vermeiden
        foreach (var extractedValue in extractedValues)
        {
            if (extractedValue.ContainsKey(propertyToFlatList))
            {
                var value = extractedValue[propertyToFlatList];
                if (!filterDuplicates || uniqueValues.Add(value))
                {
                    flatList.Add(value);
                }
            }
        }

        return flatList;
    }
}

