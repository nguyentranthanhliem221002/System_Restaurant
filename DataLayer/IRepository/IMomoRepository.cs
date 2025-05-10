namespace DataLayer.IRepository
{
    public interface IMomoRepository
    {
        Task<string> CreateMomoPaymentAsync();

        string CreateSignature(string key, string rawData);
    }
}
