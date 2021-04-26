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
    public interface IAccountHistoryApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <param name="token"></param>
        /// <param name="limit"></param>
        /// <param name="maxBlockHeight"></param>
        /// <param name="noRewards"></param>
        /// <returns>List&lt;AccountHistory&gt;</returns>
        List<AccountHistory> ApiV1NetworkCoinAccounthistoryAddressTokenPost (string coin, string network, string address, string token, string limit, string maxBlockHeight, bool? noRewards);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <param name="limit"></param>
        /// <param name="maxBlockHeight"></param>
        /// <param name="noRewards"></param>
        /// <returns>List&lt;AccountHistory&gt;</returns>
        List<AccountHistory> ApiV1NetworkCoinHistoryAllTokenPost (string coin, string network, string token, AddressesBodyRequest body, string limit, string maxBlockHeight, bool? noRewards);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AccountHistoryApi : IAccountHistoryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHistoryApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AccountHistoryApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHistoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccountHistoryApi(String basePath)
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
        /// <param name="address"></param>
        /// <param name="token"></param>
        /// <param name="limit"></param>
        /// <param name="maxBlockHeight"></param>
        /// <param name="noRewards"></param>
        /// <returns>List&lt;AccountHistory&gt;</returns>
        public List<AccountHistory> ApiV1NetworkCoinAccounthistoryAddressTokenPost (string coin, string network, string address, string token, string limit, string maxBlockHeight, bool? noRewards)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinAccounthistoryAddressTokenPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinAccounthistoryAddressTokenPost");
            // verify the required parameter 'address' is set
            if (address == null) throw new ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinAccounthistoryAddressTokenPost");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiV1NetworkCoinAccounthistoryAddressTokenPost");
    
            var path = "/api/v1/{network}/{coin}/accounthistory/{address}/{token}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
path = path.Replace("{" + "token" + "}", ApiClient.ParameterToString(token));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
 if (maxBlockHeight != null) queryParams.Add("maxBlockHeight", ApiClient.ParameterToString(maxBlockHeight)); // query parameter
 if (noRewards != null) queryParams.Add("no_rewards", ApiClient.ParameterToString(noRewards)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccounthistoryAddressTokenPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccounthistoryAddressTokenPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<AccountHistory>) ApiClient.Deserialize(response.Content, typeof(List<AccountHistory>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="token"></param>
        /// <param name="body"></param>
        /// <param name="limit"></param>
        /// <param name="maxBlockHeight"></param>
        /// <param name="noRewards"></param>
        /// <returns>List&lt;AccountHistory&gt;</returns>
        public List<AccountHistory> ApiV1NetworkCoinHistoryAllTokenPost (string coin, string network, string token, AddressesBodyRequest body, string limit, string maxBlockHeight, bool? noRewards)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinHistoryAllTokenPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinHistoryAllTokenPost");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling ApiV1NetworkCoinHistoryAllTokenPost");
    
            var path = "/api/v1/{network}/{coin}/history-all/{token}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "token" + "}", ApiClient.ParameterToString(token));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
 if (maxBlockHeight != null) queryParams.Add("maxBlockHeight", ApiClient.ParameterToString(maxBlockHeight)); // query parameter
 if (noRewards != null) queryParams.Add("no_rewards", ApiClient.ParameterToString(noRewards)); // query parameter
                        postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinHistoryAllTokenPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinHistoryAllTokenPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<AccountHistory>) ApiClient.Deserialize(response.Content, typeof(List<AccountHistory>), response.Headers);
        }
    
    }
}
