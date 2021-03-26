using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;

namespace RanksClient
{
    static public class API
    {
        public static GraphQLHttpClient _client;

        public static GraphQLHttpClient Client
        {
            get {
                if (_client == null)
                    _client = new GraphQLHttpClient("http://localhost:8000/graphql", new NewtonsoftJsonSerializer(new JsonSerializerSettings()));
                return _client;
            }
        }

    }
}
