/*
 * Copyright (c) 2017 ChemADVISOR, Inc. All rights reserved.
 * Licensed under The MIT License (MIT)
 * https://opensource.org/licenses/MIT
 */

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleClient
{
    internal class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // set base address
            var baseAddress = "https://sandbox.chemadvisor.io/chem/rest/v2/";

            // set app_key header
            var appKey = "your_app_key";

            // set app_id header
            var appId = "your_app_id";

            // set accept header: "application/xml", "application/json"
            var acceptHeader = "application/json";

            // set resource
            var resource = "regulatory_lists";

            // set query parameters: q, limit, offset
            var q = Uri.EscapeUriString("{\"tags.tag.name\":\"Government Inventory Lists\"}");
            var limit = 10;
            var offset = 0;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));
            client.DefaultRequestHeaders.Add("app_key", appKey);
            client.DefaultRequestHeaders.Add("app_id", appId);
            var response = await client.GetAsync(string.Format("{0}?q={1}&limit={2}&offset={3}", resource, q, limit, offset));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            Console.ReadLine();
        }
    }
}
