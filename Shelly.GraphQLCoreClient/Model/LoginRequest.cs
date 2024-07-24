namespace Shelly.GraphQLCoreClient.Model
{
    public class LoginRequest<T> : GraphQLRequest
    {
        public T Variables { get; set; }

        public LoginRequest()
        {
            NamedQuery = "query";
            OperationName = "getLogin";
            Query = @"query ($user:String!,$password:String!,$company:Int!){
                         getLogin(user: $user, password:$password,company:$company){
                            token        
                            hasUserName                     
                            hasTwoFactor 
                            status                     
                            termsServices{           
                                id
                                name
                                description
                                status
                                urlDocument                                         
                            }                 
                         }     
                     }";
        }
    }
}
