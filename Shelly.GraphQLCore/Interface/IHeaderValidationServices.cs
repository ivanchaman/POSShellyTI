namespace Shelly.GraphQLCore.Interface
{
    public interface IHeaderValidationServices
    {
        public bool IsHeaderValid(out GraphQLQuery query, out LoginInfo? loginInfo, out string error, out string additionalMessage);
        public bool IsHeaderValid(out LoginInfo? loginInfo, out string error);
        public bool IsHeaderValid(out GraphQLQuery query, out string error, out string additionalMessage);

       
    }
}
