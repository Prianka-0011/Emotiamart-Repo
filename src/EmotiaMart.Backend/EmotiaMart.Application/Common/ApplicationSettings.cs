
using EmotiaMart.Application.Common.Interfaces;
namespace EmotiaMart.Application.Common;

public class ApplicationSettings : IApplicationSettings
{
    public string HashAlgorithm { get; init; } = "SHA512";
    public int HashIterations { get; init; } = 350000;
    public int SaltSize { get; init; } = 64;

    public string DefaultLanguage { get; init; } = "en-US";
}