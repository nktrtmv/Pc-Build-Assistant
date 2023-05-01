using Bll.Models.BuildTypes.Abstractions;

namespace Bll.Models;

public record GenerateBuildResult(
    PcBuild? Build
);