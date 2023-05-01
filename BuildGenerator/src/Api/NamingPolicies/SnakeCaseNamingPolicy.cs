using System.Text.Json;
using Generator.Extensions;

namespace Generator.NamingPolicies;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToSnakeCase();
}