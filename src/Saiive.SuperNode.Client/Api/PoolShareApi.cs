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
    public interface IPoolShareApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        Dictionary<string, PoolShareModel> ApiV1NetworkCoinListminepoolsharesPost (string coin, string network, AddressesBodyRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        Dictionary<string, PoolShareModel> ApiV1NetworkCoinListpoolsharesGet (string coin, string network);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="includingStart"></param>
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        Dictionary<string, PoolShareModel> ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet (string coin, string network, int? start, int? limit, bool? includingStart);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PoolShareApi : IPoolShareApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolShareApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PoolShareApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PoolShareApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PoolShareApi(String basePath)
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
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        public Dictionary<string, PoolShareModel> ApiV1NetworkCoinListminepoolsharesPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinListminepoolsharesPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinListminepoolsharesPost");
    
            var path = "/api/v1/{network}/{coin}/listminepoolshares";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListminepoolsharesPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListminepoolsharesPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Dictionary<string, PoolShareModel>) ApiClient.Deserialize(response.Content, typeof(Dictionary<string, PoolShareModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        public Dictionary<string, PoolShareModel> ApiV1NetworkCoinListpoolsharesGet (string coin, string network)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinListpoolsharesGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinListpoolsharesGet");
    
            var path = "/api/v1/{network}/{coin}/listpoolshares";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolsharesGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolsharesGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Dictionary<string, PoolShareModel>) ApiClient.Deserialize(response.Content, typeof(Dictionary<string, PoolShareModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="includingStart"></param>
        /// <returns>Dictionary&lt;string, PoolShareModel&gt;</returns>
        public Dictionary<string, PoolShareModel> ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet (string coin, string network, int? start, int? limit, bool? includingStart)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet");
            // verify the required parameter 'start' is set
            if (start == null) throw new Client.ApiException(400, "Missing required parameter 'start' when calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet");
            // verify the required parameter 'limit' is set
            if (limit == null) throw new Client.ApiException(400, "Missing required parameter 'limit' when calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet");
            // verify the required parameter 'includingStart' is set
            if (includingStart == null) throw new Client.ApiException(400, "Missing required parameter 'includingStart' when calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet");
    
            var path = "/api/v1/{network}/{coin}/listpoolshares/{start}/{limit}/{including_start}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "start" + "}", ApiClient.ParameterToString(start));
path = path.Replace("{" + "limit" + "}", ApiClient.ParameterToString(limit));
path = path.Replace("{" + "including_start" + "}", ApiClient.ParameterToString(includingStart));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinListpoolsharesStartLimitIncludingStartGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Dictionary<string, PoolShareModel>) ApiClient.Deserialize(response.Content, typeof(Dictionary<string, PoolShareModel>), response.Headers);
        }
    
    }
}
