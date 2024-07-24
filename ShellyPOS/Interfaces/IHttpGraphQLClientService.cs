﻿using ShellyPOS.Models;

namespace ShellyPOS.Interfaces
{
    public interface IHttpGraphQLClientService
    {
        Task<GenericResponse<Response>> Get<Response, Request>(GraphQLRequest data);
        Task<GenericResponse<Response>> Post<Response, Request>(GraphQLRequest data);
    }
}
