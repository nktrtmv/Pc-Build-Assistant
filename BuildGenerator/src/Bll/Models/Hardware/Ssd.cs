namespace Bll.Models.Hardware;

public class Ssd : Abstractions.Hardware
{
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;

    public int Capacity { get; set; }
    public int ReadSpeed { get; set; }
    public int WriteSpeed { get; set; }

    public Ssd()
    {
        
    }
    
    public Ssd(double price, string link, string model, int capacity, int readSpeed, int writeSpeed)
    {
        Price = price;
        Link = link;
        Model = model;
        Capacity = capacity;
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
    }
}