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
    public interface ITransactionApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="block"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<TransactionModel> ApiV1NetworkCoinTxBlockBlockGet (string coin, string network, string block);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="height"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<BlockTransactionModel> ApiV1NetworkCoinTxHeightHeightGet (string coin, string network, int? height);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="txId"></param>
        /// <returns>TransactionModel</returns>
        TransactionModel ApiV1NetworkCoinTxIdTxIdGet (string coin, string network, string txId);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>TransactionResponse</returns>
        TransactionResponse ApiV1NetworkCoinTxRawPost (string coin, string network, TransactionRequest body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TransactionApi : ITransactionApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TransactionApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TransactionApi(String basePath)
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
        /// <param name="block"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<TransactionModel> ApiV1NetworkCoinTxBlockBlockGet (string coin, string network, string block)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxBlockBlockGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxBlockBlockGet");
            // verify the required parameter 'block' is set
            if (block == null) throw new ApiException(400, "Missing required parameter 'block' when calling ApiV1NetworkCoinTxBlockBlockGet");
    
            var path = "/api/v1/{network}/{coin}/tx/block/{block}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "block" + "}", ApiClient.ParameterToString(block));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxBlockBlockGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxBlockBlockGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<TransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<TransactionModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="height"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<BlockTransactionModel> ApiV1NetworkCoinTxHeightHeightGet (string coin, string network, int? height)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxHeightHeightGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxHeightHeightGet");
            // verify the required parameter 'height' is set
            if (height == null) throw new ApiException(400, "Missing required parameter 'height' when calling ApiV1NetworkCoinTxHeightHeightGet");
    
            var path = "/api/v1/{network}/{coin}/tx/height/{height}/true";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin.ToUpper()));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network.ToLower()));
path = path.Replace("{" + "height" + "}", ApiClient.ParameterToString(height));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxHeightHeightGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxHeightHeightGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<BlockTransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<BlockTransactionModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="txId"></param>
        /// <returns>TransactionModel</returns>
        public TransactionModel ApiV1NetworkCoinTxIdTxIdGet (string coin, string network, string txId)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxIdTxIdGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxIdTxIdGet");
            // verify the required parameter 'txId' is set
            if (txId == null) throw new ApiException(400, "Missing required parameter 'txId' when calling ApiV1NetworkCoinTxIdTxIdGet");
    
            var path = "/api/v1/{network}/{coin}/tx/id/{txId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "txId" + "}", ApiClient.ParameterToString(txId));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxIdTxIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxIdTxIdGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TransactionModel) ApiClient.Deserialize(response.Content, typeof(TransactionModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>TransactionResponse</returns>
        public TransactionResponse ApiV1NetworkCoinTxRawPost (string coin, string network, TransactionRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxRawPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxRawPost");
    
            var path = "/api/v1/{network}/{coin}/tx/raw";
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
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxRawPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxRawPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TransactionResponse) ApiClient.Deserialize(response.Content, typeof(TransactionResponse), response.Headers);
        }
    
    }
}
