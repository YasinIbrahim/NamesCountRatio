using System;
using System.Collections.Generic;

class NamesCount
{
    private int Count;
    private Dictionary<string, int> Counts = new Dictionary<string, int>();

    /// <summary>
    /// Adds the name.
    /// </summary>
    /// <param name="name">Name.</param>
    public void AddName(string name)
    {
        int nameCount;
        
        if (Counts.TryGetValue(name, out nameCount))
        {
            Counts[name] = nameCount + 1;
            Console.WriteLine("Entry exists: " + name + " - incrementing count to: " + Counts[name]);
        }
        else { 
            Counts.Add(name, nameCount + 1);
            Console.WriteLine("Adding entry: " + name + " , with count: " + Counts[name]);
        }

        Count++;
                
    }

    /// <summary>
    /// Returns proportion of parameter name in all calls to AddName.
    /// </summary>
    /// <returns>Double in interval [0, 1]. Returns 0 if AddName has not been called.</returns>
    /// <param name="name">Name.</param>
    public double NameProportion(string name)
    {
        int nameCount;
        
        if (Counts.TryGetValue(name, out nameCount))
            return ((double)(Counts[name]) / (double)(Count));
        else
            return 0.000d;
            
    }

    public static void Main(string[] args)
    {
        NamesCount namesCount = new NamesCount();

        namesCount.AddName("John");
        namesCount.AddName("Mary");
        namesCount.AddName("Mary");
        
        Console.WriteLine("Fraction of Johns: {0:0.000}", namesCount.NameProportion("John"));
        Console.WriteLine("Fraction of Marys: {0:0.000}", namesCount.NameProportion("Mary"));
        Console.WriteLine("Total Number of name entries: "+ namesCount.Count);
        Console.ReadKey();
    }
}