using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

namespace BlazorAuthClient.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddOptions();
      builder.Services.AddAuthorizationCore();
      builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
      builder.Services.AddSingleton<CurrentUserService>();

      await builder.Build().RunAsync();
    }
  }
}
