using Bll.Models.Hardware.Abstractions;

namespace Bll.RepositoryInterfaces;

public interface IHardwareRepository
{
    Task<IEnumerable<Hardware>> QueryHardware(CancellationToken token);
}