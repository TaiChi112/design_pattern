using System;
using System.Collections.Generic;

// Component (Interface)
interface AquaticLife
{
    string GetInfo();
    void Swim();
}

// Composite
class AquaticGroup : AquaticLife
{
    private List<AquaticLife> members = new List<AquaticLife>();
    private string name;

    public AquaticGroup(string name)
    {
        this.name = name;
    }

    public void Add(AquaticLife a)
    {
        members.Add(a);
    }

    public string GetInfo()
    {
        string result = name + ":\n";
        foreach (AquaticLife a in members)
        {
            result += "  " + a.GetInfo();
        }
        return result;
    }

    public void Swim()
    {
        Console.WriteLine("[" + name + "] swimming together");
        foreach (AquaticLife a in members)
        {
            a.Swim();
        }
    }
}

// Leaf - KoiFish
class KoiFish : AquaticLife
{
    private string name;
    private string color;

    public KoiFish(string name, string color)
    {
        this.name = name;
        this.color = color;
    }

    public string GetInfo()
    {
        return "KoiFish: " + name + " (" + color + ")\n";
    }

    public void Swim()
    {
        Console.WriteLine("  " + name + " swimming");
    }
}

// Leaf - Goldfish
class Goldfish : AquaticLife
{
    private string name;

    public Goldfish(string name)
    {
        this.name = name;
    }

    public string GetInfo()
    {
        return "Goldfish: " + name + "\n";
    }

    public void Swim()
    {
        Console.WriteLine("  " + name + " swimming");
    }
}

// Leaf - ClownFish
class ClownFish : AquaticLife
{
    private string name;

    public ClownFish(string name)
    {
        this.name = name;
    }

    public string GetInfo()
    {
        return "ClownFish: " + name + "\n";
    }

    public void Swim()
    {
        Console.WriteLine("  " + name + " swimming");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create fish
        AquaticLife koi1 = new KoiFish("Koi-1", "red");
        AquaticLife koi2 = new KoiFish("Koi-2", "white");
        AquaticLife gold1 = new Goldfish("Gold-1");
        AquaticLife nemo = new ClownFish("Nemo");

        // Create groups
        AquaticGroup koiPond = new AquaticGroup("Koi Pond");
        koiPond.Add(koi1);
        koiPond.Add(koi2);

        AquaticGroup mainAquarium = new AquaticGroup("Main Aquarium");
        mainAquarium.Add(gold1);
        mainAquarium.Add(koiPond); // 
        mainAquarium.Add(nemo);

        // Display info
        Console.WriteLine("=== Aquarium Info ===");
        Console.WriteLine(mainAquarium.GetInfo());

        // Test swimming
        Console.WriteLine("\n=== Swimming Test ===");
        mainAquarium.Swim();

    }
}