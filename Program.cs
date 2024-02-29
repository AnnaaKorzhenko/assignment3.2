//put the words from txt into dictionary
var my_Dict = new StringsDictionary();
string[] allData = File.ReadAllLines("../../../dictionary.txt");
foreach (var str in allData)
{
    string[] parts = str.Split("|", StringSplitOptions.RemoveEmptyEntries);
    my_Dict.Add(new KeyValuePair(parts[0], parts[2]));
}

//get word from the user and print it's meaning
Console.WriteLine("Please, enter a ord you want to search for");
var word = Console.ReadLine();
var value = my_Dict.Get(word);
Console.WriteLine($"==========================\n\n{value}\n\n==========================");