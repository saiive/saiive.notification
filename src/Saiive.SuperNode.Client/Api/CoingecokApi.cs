using System;
using System.Collections.Generic;
using RestSharp;
using Saiive.SuperNode.Client.Client;
using Saiive.SuperNode.Client.Model;

namespace Saiive.SuperNode.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICoingecokApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="currency"></param>
        /// <returns>Dictionary&lt;string, CoinPrice&gt;</returns>
        Dictionary<string, CoinPrice> ApiV1NetworkCoinCoinPriceCurrencyGet (string coin, string network, string currency);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CoingecokApi : ICoingecokApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoingecokApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public CoingecokApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CoingecokApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CoingecokApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="currency"></param>
        /// <returns>Dictionary&lt;string, CoinPrice&gt;</returns>
        public Dictionary<string, CoinPrice> ApiV1NetworkCoinCoinPriceCurrencyGet (string coin, string network, string currency)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinCoinPriceCurrencyGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinCoinPriceCurrencyGet");
            // verify the required parameter 'currency' is set
            if (currency == null) throw new Client.ApiException(400, "Missing required parameter 'currency' when calling ApiV1NetworkCoinCoinPriceCurrencyGet");
    
            var path = "/api/v1/{network}/{coin}/coin-price/{currency}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "currency" + "}", ApiClient.ParameterToString(currency));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinCoinPriceCurrencyGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinCoinPriceCurrencyGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Dictionary<string, CoinPrice>) ApiClient.Deserialize(response.Content, typeof(Dictionary<string, CoinPrice>), response.Headers);
        }
    
    }
}
