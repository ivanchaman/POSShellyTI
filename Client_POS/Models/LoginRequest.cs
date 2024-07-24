namespace ShellyPOS.Models
{
    public class LoginRequest<T> : GraphQLRequest
    {
        public T Variables { get; set; }

        public LoginRequest()
        {
            NamedQuery = "query";
            OperationName = "getLogin";
            Query = "query ($user:String!,$password:String!,$company:Int!){\r\n     getLogin(user: $user, password:$password,company:$company){\r\n        token        \r\n        hasUserName                     \r\n        hasTwoFactor \r\n        status                     \r\n        termsServices{           \r\n            id\r\n            name\r\n            description\r\n            status\r\n            urlDocument                                         \r\n        }                 \r\n     }     \r\n }";
        }
    }
}
