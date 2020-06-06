using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilmemYol.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BilmemYol.Web.Contollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var client = new RestClient("http://localhost:5000/api/product/getproducts");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = response.Content;
                var apiResponse= JsonConvert.DeserializeObject<ApiResponse>(content);
                if (apiResponse.Code == 200)
                {
                    var products = JsonConvert.DeserializeObject<List<Product>>(apiResponse.Set.ToString());
                    return View(products);
                }

            }
            return View();
        }
    }
}