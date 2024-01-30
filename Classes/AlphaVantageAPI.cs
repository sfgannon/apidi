
// using securities.Interfaces;
// using Microsoft.Extensions.Configuration;

// namespace securities.Classes
// {
//     class AlphaVantageAPI : IAlphaVantageRequest {
//         private readonly HttpClient _client;
//         private readonly string baseUri = "https://www.alphavantage.co/query?";
//         private readonly string apiKey = 
//         public AlphaVantageAPI(HttpClient client) {
//             _client = client;
//         }
//         public async Task<TimeSeries> Intraday(string function, string symbol) {
//             // https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo
//             HttpClient client = _client;
//             // Call asynchronous network methods in a try/catch block to handle exceptions
//             try 
//             {
//                 HttpResponseMessage response = await client.GetAsync(string.Concat(this.baseUri, "function=", function, "&symbol=", symbol, "&apikey=", ));
//                 response.EnsureSuccessStatusCode();
//                 string responseBody = await response.Content.ReadAsStringAsync();
//                 return new TimeSeries();
//             }
//             catch (Exception ex) {
//                 throw new Exception(ex.Message);
//             }
//         }
//     }
// }