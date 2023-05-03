using ApiGateway.Models;

namespace ApiGateway.Dal;

public interface IDatabase
{
    Guid SaveBuild(PcBuild pcBuild);
    
    PcBuild? GetBuild(Guid id);
}