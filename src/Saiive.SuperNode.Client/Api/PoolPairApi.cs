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
    public interface IPoolPairApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="poolID"></param>
        /// <returns>PoolPairModel</returns>
        PoolPairModel ApiV1NetworkCoinGetpoolpairPoolIDGet (string coin, string network, string poolID);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>PoolPairModel</returns>
        PoolPairModel ApiV1NetworkCoinListpoolpairsGet (string coin, string network);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PoolPairApi : IPoolPairApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolPairApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PoolPairApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolPairApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PoolPairApi(String basePath)
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
        /// <param name="poolID"></param>
        /// <returns>PoolPairModel</returns>
        public PoolPairModel ApiV1NetworkCoinGetpoolpairPoolIDGet (string coin, string network, string poolID)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinGetpoolpairPoolIDGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinGetpoolpairPoolIDGet");
            // verify the required parameter 'poolID' is set
            if (poolID == null) throw new Client.ApiException(400, "Missing required parameter 'poolID' when calling ApiV1NetworkCoinGetpoolpairPoolIDGet");
    
            var path = "/api/v1/{network}/{coin}/getpoolpair/{poolID}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "poolID" + "}", ApiClient.ParameterToString(poolID));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinGetpoolpairPoolIDGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinGetpoolpairPoolIDGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PoolPairModel) ApiClient.Deserialize(response.Content, typeof(PoolPairModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>PoolPairModel</returns>
        public PoolPairModel ApiV1NetworkCoinListpoolpairsGet (string coin, string network)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinListpoolpairsGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinListpoolpairsGet");
    
            var path = "/api/v1/{network}/{coin}/listpoolpairs";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolpairsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolpairsGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PoolPairModel) ApiClient.Deserialize(response.Content, typeof(PoolPairModel), response.Headers);
        }
    
    }
}
