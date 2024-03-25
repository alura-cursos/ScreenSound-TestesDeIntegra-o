using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ScreenSound.Banco;
using System.Text.Json.Serialization;

namespace ScreenSound.Integration.Test
{
    public class ScreenSoundWebApplicationFactory: WebApplicationFactory<Program>
    {
        public ScreenSoundContext Context { get; }

        private IServiceScope scope;

        public ScreenSoundWebApplicationFactory()
        {
            this.scope = Services.CreateScope();
            Context = scope.ServiceProvider.GetRequiredService<ScreenSoundContext>();
        }

    }
}
