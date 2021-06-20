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
    public interface IMasternodeApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>List&lt;Masternode&gt;</returns>
        List<Masternode> ApiV1NetworkCoinMasternodesListActiveGet (string coin, string network);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>List&lt;Masternode&gt;</returns>
        List<Masternode> ApiV1NetworkCoinMasternodesListGet (string coin, string network);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MasternodeApi : IMasternodeApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasternodeApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public MasternodeApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="MasternodeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MasternodeApi(String basePath)
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
        /// <returns>List&lt;Masternode&gt;</returns>
        public List<Masternode> ApiV1NetworkCoinMasternodesListActiveGet (string coin, string network)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinMasternodesListActiveGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinMasternodesListActiveGet");
    
            var path = "/api/v1/{network}/{coin}/masternodes/list/active";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinMasternodesListActiveGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinMasternodesListActiveGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Masternode>) ApiClient.Deserialize(response.Content, typeof(List<Masternode>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>List&lt;Masternode&gt;</returns>
        public List<Masternode> ApiV1NetworkCoinMasternodesListGet (string coin, string network)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinMasternodesListGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinMasternodesListGet");
    
            var path = "/api/v1/{network}/{coin}/masternodes/list";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinMasternodesListGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinMasternodesListGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Masternode>) ApiClient.Deserialize(response.Content, typeof(List<Masternode>), response.Headers);
        }
    
    }
}
