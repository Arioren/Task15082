using System.Text;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Task15082.Model;

namespace Task15082.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<MyObject> _objects;


        //יוצר קונסטרקטור כדי לאתחל דאטה
        public HomeController(ILogger<HomeController> logger)
        {
            _objects = new List<MyObject>();
            GetPokemon();
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(_objects);
        }


       
       

       
      
        public static async void GetPokemon()
        {
            //Define your baseUrl
            string baseUrl = "https://fakestoreapi.com/products";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    //The HttpResponseMessage which contains status code, and data from response.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Then get the data or content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {

                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                Console.WriteLine("-----------------------------------------------------------------------------------");
                                Console.WriteLine("-----------------------------------------------------------------------------------");
                                //לפחות אני יועד שזה עובד עכשיו אני צריך להבין איך לנפוך את לליסט
                                var some = data.Split("},");  
                                
                                //כך שאוכל להפוך אותו לליסט data כאן אני הופך את 
                                var dataObj = JObject.Parse(data);
                                
                                foreach (var item in dataObj)
                                {
                                    //var myObject = item.ToObject<MyObject>();
                                    //_objects.Add(myObject);
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------");
                                Console.WriteLine("-----------------------------------------------------------------------------------");

                                //Now log your data in the console
                                Console.WriteLine("data------------{0}", data);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }

       
    }
}

