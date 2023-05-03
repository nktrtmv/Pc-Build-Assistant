using Bll.Models.BuildTypes.Enums;

namespace Generator.Requests;

public record BuildGenerationRequest(BuildType Type, int Budget);