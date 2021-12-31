namespace BlazorShop.Application.Common.Interfaces
{
    public interface IEncryptionService
    {
        string? DecryptData(string? cipherText);
        byte[] EncryptData(string? plainText);
    }
}
