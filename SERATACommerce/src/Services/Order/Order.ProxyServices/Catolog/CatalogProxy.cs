using Microsoft.Extensions.Options;
using Order.ProxyServices.Catolog.Commands;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Order.ProxyServices.Catolog
{

    public interface ICatalogProxy
    {
        Task UpdateStockAsync(ProductInStockUpdateCommand command);
    }
    public  class CatalogProxy: ICatalogProxy
    {

        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public CatalogProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient) 
        {
            _apiUrls = apiUrls.Value;
            _httpClient = httpClient;
        }

        public async Task UpdateStockAsync(ProductInStockUpdateCommand command) 
        {

             var content = new StringContent(JsonSerializer.Serialize(command),
                 encoding: Encoding.UTF8, "application/json");
             
            var request= await _httpClient.PostAsync($"{_apiUrls.CatologUrl}/Stocks", content);
            request.EnsureSuccessStatusCode();


        }
    }
}
