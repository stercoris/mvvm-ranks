using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace RanksApi {

    public class IAddGroupGQL {
      /// <summary>
      /// IAddGroupGQL.Request 
      /// <para>Required variables:<br/> { group=(NewGroup) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddGroupDocument,
          OperationName = "AddGroup",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIAddGroupGQL() {
        return Request();
      }
      
      public static string AddGroupDocument = @"
        mutation AddGroup($group: NewGroup!) {
          AddGroup(newGroup: $group) {
            id
            name
            picture
            about
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("group")]
        public INewGroup group { get; set; }
        
      }
      
      public class Response {
      
        public class GroupSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
          [JsonProperty("about")]
          public string about { get; set; }
          
        }
        
        [JsonProperty("AddGroup")]
        public GroupSelection AddGroup { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class IUpdateGroupGQL {
      /// <summary>
      /// IUpdateGroupGQL.Request 
      /// <para>Required variables:<br/> { groupid=(int), group=(UpdateGroup) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = UpdateGroupDocument,
          OperationName = "UpdateGroup",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIUpdateGroupGQL() {
        return Request();
      }
      
      public static string UpdateGroupDocument = @"
        mutation UpdateGroup($groupid: Int!, $group: UpdateGroup!) {
          UpdateGroup(id: $groupid, updateGroup: $group)
        }
        ";
            
      public class Variables {
      
        [JsonProperty("groupid")]
        public int groupid { get; set; }
        
        [JsonProperty("group")]
        public IUpdateGroup group { get; set; }
        
      }
      
      public class Response {
      
        [JsonProperty("UpdateGroup")]
        public bool UpdateGroup { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class IDeleteGroupGQL {
      /// <summary>
      /// IDeleteGroupGQL.Request 
      /// <para>Required variables:<br/> { groupid=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteGroupDocument,
          OperationName = "DeleteGroup",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIDeleteGroupGQL() {
        return Request();
      }
      
      public static string DeleteGroupDocument = @"
        mutation DeleteGroup($groupid: Int!) {
          DeleteGroup(id: $groupid)
        }
        ";
            
      public class Variables {
      
        [JsonProperty("groupid")]
        public int groupid { get; set; }
        
      }
      
      public class Response {
      
        [JsonProperty("DeleteGroup")]
        public bool DeleteGroup { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class IGetGroupsAndUsersGQL {
      /// <summary>
      /// IGetGroupsAndUsersGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = GetGroupsAndUsersDocument,
          OperationName = "GetGroupsAndUsers"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetGroupsAndUsersGQL() {
        return Request();
      }
      
      public static string GetGroupsAndUsersDocument = @"
        query GetGroupsAndUsers {
          Groups {
            id
            name
            picture
            about
            users {
              id
              name
              secname
              about
              picture
              rankId
            }
          }
        }
        ";
            
      
      public class Response {
      
        public class GroupSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
          [JsonProperty("about")]
          public string about { get; set; }
          
          public class UserSelection {
          
            [JsonProperty("id")]
            public int id { get; set; }
            
            [JsonProperty("name")]
            public string name { get; set; }
            
            [JsonProperty("secname")]
            public string secname { get; set; }
            
            [JsonProperty("about")]
            public string about { get; set; }
            
            [JsonProperty("picture")]
            public string picture { get; set; }
            
            [JsonProperty("rankId")]
            public string rankId { get; set; }
            
          }
          
          [JsonProperty("users")]
          public System.Collections.Generic.List<UserSelection> users { get; set; }
          
        }
        
        [JsonProperty("Groups")]
        public System.Collections.Generic.List<GroupSelection> Groups { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    

    public class IGetGroupsGQL {
      /// <summary>
      /// IGetGroupsGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = GetGroupsDocument,
          OperationName = "GetGroups"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetGroupsGQL() {
        return Request();
      }
      
      public static string GetGroupsDocument = @"
        query GetGroups {
          Groups {
            id
            name
            picture
            about
          }
        }
        ";
            
      
      public class Response {
      
        public class GroupSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
          [JsonProperty("about")]
          public string about { get; set; }
          
        }
        
        [JsonProperty("Groups")]
        public System.Collections.Generic.List<GroupSelection> Groups { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    

    public class IGetGroupsAndUsersAndRanksGQL {
      /// <summary>
      /// IGetGroupsAndUsersAndRanksGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = GetGroupsAndUsersAndRanksDocument,
          OperationName = "GetGroupsAndUsersAndRanks"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetGroupsAndUsersAndRanksGQL() {
        return Request();
      }
      
      public static string GetGroupsAndUsersAndRanksDocument = @"
        query GetGroupsAndUsersAndRanks {
          Groups {
            id
            name
            picture
            about
            users {
              id
              name
              secname
              about
              picture
              rankId
            }
          }
          Ranks {
            id
            name
            picture
          }
        }
        ";
            
      
      public class Response {
      
        public class GroupSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
          [JsonProperty("about")]
          public string about { get; set; }
          
          public class UserSelection {
          
            [JsonProperty("id")]
            public int id { get; set; }
            
            [JsonProperty("name")]
            public string name { get; set; }
            
            [JsonProperty("secname")]
            public string secname { get; set; }
            
            [JsonProperty("about")]
            public string about { get; set; }
            
            [JsonProperty("picture")]
            public string picture { get; set; }
            
            [JsonProperty("rankId")]
            public string rankId { get; set; }
            
          }
          
          [JsonProperty("users")]
          public System.Collections.Generic.List<UserSelection> users { get; set; }
          
        }
        
        [JsonProperty("Groups")]
        public System.Collections.Generic.List<GroupSelection> Groups { get; set; }
        
        public class RankSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
        }
        
        [JsonProperty("Ranks")]
        public System.Collections.Generic.List<RankSelection> Ranks { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    
    public class INewGroup {
    
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
      [JsonProperty("about")]
      public string about { get; set; }
      
    }
    
    public class INewRank {
    
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
    }
    
    public class INewUser {
    
      [JsonProperty("rank")]
      public string rank { get; set; }
      
      [JsonProperty("group")]
      public string group { get; set; }
      
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("secname")]
      public string secname { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
      [JsonProperty("about")]
      public string about { get; set; }
      
    }
    
    public class IUpdateGroup {
    
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
      [JsonProperty("about")]
      public string about { get; set; }
      
    }
    
    public class IUpdateRank {
    
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
    }
    
    public class IUpdateUser {
    
      [JsonProperty("rankId")]
      public int? rankId { get; set; }
      
      [JsonProperty("groupId")]
      public int? groupId { get; set; }
      
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("secname")]
      public string secname { get; set; }
      
      [JsonProperty("picture")]
      public string picture { get; set; }
      
      [JsonProperty("about")]
      public string about { get; set; }
      
    }
    
}