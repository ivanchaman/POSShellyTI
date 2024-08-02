namespace Shelly.GraphQLShared.Services
{
     public class HttpGraphQLClientService : IHttpGraphQLClientService
    {
        private HttpClient _httpClient;
        private IDataEncryptionService _EncryptionService;

        public HttpGraphQLClientService(HttpClient httpClient, IDataEncryptionService encryptionService)
        {
            _httpClient = httpClient;
            _EncryptionService = encryptionService;
        }

        public async Task<GenericResponse<Response>> Get<Response, Request>(GraphQLRequest data)
        {
            CreateRequest<Request>(data);
            var response = await ExecRequest<GenericResponse<Response>, GenericResponse<Response>>($"exec_d", HttpMethodTypes.GET);
            if (response.Status)
                return response.Data;
            return response.Errors;
        }

        public async Task<GenericResponse<Response>> Post<Response, Request>(GraphQLRequest data)
        {
            CreateRequest<Request>(data);
            var response = await ExecRequest<GenericResponse<Response>, GenericResponse<Response>>($"exec_d", HttpMethodTypes.POST);
            if (response.Status)
                return response.Data;
            return response.Errors;
        }


        // helper methods

        private void CreateRequest<Request>(GraphQLRequest query)
        {
            try
            {
                string dataquery = query.ConvertObjectToJson();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(dataquery);
                string base64 = Convert.ToBase64String(bytes);
                string orderString = "";
                _httpClient.DefaultRequestHeaders.Clear();
                Random random = new Random();
                while (base64.Length > 100)
                {
                    var name = random.Next(1000000000, Int32.MaxValue);
                    _httpClient.DefaultRequestHeaders.Add($"{name}", _EncryptionService.Encrypted(base64.Substring(0, 100)));
                    orderString += $"{name}|";
                    base64 = base64.Substring(100, base64.Length - 100);
                }
                if (base64.Length != 0)
                {
                    var name = random.Next(1000000000, Int32.MaxValue);
                    _httpClient.DefaultRequestHeaders.Add($"{name}", _EncryptionService.Encrypted(base64));
                    orderString += $"{name}|";
                }
                int count = 0;
                while (orderString.Length > 100)
                {
                    var name = random.Next(1000000000, Int32.MaxValue);
                    _httpClient.DefaultRequestHeaders.Add($"exec-hash-{count}", _EncryptionService.Encrypted(orderString.Substring(0, 100)));
                    orderString = orderString.Substring(100, orderString.Length - 100);
                    count++;
                }
                if (orderString.Length != 0)
                {
                    var name = random.Next(1000000000, Int32.MaxValue);
                    _httpClient.DefaultRequestHeaders.Add($"exec-hash-{count}", _EncryptionService.Encrypted(orderString));                    
                }
                _httpClient.DefaultRequestHeaders.Add($"hash-id", $"{_EncryptionService.Encrypted(random.Next(1000000000, Int32.MaxValue).ToString())}");
                _httpClient.DefaultRequestHeaders.Add($"content-hash", $"{_EncryptionService.Encrypted($"POS|{DateTime.Now.ToUniversalTime().Ticks}")}");
            }
            catch
            {

            }
        }

        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, FormUrlEncodedContent data, HttpMethodTypes httpMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, data, httpMethod);
        }
        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, Dictionary<string, string> data, HttpMethodTypes httpMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, new FormUrlEncodedContent(data), httpMethod);
        }
        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, MultipartFormDataContent data, HttpMethodTypes httpMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, data, httpMethod);
        }

        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, string objRequest)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, objRequest != null ? new StringContent(objRequest, Encoding.UTF8, "application/json") : null, HttpMethodTypes.GET);
        }

        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, null, HttpMethodTypes.GET);
        }

        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, string objRequest, HttpMethodTypes httpMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, objRequest != null ? new StringContent(objRequest, Encoding.UTF8, "application/json") : null, httpMethod);
        }

        public async Task<DataResult<TSuccess, TError>> ExecRequest<TSuccess, TError>(string uriPathMethod, HttpMethodTypes httpMethod)
        {
            return await HandleResponseAsync<TSuccess, TError>(uriPathMethod, null, httpMethod);
        }      

        private async Task<DataResult<TSuccess, TError>> HandleResponseAsync<TSuccess, TError>(string uriPathMethod, HttpContent objRequest, HttpMethodTypes httpMethod)
        {
            string uri = $"{_httpClient.BaseAddress.ToString().PathURLFormat()}{uriPathMethod}";
            switch (httpMethod)
            {
                case HttpMethodTypes.GET:
                case HttpMethodTypes.POST:
                case HttpMethodTypes.PUT:
                case HttpMethodTypes.DELETE:
                    if (objRequest == null)
                    {
                        _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        break;
                    }
                    switch (objRequest)
                    {
                        case FormUrlEncodedContent:
                            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                            break;
                        case MultipartFormDataContent:
                            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("multipart/form-data"));
                            break;
                        case StringContent:
                            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            break;
                        default:
                            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            break;
                    }
                    break;
            }
            HttpResponseMessage? response = null;
            switch (httpMethod)
            {
                case HttpMethodTypes.SEND:
                    using (var request = new HttpRequestMessage())
                    {
                        // Construccion de la peticion (Request)
                        if (objRequest != null)
                        {
                            var json = JsonConvert.SerializeObject(objRequest);
                            request.Content = new StringContent(json);
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        }
                        request.Method = new HttpMethod(HttpMethodTypes.GET.ToString());
                        request.RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute);
                        request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                        response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                    }
                    break;
                case HttpMethodTypes.GET:
                    response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                    break;
                case HttpMethodTypes.POST:
                    response = await _httpClient.PostAsync(uri, objRequest);
                    break;
                case HttpMethodTypes.PUT:
                    response = await _httpClient.PutAsync(uri, objRequest);
                    break;
                case HttpMethodTypes.DELETE:
                    response = await _httpClient.DeleteAsync(uri);
                    break;
            }

            // auto logout on 401 response
            string? result = response?.Content.ReadAsStringAsync().Result;
            switch (response?.StatusCode)
            {
                case HttpStatusCode.OK: //201
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                    return DataResult<TSuccess, TError>.Success(result);
                case HttpStatusCode.Unauthorized: //401
                    return DataResult<TSuccess, TError>.Unauthorized(result);
                case HttpStatusCode.BadRequest: //400
                    return DataResult<TSuccess, TError>.BadRequest(result);
                case HttpStatusCode.InternalServerError: //500
                    return DataResult<TSuccess, TError>.InternalServerError(result);
                case HttpStatusCode.ServiceUnavailable: //500
                    return DataResult<TSuccess, TError>.ServiceUnavailable(result);
                default:
                    return DataResult<TSuccess, TError>.Fail(response?.StatusCode.ToString(), result);
            }

        }


    }
}
