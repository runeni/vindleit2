using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;


namespace yrlib
{
  public class Yrlib
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public Yrlib(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public string GetForecast()
    {
      var result = GetFromYr().Result;
      return result;
    }
    public async Task<string> GetFromYr()
    {
      string uri = "http://www.yr.no/sted/Sverige/V%C3%A4stra_G%C3%B6taland/Skalhamn/varsel.xml";
      // uri = "http://vind.template.no";
      var client = _httpClientFactory.CreateClient();
      var result = await client.GetStringAsync(uri);
      return result;
    }
  }
}
