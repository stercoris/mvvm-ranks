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
    public class API
    {
        public GraphQLHttpClient graphQLClient;

        public API(string Url)
        {
            this.graphQLClient = new GraphQLHttpClient(Url, new NewtonsoftJsonSerializer(new JsonSerializerSettings()));
        }

    }
}
