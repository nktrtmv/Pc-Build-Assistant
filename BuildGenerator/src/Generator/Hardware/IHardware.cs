namespace Generator.Hardware;

public interface IHardware
{ 
    /// <summary>
    /// Price of the hardware.
    /// </summary>
    double Price { get; set; }
    
    /// <summary>
    /// Link from the E-market of the hardware.
    /// </summary>
    string? Link { get; set; }
    
    /// <summary>
    /// Manufacturer of the hardware.
    /// </summary>
    string? Manufacturer { get; set; }
}