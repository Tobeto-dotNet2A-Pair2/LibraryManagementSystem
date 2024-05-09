

namespace Application.Features.Streets.Constants;


public static class StreetsOperationClaims
{
    private const string _section = "Streets";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";

    public const string GetDynamic = $"{_section}.GetDynamic";
}