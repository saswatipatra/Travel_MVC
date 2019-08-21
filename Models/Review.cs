using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace travel_mvc.Models
{
    public class Review
    {
        public int ReviewId {get; set;}
        public int DestinationId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }

        // public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        // {
        //     var tcs = new TaskCompletionSource<IRestResponse>();
        //     theClient.ExecuteAsync(theRequest, response => {
        //         tcs.SetResult(response);
        //     });
        //     return tcs.Task;
        // }
        // // Display all Review
        // public static List<Review> GetReviews()
        // {
        //     var client = new RestClient("http://localhost:5000/api/");
        //     var request = new RestRequest("reviews", Method.GET);
        //     var response = new RestResponse();

        //     Task.Run(async () =>
        //     {
        //         response = await GetResponseContentAsync(client, request) as RestResponse;
        //     }).Wait();

        //     JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
        //     var reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());
        //     return reviewList;
        // }

        // // Add new Review
        // public static void PostReview(Review review)
        // {
        //     var client = new RestClient("http://localhost:5000/api/");
        //     var request = new RestRequest("reviews", Method.POST);
        //     request.AddJsonBody(review);
        //     var response = new RestResponse();

        //     Task.Run(async () =>
        //     {
        //         response = await GetResponseContentAsync(client, request) as RestResponse;
        //     }).Wait();
        // }
    }
}