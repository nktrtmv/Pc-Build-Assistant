using Dal.Repositories.Interfaces;
using Dal.Settings;
using Microsoft.Extensions.Options;

namespace Dal.Repositories;

public class HardwareRepository : BaseRepository, IHardwareRepository
{
    public HardwareRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }
}