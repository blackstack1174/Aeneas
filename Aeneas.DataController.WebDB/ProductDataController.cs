using System;
using System.Collections.Generic;
using System.Net.Http;
using Aeneas.Models;
using Newtonsoft.Json;

namespace Aeneas.DataController.WebDB
{
    public class ProductDataController : IProductDataController
    {
        public static string BaseUrl = "http://localhost:56734/ProductData";
        public static string AddUrl = BaseUrl + "/Add";
        public static string RemoveUrl = BaseUrl + "/Remove";
        public static string FindAllUrl = BaseUrl + "/FindAll";
        public static string FindByMainCategoryUrl = BaseUrl + "/FindByMainCategory";
        public IProductData Create()
        {
            return new ProductData();
        }

        public void Delete(IProductData product)
        {
            var productData = product as ProductData;

            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(RemoveUrl+"/"+productData.ProductID).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
        }

        public IEnumerable<IProductData> FindAll()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(FindAllUrl).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<ProductData>>(responseString);
        }

        public IEnumerable<IProductData> FindByMainCategory(string mainCategory)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(FindByMainCategoryUrl + "/" + mainCategory).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<ProductData>>(responseString);
        }

    }
}
