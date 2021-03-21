using GraphQL;
using GraphQL.Client.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RanksClient.Models;


namespace RanksClient.Resolvers
{
    public class RankResolver : ResolverBase
    {
        public RankResolver(GraphQLHttpClient client_URL) : base(client_URL) { }
        protected override GraphQLRequest QueryString
        {
            get => new GraphQLRequest
            {
                Query = @"{Ranks{id,name,picture}}"
            };
        }
        protected override GraphQLRequest MutationStringCreate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($rank: rankInput){AddRank(Rank: $rank){name,id,picture}}"
            };
        }
        protected override GraphQLRequest MutationStringUpdate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($rank: rankUpdateInput){UpdateRank(Rank: $rank){name,id,picture}}"
            };
        }

        public async Task<List<Rank>> GetRanks()
        {
            var response = await GetList(() => new { Ranks = new List<Rank> { } });
            return (response.Ranks);
        }
        public async Task<RankInputType> AddRank(RankInputType rank)
        {
            var response = await Create(new { rank = rank }, () => new { AddRank = new RankType() });
            return (response.AddRank);
        }
        public async Task<RankType> UpdateRank(RankType rank)
        {
            var response = await Update(new { rank = rank }, () => new { UpdateRank = new RankType() });
            return (response.UpdateRank);
        }

    }
    public class RankType : RankInputType
    {
        public string id { get; set; }
    }
    public class RankInputType
    {
        public string name { get; set; }
        public string picture { get; set; } 
    }
}
