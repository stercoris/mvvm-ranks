using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace RanksApi {

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
            about
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
          
          [JsonProperty("about")]
          public string about { get; set; }
          
          [JsonProperty("picture")]
          public string picture { get; set; }
          
        }
        
        [JsonProperty("Groups")]
        public System.Collections.Generic.List<GroupSelection> Groups { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    

    public class IGetGroupImageGQL {
      /// <summary>
      /// IGetGroupImageGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetGroupImageDocument,
          OperationName = "GetGroupImage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetGroupImageGQL() {
        return Request();
      }
      
      public static string GetGroupImageDocument = @"
        query GetGroupImage($id: Int!) {
          Group(id: $id) {
            picture
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class GroupSelection {
        
          [JsonProperty("picture")]
          public string picture { get; set; }
          
        }
        
        [JsonProperty("Group")]
        public GroupSelection Group { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class IGetGroupGQL {
      /// <summary>
      /// IGetGroupGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetGroupDocument,
          OperationName = "GetGroup",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetGroupGQL() {
        return Request();
      }
      
      public static string GetGroupDocument = @"
        query GetGroup($id: Int!) {
          Group(id: $id) {
            users {
              id
              rankId
              name
              secname
              picture
              about
            }
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class GroupSelection {
        
          public class UserSelection {
          
            [JsonProperty("id")]
            public int id { get; set; }
            
            [JsonProperty("rankId")]
            public string rankId { get; set; }
            
            [JsonProperty("name")]
            public string name { get; set; }
            
            [JsonProperty("secname")]
            public string secname { get; set; }
            
            [JsonProperty("picture")]
            public string picture { get; set; }
            
            [JsonProperty("about")]
            public string about { get; set; }
            
          }
          
          [JsonProperty("users")]
          public System.Collections.Generic.List<UserSelection> users { get; set; }
          
        }
        
        [JsonProperty("Group")]
        public GroupSelection Group { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class IGetUserImageGQL {
      /// <summary>
      /// IGetUserImageGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetUserImageDocument,
          OperationName = "GetUserImage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getIGetUserImageGQL() {
        return Request();
      }
      
      public static string GetUserImageDocument = @"
        query GetUserImage($id: Int!) {
          User(id: $id) {
            picture
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class UserSelection {
        
          [JsonProperty("picture")]
          public string picture { get; set; }
          
        }
        
        [JsonProperty("User")]
        public UserSelection User { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
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