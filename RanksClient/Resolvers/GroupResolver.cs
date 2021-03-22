using GraphQL;
using GraphQL.Client.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using RanksClient.Models;

namespace RanksClient.Resolvers
{
    public class GroupResolver : ResolverBase
    {
        public GroupResolver(GraphQLHttpClient client_URL) : base(client_URL) { }

        protected override GraphQLRequest QueryString
        {
            get => new GraphQLRequest
            {
                Query = @"{Groups{id,name,about,picture,Users{id,name,secname,about,picture}}}"
            };
        }
        //protected override GraphQLRequest QueryGetImage => throw new System.NotImplementedException();
        //{
        //    get => new GraphQLRequest
        //    {
        //        Query = @"{Groups{id,name,about,picture,Users{id,name,secname,about,picture}}}"
        //    };
        //}
        protected override GraphQLRequest MutationStringCreate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($group: GroupInput){AddGroup(Group: $group){name,id,picture,about}}"
            };
        }
        protected override GraphQLRequest MutationStringUpdate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($group: GroupUpdateInput){UpdateGroup(Group: $group){name,id,picture,about}}"
            };
        }
        protected override GraphQLRequest QueryGetImage
        {
            get => new GraphQLRequest
            {
                Query = @""
            };


        }

        public async Task<List<Group>> GetAsync()
        {
            var response = await SendQuery(() => new { groups = new List<Group> { } });
            return (response.groups);
        }
        public async Task<GroupInputType> AddGroup(GroupInputType group)
        {
            var response = await Create(new { group = group }, () => new { AddGroup = new GroupInputType() });
            return (response.AddGroup);
        }
        public async Task<GroupInputType> UpdateGroup(GroupType group)
        {
            var response = await Update(new { group = group }, () => new { UpdateGroup = new GroupInputType() });
            return (response.UpdateGroup);
        }
    }
    public class GroupInputType : GroupBase
    {

    }
    public class GroupType : GroupBase
    {
        public string id { get; set; }
    }
    abstract public class GroupBase
    {
        public string name { get; set; }
        public string picture { get; set; }
        public string about { get; set; }
        public List<UserInputTypeWithId> Users { get; set; }
    }

}
