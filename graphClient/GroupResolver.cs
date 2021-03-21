using GraphQL;
using GraphQL.Client.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ranksClient
{
    public class GroupResolver : ResolverBase
    {
        public GroupResolver(string client_URL) : base(client_URL) { }

        protected override GraphQLRequest QueryString
        {
            get => new GraphQLRequest
            {
                Query = @"{Groups{id,name,about,Users{id,name,secname,about,}}}"
            };
        }
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

        public async Task<List<GroupInputType>> GetAsync()
        {
            var response = await GetList(() => new { groups = new List<GroupInputType> { } });
            return (response.groups);
        }
        public async Task<GroupInputType> AddGroup(GroupInputType group)
        {
            var response = await Create(new { group = group}, () => new { AddGroup = new GroupInputType() });
            return (response.AddGroup);
        }
        public async Task<GroupInputType> UpdateGroup(GroupType group)
        {
            var response = await Update(new { group = group }, () => new { UpdateGroup = new GroupInputType() });
            return (response.UpdateGroup);
        }
    }
    public class GroupInputType: Group
    {

    }
    public class GroupType : Group
    {
        public string id { get; set; }

    }
    abstract public class Group
    {
        public string name { get; set; }
        public string picture { get; set; }
        public string about { get; set; }
        public List<UserInputTypeWithId> Users { get; set; }
    }

}
