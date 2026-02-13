using System;

// Interface
interface PlayMethod
{
    string getSound();
    string getStyle();
}

// Concrete Implementation - Acoustic
class Acoustic : PlayMethod
{
    private string quality;
    
    public Acoustic(string q)
    {
        quality = q;
    }
    
    public string getSound()
    {
        return "Acoustic Sound";
    }
    
    public string getStyle()
    {
        return quality;
    }
}

// Concrete Implementation - Electronic
class Electronic : PlayMethod
{
    private string effectType;
    
    public Electronic(string effect)
    {
        effectType = effect;
    }
    
    public string getSound()
    {
        return "Electronic Sound";
    }
    
    public string getStyle()
    {
        return effectType;
    }
}

// Abstraction
abstract class Instrument
{
    protected PlayMethod playMethod;
    
    public Instrument(PlayMethod pm)
    {
        playMethod = pm;
    }
    
    public abstract string play();
}

// Refined Abstraction - Guitar
class Guitar : Instrument
{
    public Guitar(PlayMethod pm) : base(pm) { }
    
    public override string play()
    {
        return "Guitar >> " + playMethod.getSound() + " : " + playMethod.getStyle();
    }
}

// Refined Abstraction - Piano
class Piano : Instrument
{
    public Piano(PlayMethod pm) : base(pm) { }
    
    public override string play()
    {
        return "Piano >> " + playMethod.getSound() + " : " + playMethod.getStyle();
    }
}

// Client function
class Program
{
    static void client(Instrument instrument)
    {
        Console.WriteLine(instrument.play());
    }
    
    static void Main()
    {
        // Create PlayMethod objects
        PlayMethod acoustic = new Acoustic("Concert Quality");
        
        // Create Instruments with Acoustic
        Instrument guitar1 = new Guitar(acoustic);
        client(guitar1);
        
        Instrument piano1 = new Piano(acoustic);
        client(piano1);
        
        // Change to Electronic
        PlayMethod electronic = new Electronic("Distortion Effect");
        
        Instrument guitar2 = new Guitar(electronic);
        client(guitar2);
        
        Instrument piano2 = new Piano(electronic);
        client(piano2);
        
        // Try different combinations
        PlayMethod reverb = new Electronic("Reverb Effect");
        Instrument guitar3 = new Guitar(reverb);
        client(guitar3);
    }
}