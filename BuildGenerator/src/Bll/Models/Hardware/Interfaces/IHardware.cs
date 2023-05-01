namespace Bll.Models.Hardware.Interfaces;

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
    /// Model of the hardware.
    /// </summary>
    string? Model { get; set; }
}