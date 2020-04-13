using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAuthClient.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddBaseAddressHttpClient();
      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();
      builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
      builder.Services.AddSingleton<CurrentUserService>();

      await builder.Build().RunAsync();
    }
  }
}
