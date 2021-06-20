using System;
using System.Collections.Generic;
using RestSharp;
using Saiive.SuperNode.Client.Client;

namespace Saiive.SuperNode.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthCheckApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        void ApiV1HealthGet ();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="network"></param>
        /// <param name="coin"></param>
        /// <returns></returns>
        void ApiV1NetworkCoinHealthGet (string network, string coin);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class HealthCheckApi : IHealthCheckApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public HealthCheckApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckApi"/> class.
        /// </summary>
        /// <returns></returns>
        public HealthCheckApi(String basePath)
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
        /// <returns></returns>
        public void ApiV1HealthGet ()
        {
    
            var path = "/api/v1/health";
            path = path.Replace("{format}", "json");
                
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1HealthGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1HealthGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="network"></param>
        /// <param name="coin"></param>
        /// <returns></returns>
        public void ApiV1NetworkCoinHealthGet (string network, string coin)
        {
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinHealthGet");
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinHealthGet");
    
            var path = "/api/v1/{network}/{coin}/health";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinHealthGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinHealthGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
    }
}
