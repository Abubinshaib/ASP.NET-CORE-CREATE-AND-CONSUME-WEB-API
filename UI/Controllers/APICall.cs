using RestSharp;

namespace UI.Controllers
{
    public static class APICall
    {
        public static string SendAPIPostRequest(string strUrl, string strInput)
        {
            RestSharp.RestClient restClient = new RestSharp.RestClient();

            var request = new RestSharp.RestRequest(strUrl, Method.Post);
            request.AddParameter("text/json", strInput, ParameterType.RequestBody);
            var response = restClient.Execute(request);
            string jsonresponse = response.Content;

            return jsonresponse;
        }

        public static string SendAPIGetRequest(string strUrl)
        {
            RestSharp.RestClient restClient = new RestSharp.RestClient();
            var request = new RestRequest(strUrl, Method.Get);
            var response = restClient.Execute(request);
            string jsonresponse = response.Content;
            return jsonresponse;
        }

        public static string SendAPIDeleteRequest(string strUrl)
        {
            RestSharp.RestClient restClient = new RestSharp.RestClient();
            var request = new RestRequest(strUrl, Method.Delete);
            var response = restClient.Execute(request);
            string jsonresponse = response.Content;
            return jsonresponse;
        }

        public static string SendAPIPutRequest(string strUrl)
        {
            RestSharp.RestClient restClient = new RestSharp.RestClient();
            var request = new RestRequest(strUrl, Method.Put);
            var response = restClient.Execute(request);
            string jsonresponse = response.Content;
            return jsonresponse;
        }
    }
}
