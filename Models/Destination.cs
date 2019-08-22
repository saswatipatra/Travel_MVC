using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace travel_mvc.Models
{
    public class Destination
    {
        public int DestinationId {get; set;}
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double AvgRating { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        // Display first page of destinations
        public static List<Destination> GetDestinations()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());
            return destinationList;
        }

        // Display next page of destinations
        public static List<Destination> GetNextDestinations()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/next", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());
            return destinationList;
        }

        // Display prev page of destinations
        public static List<Destination> GetPrevDestinations()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/prev", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());
            return destinationList;
        }

        // Display particular destination 
        public static Destination GetPaticularDestinations(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisDestination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());
            return thisDestination;
        }

        // Add new Destination
        public static void PostDestination(Destination destination)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations", Method.POST);
            request.AddJsonBody(destination);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Delete particular Destination
        public static void DeleteDestination(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/"+id, Method.DELETE);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Editing a particular Destination
        public static void EditDestination(int id, Destination destination)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("destinations/"+id, Method.PUT);
            request.AddJsonBody(destination);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }


        
    }
}