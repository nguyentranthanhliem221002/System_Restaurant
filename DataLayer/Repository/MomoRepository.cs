using DataLayer.IRepository;
using System.Security.Cryptography;
using System.Text;
using TransferObject;
using Newtonsoft.Json;

namespace DataLayer.Repository
{
    public class MomoRepository : IMomoRepository
    {
        private readonly ApplicationDbContext _context;
        private static readonly HttpClient _httpClient = new HttpClient(); 

        public MomoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateMomoPaymentAsync()
        {

            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO5RGX20191128";
            string accessKey = "M8brj9K6E22vXoDB";
            string secretKey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderId = DateTime.Now.Ticks.ToString();
            string requestId = orderId;
            string amount = "10000"; // Ví dụ: 10.000 VND
            string orderInfo = "Thanh toan don hang demo";
            string returnUrl = "https://webhook.site/your-return-url";
            string notifyUrl = "https://webhook.site/your-notify-url";

            // Tạo chữ ký
            string rawHash = $"accessKey={accessKey}&amount={amount}&extraData=&ipnUrl={notifyUrl}&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={returnUrl}&requestId={requestId}&requestType=captureWallet";
            string signature = CreateSignature(secretKey, rawHash); 

            var requestBody = new
            {
                partnerCode,
                accessKey,
                requestId,
                amount,
                orderId,
                orderInfo,
                redirectUrl = returnUrl,
                ipnUrl = notifyUrl,
                lang = "vi",
                extraData = "",
                requestType = "captureWallet",
                signature
            };

            // Gửi yêu cầu POST tới MoMo API
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            var result = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(result);
            string payUrl = json.payUrl;

            var paymentMomo = new PaymentMomo
            {
                OrderId = "ORDER - " + orderId,
                RequestId = requestId,
                Amount = amount, 
                PayUrl = payUrl,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.Now
            };

            try
            {
                _context.PaymentMomos.Add(paymentMomo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo thanh toán MoMo: " + (ex.InnerException?.Message ?? ex.Message));
            }

            return payUrl;
        }

        public string CreateSignature(string key, string rawData)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
