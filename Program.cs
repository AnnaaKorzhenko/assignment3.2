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

/*my_Dict.Add(new KeyValuePair("k1", "v1"));
my_Dict.Add(new KeyValuePair("k2", "v2"));
my_Dict.Add(new KeyValuePair("k3", "v3"));
my_Dict.Add(new KeyValuePair("k4", "v4"));
my_Dict.Print();*/