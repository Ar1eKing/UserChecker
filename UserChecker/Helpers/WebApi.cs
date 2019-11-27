using System;
using System.Net;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using UserChecker.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace UserChecker
{
    public class WebApi
    {
        public const string URL = "https://webapp-qa.wisestamp.com";
        public static string API => URL + "/api";

        /// <summary>
        /// Post API request with custom parameters
        /// </summary>
        public static async Task<T> SendAsync<T>(string queryId, Dictionary<string, string> parameters = null)
        {
            {
                T rootObject = default(T);
                using (HttpClient httpClient = new HttpClient())
                {
                    var requestString = await GetRequestString(parameters);
                    var tempUrl = API + queryId;
                    httpClient.BaseAddress = new Uri(tempUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress)
                    {
                        Content = new StringContent(requestString)
                    };
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    var response = await httpClient.SendAsync(request);

                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        throw new Exception("Empty String!");
                    }

                    await Task.Factory.StartNew(() => rootObject = JsonConvert.DeserializeObject<T>(responseString));
                }
                return rootObject;
            }

        }

        public static async Task<T> SendAsync<T>(string queryId, string json, string token)
        {
            {
                T rootObject = default(T);
                using (HttpClient httpClient = new HttpClient())
                {
                    var tempUrl = API + queryId;
                    httpClient.BaseAddress = new Uri(tempUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var request = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress)
                    {
                        Content = stringContent
                    };
                    if (!string.IsNullOrEmpty(token))
                        request.Headers.Add("Authorization", "Basic " + token);
                    var response = await httpClient.SendAsync(request);

                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        throw new Exception("Empty String!");
                    }

                    await Task.Factory.StartNew(() => rootObject = JsonConvert.DeserializeObject<T>(responseString));
                }
                return rootObject;
            }

        }

        private static async Task<string> GetRequestString(Dictionary<string, string> parameters = null)
        {
            string stringParameters = string.Empty;
            return await Task.Factory.StartNew(() =>
            {
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        if (i != 0)
                            stringParameters += "&";
                        stringParameters += WebUtility.UrlEncode(parameters.ElementAt(i).Key) + "=" + WebUtility.UrlEncode(parameters.ElementAt(i).Value);
                    }
                }
                return stringParameters;
            });
        }

        private const string SearchUserId = "/users/get";
        public async static Task<UserInfo> SearchUser(string userId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("uid", userId);
            parameters.Add("without_signatures", "true");

            var rootObject = await SendAsync<UserInfo>(SearchUserId, parameters);

            return rootObject;
        }

        private const string RenderRequestId = "/signatures/render";
        public async static Task<SignatureRenderItem> RenderRequest(string signatureId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("signature_id", signatureId);

            var rootObject = await SendAsync<SignatureRenderItem>(RenderRequestId, parameters);

            return rootObject;
        }
    }
}