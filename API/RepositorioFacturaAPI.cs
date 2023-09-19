using ComponentesMVC.Models;
using ComponentesMVC.Services;
using Newtonsoft.Json;
using System.Text;

namespace ComponentesMVC.API
{
    public class RepositorioFacturaAPI : IRepositorioFactura
    {
        private readonly HttpClient _httpClient;

        public RepositorioFacturaAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void AgregarFactura(Factura factura)
        {
            var url = "https://webapipc.azurewebsites.net/api/Factura";
            var json = JsonConvert.SerializeObject(factura);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void BorrarFactura(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Factura/{Id}";
            _httpClient.DeleteAsync(url);
        }

        public Factura? ConsultarFactura(int Id)
        {
            var url = $"https://webapipc.azurewebsites.net/api/Factura/{Id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Factura>(response);
        }

        public void EditarFactura(Factura factura)
        {
            var url = "https://webapipc.azurewebsites.net/api/Factura";
            var json = JsonConvert.SerializeObject(factura);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public List<Pedido>? ListarPedidosEnFactura(Factura factura)
        {
            var url = "https://webapipc.azurewebsites.net/api/Factura";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Pedido>>(response);
            if (lista == null) return new();

            return lista;
        }

        public List<Factura>? ListarFacturas()
        {
            var url = "https://webapipc.azurewebsites.net/api/Factura";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Factura>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}
