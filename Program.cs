partial class Program
{
    static void Main(string[] args)
    {
        // JSON Daten laden (Beispiel JSON)
        var jsonData = File.ReadAllText(@"data.json");

        // Die gewünschten Properties
        var propertiesToExtract = new List<string> { "LicenseOwnerId", "EntityId", "EntityName" };

        // Option zum Filtern von Duplikaten
        var filterDuplicates = true; // Setze auf false, wenn keine Duplikate entfernt werden sollen

        // Option zum Steuern der Ausgabeformat
        var outputFlatList = true; // Setze auf false für umfangreiche Ergebnisse

        // Property aus JSON extrahieren und zählen, wie oft jedes Ergebnis vorkommt
        var extractedValues = MessagePropertyExtractor.ExtractPropertiesFromServiceBusMessages(jsonData, propertiesToExtract, filterDuplicates);

        // Ergebnisse ausgeben
        if (outputFlatList)
        {
            var flatListOutput = new FlatListOutput(extractedValues, "LicenseOwnerId", filterDuplicates);
            flatListOutput.Output();
        }
        else
        {
            var detailedOutput = new DetailedOutput(extractedValues);
            detailedOutput.Output();
        }
    }
}
