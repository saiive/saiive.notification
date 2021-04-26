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
    public interface IDexApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>TestPoolSwapModel</returns>
        TestPoolSwapModel ApiV1NetworkCoinDexTestpoolswapPost (string coin, string network, TestPoolSwapBodyRequest body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DexApi : IDexApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DexApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DexApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DexApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DexApi(String basePath)
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
        /// <param name="body"></param>
        /// <returns>TestPoolSwapModel</returns>
        public TestPoolSwapModel ApiV1NetworkCoinDexTestpoolswapPost (string coin, string network, TestPoolSwapBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinDexTestpoolswapPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinDexTestpoolswapPost");
    
            var path = "/api/v1/{network}/{coin}/dex/testpoolswap";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinDexTestpoolswapPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinDexTestpoolswapPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TestPoolSwapModel) ApiClient.Deserialize(response.Content, typeof(TestPoolSwapModel), response.Headers);
        }
    
    }
}
