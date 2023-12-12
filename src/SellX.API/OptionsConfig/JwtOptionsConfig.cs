using Microsoft.Extensions.Options;
using SellX.Infrastructure.Security;

namespace SellX.API.OptionsConfig;
public class JwtOptionsConfig : IConfigureOptions<JwtOptions>
{
    private const string JwtSectionName = "Jwt";
    private readonly IConfiguration configuration;

    public JwtOptionsConfig(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtSectionName).Bind(options);
    }
}
