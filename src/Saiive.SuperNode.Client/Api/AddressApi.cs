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
    public interface IAddressApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>List&lt;AccountModel&gt;</returns>
        List<AccountModel> ApiV1NetworkCoinAccountAddressGet (string coin, string network, string address);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;Account&gt;</returns>
        List<Account> ApiV1NetworkCoinAccountsPost (string coin, string network, AddressesBodyRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>BalanceModel</returns>
        BalanceModel ApiV1NetworkCoinBalanceAddressGet (string coin, string network, string address);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>BalanceModel</returns>
        BalanceModel ApiV1NetworkCoinBalanceAllAddressGet (string coin, string network, string address);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>Dictionary&lt;string, AccountModel&gt;</returns>
        Dictionary<string, AccountModel> ApiV1NetworkCoinBalanceAllPost (string coin, string network, AddressesBodyRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;BalanceModel&gt;</returns>
        List<BalanceModel> ApiV1NetworkCoinBalancesPost (string coin, string network, AddressesBodyRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>FeeEstimateModel</returns>
        FeeEstimateModel ApiV1NetworkCoinFeeGet (string coin, string network);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<TransactionModel> ApiV1NetworkCoinTxsAddressGet (string coin, string network, string address);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<TransactionModel> ApiV1NetworkCoinTxsPost (string coin, string network, AddressesBodyRequest body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<TransactionModel> ApiV1NetworkCoinUnspentAddressGet (string coin, string network, string address);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        List<TransactionModel> ApiV1NetworkCoinUnspentPost (string coin, string network, AddressesBodyRequest body);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AddressApi : IAddressApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AddressApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AddressApi(String basePath)
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
        /// <returns>List&lt;AccountModel&gt;</returns>
        public List<AccountModel> ApiV1NetworkCoinAccountAddressGet (string coin, string network, string address)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinAccountAddressGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinAccountAddressGet");
            // verify the required parameter 'address' is set
            if (address == null) throw new Client.ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinAccountAddressGet");
    
            var path = "/api/v1/{network}/{coin}/account/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccountAddressGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccountAddressGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<AccountModel>) ApiClient.Deserialize(response.Content, typeof(List<AccountModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;Account&gt;</returns>
        public List<Account> ApiV1NetworkCoinAccountsPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinAccountsPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinAccountsPost");
    
            var path = "/api/v1/{network}/{coin}/accounts";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccountsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinAccountsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<Account>) ApiClient.Deserialize(response.Content, typeof(List<Account>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>BalanceModel</returns>
        public BalanceModel ApiV1NetworkCoinBalanceAddressGet (string coin, string network, string address)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinBalanceAddressGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinBalanceAddressGet");
            // verify the required parameter 'address' is set
            if (address == null) throw new Client.ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinBalanceAddressGet");
    
            var path = "/api/v1/{network}/{coin}/balance/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAddressGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAddressGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (BalanceModel) ApiClient.Deserialize(response.Content, typeof(BalanceModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>BalanceModel</returns>
        public BalanceModel ApiV1NetworkCoinBalanceAllAddressGet (string coin, string network, string address)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinBalanceAllAddressGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinBalanceAllAddressGet");
            // verify the required parameter 'address' is set
            if (address == null) throw new Client.ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinBalanceAllAddressGet");
    
            var path = "/api/v1/{network}/{coin}/balance-all/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAllAddressGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAllAddressGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (BalanceModel) ApiClient.Deserialize(response.Content, typeof(BalanceModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>Dictionary&lt;string, AccountModel&gt;</returns>
        public Dictionary<string, AccountModel> ApiV1NetworkCoinBalanceAllPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinBalanceAllPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinBalanceAllPost");
    
            var path = "/api/v1/{network}/{coin}/balance-all";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAllPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalanceAllPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Dictionary<string, AccountModel>) ApiClient.Deserialize(response.Content, typeof(Dictionary<string, AccountModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;BalanceModel&gt;</returns>
        public List<BalanceModel> ApiV1NetworkCoinBalancesPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinBalancesPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinBalancesPost");
    
            var path = "/api/v1/{network}/{coin}/balances";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalancesPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinBalancesPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<BalanceModel>) ApiClient.Deserialize(response.Content, typeof(List<BalanceModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <returns>FeeEstimateModel</returns>
        public FeeEstimateModel ApiV1NetworkCoinFeeGet (string coin, string network)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinFeeGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinFeeGet");
    
            var path = "/api/v1/{network}/{coin}/fee";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinFeeGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinFeeGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FeeEstimateModel) ApiClient.Deserialize(response.Content, typeof(FeeEstimateModel), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<TransactionModel> ApiV1NetworkCoinTxsAddressGet (string coin, string network, string address)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxsAddressGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxsAddressGet");
            // verify the required parameter 'address' is set
            if (address == null) throw new Client.ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinTxsAddressGet");
    
            var path = "/api/v1/{network}/{coin}/txs/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxsAddressGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxsAddressGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<TransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<TransactionModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<TransactionModel> ApiV1NetworkCoinTxsPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinTxsPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinTxsPost");
    
            var path = "/api/v1/{network}/{coin}/txs";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxsPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinTxsPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<TransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<TransactionModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="address"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<TransactionModel> ApiV1NetworkCoinUnspentAddressGet (string coin, string network, string address)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinUnspentAddressGet");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinUnspentAddressGet");
            // verify the required parameter 'address' is set
            if (address == null) throw new Client.ApiException(400, "Missing required parameter 'address' when calling ApiV1NetworkCoinUnspentAddressGet");
    
            var path = "/api/v1/{network}/{coin}/unspent/{address}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "coin" + "}", ApiClient.ParameterToString(coin));
path = path.Replace("{" + "network" + "}", ApiClient.ParameterToString(network));
path = path.Replace("{" + "address" + "}", ApiClient.ParameterToString(address));
    
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinUnspentAddressGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinUnspentAddressGet: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<TransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<TransactionModel>), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="network"></param>
        /// <param name="body"></param>
        /// <returns>List&lt;TransactionModel&gt;</returns>
        public List<TransactionModel> ApiV1NetworkCoinUnspentPost (string coin, string network, AddressesBodyRequest body)
        {
            // verify the required parameter 'coin' is set
            if (coin == null) throw new Client.ApiException(400, "Missing required parameter 'coin' when calling ApiV1NetworkCoinUnspentPost");
            // verify the required parameter 'network' is set
            if (network == null) throw new Client.ApiException(400, "Missing required parameter 'network' when calling ApiV1NetworkCoinUnspentPost");
    
            var path = "/api/v1/{network}/{coin}/unspent";
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
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinUnspentPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new Client.ApiException ((int)response.StatusCode, "Error calling ApiV1NetworkCoinUnspentPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<TransactionModel>) ApiClient.Deserialize(response.Content, typeof(List<TransactionModel>), response.Headers);
        }
    
    }
}
