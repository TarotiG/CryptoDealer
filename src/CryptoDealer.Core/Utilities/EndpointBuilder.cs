using System.Web;

namespace CryptoDealer.Core.Utilities
{
    public class EndpointBuilder : UriBuilder
    {
        public string _Uri;
        public EndpointBuilder(string endpoint, Dictionary<string, object?> parameters)
        {
            _Uri = BuildQueryString(endpoint, parameters);
        }

        public string BuildQueryString(string endpoint, Dictionary<string, object?> parameters)
        {
            var builder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var param in parameters)
            {
                if (param.Key != null)
                {
                    query[param.Key] = param.Value.ToString();
                }
            }

            builder.Path = endpoint;
            builder.Query = query.ToString();
            return builder.Query;
        }

        public static Dictionary<string, object?> ToDictionary(object values)
        {
            return values.GetType()
                         .GetProperties()
                         .Where(p => p.GetValue(values) != null)
                         .ToDictionary(p => p.Name, p => p.GetValue(values));
        }
    }
}
