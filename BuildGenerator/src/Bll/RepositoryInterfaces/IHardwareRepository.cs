using Bll.Models.Hardware.Abstractions;

namespace Bll.RepositoryInterfaces;

public interface IHardwareRepository
{
    Task<List<Hardware>> QueryHardware(CancellationToken token);
}