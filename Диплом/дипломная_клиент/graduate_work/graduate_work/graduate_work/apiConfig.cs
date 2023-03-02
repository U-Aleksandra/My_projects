using System.Net.Http;

namespace graduate_work.Droid
{
    public static class apiConfig
    {
        public static HttpClientHandler clientHandler = new HttpClientHandler();
        public static HttpClient client;

        static apiConfig()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }
    }
}