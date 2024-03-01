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
    public Node GetFirst()
    {
        return first;
    }

    public void Add(KeyValuePair data)
    {
        if (first == null)
        {
            first = new Node(data ,null);
        }
        else
        {
            Node curElement = first;
            while (curElement.Next != null)
            {
                curElement = curElement.Next;
            }
            curElement.Next = new Node(data,null);
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
        
        while (curElement.Data.Key != null)
        {
            if (curElement.Data.Key == key)
            {
                return curElement.Data.Value;
            }
            curElement = curElement.Next;
        }

        return null;
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
    private const float LoadFactor = 0.75f;
    private LinkedList[] _buckets = new LinkedList[InitialSize];
    private int CurrentSize = InitialSize;
    private int _count = 0;

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
        if (_buckets[hash] == null)
        {
            _buckets[hash] = new LinkedList();
            _buckets[hash].Add(pair);
            _count++;
        }
        else
        {
            _buckets[hash].Add(pair);
        }
        

        var bucketsfullness = (float)_count / CurrentSize;

        if (bucketsfullness > LoadFactor)
        {
            ResizeBuckets();
        }
    }

    public void Remove(string key)
    {
        var hash = CalculateHash(key) ;
        _buckets[hash].Remove(key);
    }

    public string Get(string key)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] != null)
        {
            var value = _buckets[hash].Get(key);

            return value;
        }

        return null;
    }


    private int CalculateHash(string key)
    {
        var hash = 0;
        foreach (var c in key)
        {
            hash = hash * c + c;
        }

        return hash % CurrentSize;
    }

    public void Print()
    {
        foreach (var b in _buckets)
        {
            b.Print();
            Console.WriteLine("\n====================================");
        }
    }

    private void ResizeBuckets()
    {
        CurrentSize *= 2;
        var newBuckets = new LinkedList[CurrentSize];
        int newCount = 0;
        for (int i = 0; i < _buckets.Length; i++)
        {
            LinkedList bucket = _buckets[i];
            if (bucket != null)
            {
                Node curElement = bucket.GetFirst();
                while (curElement != null)
                {
                    int newHash = CalculateHash(curElement.Data.Key);
                    if (newBuckets[newHash] == null)
                    {
                        newBuckets[newHash] = new LinkedList();
                    }
                    newBuckets[newHash].Add(curElement.Data);
                    curElement = curElement.Next;
                    newCount++;
                }
            }
        }
        _buckets = newBuckets;
        _count = newCount;
    }
}
