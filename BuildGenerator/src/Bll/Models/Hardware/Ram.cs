namespace Bll.Models.Hardware;

public class Ram : Abstractions.Hardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Model { get; set; }

    public bool Ddr5 { get; set; }
    public int Frequency { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }

    public Ram()
    {
        
    }
    
    public Ram(double price, string link, string model, bool ddr5, int frequency, int capacity, int count)
    {
        Price = price;
        Link = link;
        Model = model;
        Ddr5 = ddr5;
        Frequency = frequency;
        Capacity = capacity;
        Count = count;
    }
}
