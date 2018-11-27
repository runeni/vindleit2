using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using yrlib.models;
using System.Xml.Serialization;
// using Newtonsoft.Json;

namespace yrlib
{
  public class Yrlib
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public Yrlib(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public Weatherdata GetForecast()
    {
      var result = deserialize().Result;
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

    public async Task<Weatherdata> deserialize()
    {
      string uri = "http://www.yr.no/sted/Sverige/V%C3%A4stra_G%C3%B6taland/Skalhamn/varsel.xml";
      var client = _httpClientFactory.CreateClient();
      HttpResponseMessage response = await client.GetAsync(uri);
      XmlSerializer ds = new XmlSerializer(typeof(Weatherdata));
      var stream = await response.Content.ReadAsStreamAsync();
      return (Weatherdata)ds.Deserialize(stream);
    }
  }
}