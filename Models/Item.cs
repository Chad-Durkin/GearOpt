using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GearOptimizer.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }

        public static JObject GetPrices(string requestString)
        {
            var client = new RestClient("http://services.runescape.com/m=itemdb_oldschool");
            var request = new RestRequest(requestString, Method.GET);


            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject result = JsonConvert.DeserializeObject<JObject>(response.Content);

            return result;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        //Search through my json file for an items name, and grab the ID of it
        public static int LoadJsonFindId(string itemName)
        {
            int itemId = 0;
            List<Item> items = new List<Item>();

            string json = File.ReadAllText(@"C:\Users\chadd\Desktop\Projects\GearOptimizer\src\GearOptimizer\Resources\ItemInfo.json");
            items = JsonConvert.DeserializeObject<List<Item>>(json);

            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].name.ToLower() == itemName.ToLower())
                {
                    itemId = items[i].id;
                }
            }

            return itemId;
        }

    }
}
