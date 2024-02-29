public class KeyValuePair
{
    public string Key { get; }
    public string Value { get; }
    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}


class Node {
    public KeyValuePair Data;
    public Node Next;
    public Node (KeyValuePair data, Node next)
    {
        Data = data;
        Next = next;
    }
}


class LinkedList
{
    private Node first = null;
    public void Add(KeyValuePair data)
    {
        if (first == null)
        {
            first = new Node(data, null);
        }
        else
        {
            Node curElement = first;
            while (curElement.Next != null)
            {
                curElement = curElement.Next;
            }
            curElement.Next = new Node(data, null);
        }
    }

    public void Remove(string key)
    {
        var curElement = first;
        Node previous = null;
        while (curElement != null && curElement.Data.Key != key)
        {
            previous = curElement;
            curElement = curElement.Next;
        }

        if (curElement != null)
        {
            if (curElement == first)
            {
                first = curElement.Next;
            }
            else
            {
                previous.Next = curElement.Next;
            }
        }
    }
    public string Get(string key)
    {
        var curElement = first;
        while (curElement.Data.Key != key)
        {
            curElement = curElement.Next;
        }

        return curElement.Data.Value;
    }

    public void Print()
    {
        Node curElement = first;
        while (curElement != null)
        {
            Console.Write($"| {curElement.Data.Key}:  {curElement.Data.Value}| -> ");
            curElement = curElement.Next;
        }
        Console.Write("NULL");
    } 
   
}



public class StringsDictionary
{
    private const int InitialSize = 10;
    private LinkedList[] _buckets = new LinkedList[InitialSize];

    public StringsDictionary()
    {
        for (var i = 0; i < InitialSize; ++i)
        {
            _buckets[i] = new LinkedList();
        }
    }
    public void Add(KeyValuePair pair)
    {
        var hash = CalculateHash(pair.Key);
        _buckets[hash].Add(pair);
    }

    public void Remove(string key)
    {
        var hash = CalculateHash(key);
        _buckets[hash].Remove(key);
    }

    public string Get(string key)
    {
        var hash = CalculateHash(key);
        var value =_buckets[hash].Get(key);
        return value;
    }


    private int CalculateHash(string key)
    {
        var hash = 0; 
        foreach (var c in key)
        {
            hash += c;
        }
        return hash % InitialSize;
    }

    public void Print()
    {
        foreach (var b in _buckets)
        {
            b.Print();
            Console.WriteLine("\n====================================");
        }
    }
}

