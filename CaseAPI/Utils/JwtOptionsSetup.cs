using Microsoft.Extensions.Options;

namespace CaseAPI.Utils
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private IConfiguration configuration;
        public JwtOptionsSetup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void Configure(JwtOptions option)
        {
            configuration.GetSection("Jwt").Bind(option);
        }
    }
}
