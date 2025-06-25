namespace CryptoDealer.Core.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Creates signature to authenticate client
        /// </summary>
        /// <param name="_apiSecret"></param>
        /// <param name="timestamp"></param>
        /// <param name="method"></param>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        string CreateSignature(string _apiSecret, string timestamp, string method, string endpoint, string body = "");

        /// <summary>
        /// Authenticates client
        /// </summary>
        /// <param name="method"></param>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        RestRequest AuthenticateClient(string method, string endpoint, string body = "");

        /// <summary>
        /// Creates GET request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        Task<string> CreateGETRequest(string endpoint);

        /// <summary>
        /// Creates POST request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<string> CreatePOSTRequest(string endpoint, string body);

        /// <summary>
        /// Creates PUT request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<string> CreatePUTRequest(string endpoint, string body);

        /// <summary>
        /// Creates DELETE request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        Task<string> CreateDELETERequest(string endpoint);
    }
}
