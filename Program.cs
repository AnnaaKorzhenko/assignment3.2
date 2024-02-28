var my_Dict = new StringsDictionary();
var path = "dictionary.txt";

var allData = File.ReadAllLines(path);
my_Dict.Add(new KeyValuePair("k1", "v1"));
my_Dict.Add(new KeyValuePair("k2", "v2"));
my_Dict.Add(new KeyValuePair("k3", "v3"));
my_Dict.Add(new KeyValuePair("k4", "v4"));
my_Dict.Print();
var value = my_Dict.Get("k4");
Console.WriteLine($"\n\n{value}\n\n==========================");