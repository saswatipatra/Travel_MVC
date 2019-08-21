using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace travel_mvc.Models
{
    public class Destination
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double AvgRating { get; set; }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

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
    }
}