// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using StarWarsAPI;


 public class StarWarsAPIClient
    {
        readonly protected string BaseAddress = @"http://swapi.dev/";
        readonly protected string AcceptHeader = "application/json";

        /// <summary>
        /// Helper method to create a HttpClient object
        /// </summary>
        /// <returns></returns>
        HttpClient GetClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

            return client;
        }
      }   

       
