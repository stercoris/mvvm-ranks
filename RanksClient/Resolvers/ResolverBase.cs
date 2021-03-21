using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using System.Threading.Tasks;
using System;
using GraphQL.Client.Serializer.Newtonsoft;

namespace RanksClient.Resolvers
{
    public abstract class ResolverBase
    {
        public ResolverBase(GraphQLHttpClient client_URL)
        {
            this.GraphQLClient = client_URL;
        }
        protected GraphQLHttpClient GraphQLClient { get; set; }

        //protected GraphQLHttpClient GraphQLClient { get => new GraphQLHttpClient("http://localhost:8000/graph", new NewtonsoftJsonSerializer()); }

        protected abstract GraphQLRequest QueryString { get; }
        //protected abstract GraphQLRequest QueryGetImage { get; }
        protected abstract GraphQLRequest MutationStringCreate { get; }
        protected abstract GraphQLRequest MutationStringUpdate { get; }

        //protected async Task<Response> GetImage<Response>(Func<Response> defineResponseType)
        //{
        //    var response = await GraphQLClient.SendQueryAsync(QueryString, defineResponseType);
        //    return (response.Data);
        //}

        protected async Task<Response> GetList<Response>(Func<Response> defineResponseType)
        {
            var response = await GraphQLClient.SendQueryAsync(QueryString, defineResponseType);
            return (response.Data);
        }

        protected async Task<Response> Create<Response>(object variable, Func<Response> defineResponseType)
        {
            GraphQLRequest add_request = MutationStringCreate;
            add_request.Variables = variable;
            var response = await GraphQLClient.SendQueryAsync(add_request, defineResponseType);
            return (response.Data);
        }

        protected async Task<Response> Update<Response>(object variable, Func<Response> defineResponseType)
        {
            GraphQLRequest Update_request = MutationStringUpdate;
            Update_request.Variables = variable;
            var response = await GraphQLClient.SendQueryAsync(Update_request, defineResponseType);

            return (response.Data);

        }
    }
}