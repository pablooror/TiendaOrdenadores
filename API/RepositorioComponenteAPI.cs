using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Newtonsoft.Json;
using System.Text;

namespace ComponentesMVC.API
{
    public class RepositorioComponenteAPI : IRepositorioComponente
    {
        private readonly HttpClient _httpClient;

        public RepositorioComponenteAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public Componente? ConsultarComponente(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Componente/{Id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Componente>(response);
        }

        public void BorrarComponente(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Componente/{Id}";
            _httpClient.DeleteAsync(url);
        }

        public void AgregarComponente(Componente componente)
        {
            var url = "https://webapipc.azurewebsites.net/api/Componente";
            var json = JsonConvert.SerializeObject(componente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void EditarComponente(Componente componente)
        {
            var url = "https://webapipc.azurewebsites.net/api/Componente";
            var json = JsonConvert.SerializeObject(componente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public List<Componente>? ListarComponentes()
        {
            var url = "https://webapipc.azurewebsites.net/api/Componente";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}
