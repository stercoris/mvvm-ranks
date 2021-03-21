using GraphQL;
using GraphQL.Client.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RanksClient.Resolvers
{
    public class UserResolver : ResolverBase
    {
        public UserResolver(GraphQLHttpClient client_URL) : base(client_URL) { }
        protected override GraphQLRequest QueryString
        {
            get => new GraphQLRequest
            {
                Query = @"{Users{name,secname,picture,groupId,rankId,about}}"
            };
        }
        protected override GraphQLRequest MutationStringCreate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($user: UserInput){AddUser(User: $user){
                        id,name,secname,groupId,rankId,isAdmin,password,picture,about}}"
            };
        }
        protected override GraphQLRequest MutationStringUpdate
        {
            get => new GraphQLRequest
            {
                Query = @"mutation($user: UserInput){UpdateUser(User: $user){
                        id,name,secname,groupId,rankId,isAdmin,password,picture,about}}"
            };
        }

        public async Task<List<UserInputType>> GetUsers()
        {
            var response = await GetList(() => new { Users = new List<UserInputType> { } });
            return (response.Users);
        }
        public async Task<UserInputTypeWithId> AddUser(UserInputType user)
        {
            var response = await Create(new { user = user }, () => new { AddUser = new UserInputTypeWithId() });
            return (response.AddUser);
        }
        public async Task<UserInputType> UpdateUser(UserInputTypeWithId user)
        {
            var response = await Update(new { user = user }, () => new { UpdateUser = new UserInputType() });
            return (response.UpdateUser);
        }
    }
    public class BigUserType : UserBase
    {
        public GroupType groupInfo { get; set; }
        public RankType rankInfo { get; set; }
    }
    public class UserInputType : UserBase
    {
        public string groupId { get; set; }
        public string rankId { get; set; }
    }
    public class UserInputTypeWithId : UserBase
    {

        public string id { get; set; }
        public string groupId { get; set; }
        public string rankId { get; set; }
    }
    public class UserBase
    {
        public string name { get; set; }
        public string secname { get; set; }
        public string isAdmin { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
        public string about { get; set; }
    }

}