using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace HashingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashingController : ControllerBase
    {
        [HttpGet]
        public string Hash([FromBody] string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);

            using (var algorithm = SHA256.Create())
            {
                var hashedBytes = algorithm.ComputeHash(bytes);

                return GetHashString(hashedBytes);
            }
        }

        private static string GetHashString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var b in bytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }

}
