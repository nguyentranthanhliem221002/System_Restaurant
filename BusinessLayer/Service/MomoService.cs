using DataLayer.IRepository;

namespace BusinessLayer.Service
{
    public class MomoService
    {
        public readonly IMomoRepository _momoRepository;

        public MomoService(IMomoRepository momoRepository)
        {
            _momoRepository = momoRepository;
        }

        public async Task<string> CreateMomoPaymentAsync()
        {
            return await _momoRepository.CreateMomoPaymentAsync();
        }

        public string CreateSignature(string key, string rawData)
        {
            return _momoRepository.CreateSignature(key, rawData);
        }
    }
}
