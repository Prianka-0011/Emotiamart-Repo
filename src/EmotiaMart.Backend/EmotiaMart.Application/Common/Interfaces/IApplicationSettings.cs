namespace EmotiaMart.Application.Common.Interfaces
{
    public interface IApplicationSettings
    {
        string HashAlgorithm { get; }
        int HashIterations { get; }
        int SaltSize { get; }
        string DefaultLanguage { get; }
    }
}
