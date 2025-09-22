using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using Newtonsoft.Json;

namespace AppRpgEtec.Services.Enderecos
{
    internal class EnderecoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "AppRpgEtec/1.0 (seuemail@dominio.com)");
        }

        public async Task<List<Endereco>> BuscarEnderecoPorCepAsync(string cep)
        {
            string url = $"https://nominatim.openstreetmap.org/search?format=json&q={cep}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Endereco>>(response);
        }

    }
}


