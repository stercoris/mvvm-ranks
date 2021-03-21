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
using RanksClient.Resolvers;

namespace RanksClient
{
    public class API
    {
        private GraphQLHttpClient graphQLClient;
        public GroupResolver GroupResolver { get; private set; }
        public UserResolver UserResolver { get; private set; }
        public RankResolver RankResolver { get; private set; }

        public API(string Url)
        {
            this.graphQLClient = new GraphQLHttpClient(Url, new NewtonsoftJsonSerializer(new JsonSerializerSettings()));
            GroupResolver = new GroupResolver(graphQLClient);
            UserResolver = new UserResolver(graphQLClient);
            RankResolver = new RankResolver(graphQLClient);
        }

    }
}
