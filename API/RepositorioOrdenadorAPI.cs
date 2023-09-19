using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Newtonsoft.Json;
using System.Text;

namespace ComponentesMVC.API
{
    public class RepositorioOrdenadorAPI : IRepositorioOrdenador
    {
        private readonly HttpClient _httpClient;

        public RepositorioOrdenadorAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void AgregarOrdenador(Ordenador ordenador)
        {
            var url = "https://webapipc.azurewebsites.net/api/Ordenador";
            var json = JsonConvert.SerializeObject(ordenador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void BorrarOrdenador(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Ordenador/{Id}";
            _httpClient.DeleteAsync(url);
        }

        public Ordenador? ConsultarOrdenador(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Ordenador/{Id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Ordenador>(response);
        }

        public void EditarOrdenador(Ordenador ordenador)
        {
            var url = "https://webapipc.azurewebsites.net/api/Ordenador";
            var json = JsonConvert.SerializeObject(ordenador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public List<Componente>? ListarCompDelPc(Ordenador ordenador)
        {
            var url = "https://webapipc.azurewebsites.net/api/Ordenador";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
            if (lista == null) return new();

            return lista;
        }

        public List<Ordenador>? ListarOrdenadores()
        {
            var url = "https://webapipc.azurewebsites.net/api/Ordenador";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}
