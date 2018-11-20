using System;
using yrlib;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace app
{
  class Program
  {
    static void Main(string[] args)
    {
      var services = new ServiceCollection();
      services.AddHttpClient();
      services.AddTransient<Yrlib>();

      var provider = services.BuildServiceProvider();
      var yrlib = provider.GetService<Yrlib>();

      Console.WriteLine(yrlib.GetForecast());
    }
  }
}
