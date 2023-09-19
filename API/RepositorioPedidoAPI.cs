using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Newtonsoft.Json;
using System.Text;

namespace ComponentesMVC.API
{
    public class RepositorioPedidoAPI : IRepositorioPedido
    {
        private readonly HttpClient _httpClient;

        public RepositorioPedidoAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void AgregarPedido(Pedido pedido)
        {
            var url = "https://webapipc.azurewebsites.net/api/Pedido";
            var json = JsonConvert.SerializeObject(pedido);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void BorrarPedido(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Pedido/{Id}";
            _httpClient.DeleteAsync(url);
        }

        public Pedido? ConsultarPedido(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Pedido/{Id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Pedido>(response);
        }

        public void EditarPedido(Pedido pedido)
        {
            var url = "https://webapipc.azurewebsites.net/api/Pedido";
            var json = JsonConvert.SerializeObject(pedido);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public List<Ordenador>? ListarPcEnPedido(Pedido pedido)
        {
            var url = "https://webapipc.azurewebsites.net/api/Pedido";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
            if (lista == null) return new();

            return lista;
        }

        public List<Pedido>? ListarPedidos()
        {
            var url = "https://webapipc.azurewebsites.net/api/Pedido";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Pedido>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}
