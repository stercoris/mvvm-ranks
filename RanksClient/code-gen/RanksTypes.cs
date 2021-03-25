using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace RanksApi {
  public class Ranks {
    
    #region Group
    public class Group {
      #region members
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("users")]
      public IEnumberable<User> users { get; set; }
    
      [JsonProperty("picture")]
      public string picture { get; set; }
    
      [JsonProperty("about")]
      public string about { get; set; }
      #endregion
    }
    #endregion
    
    #region Mutation
    public class Mutation {
      #region members
      [JsonProperty("AddGroup")]
      public Group AddGroup { get; set; }
    
      [JsonProperty("DeleteGroup")]
      public bool DeleteGroup { get; set; }
    
      [JsonProperty("UpdateGroup")]
      public bool UpdateGroup { get; set; }
    
      [JsonProperty("AddRank")]
      public Rank AddRank { get; set; }
    
      [JsonProperty("DeleteRank")]
      public bool DeleteRank { get; set; }
    
      [JsonProperty("UpdateRank")]
      public bool UpdateRank { get; set; }
    
      [JsonProperty("AddUser")]
      public User AddUser { get; set; }
    
      [JsonProperty("DeleteUser")]
      public bool DeleteUser { get; set; }
    
      [JsonProperty("UpdateUser")]
      public bool UpdateUser { get; set; }
      #endregion
    }
    #endregion
    
    #region INewGroup
    public class INewGroup {
      #region members
      [JsonRequired]
      public string name { get; set; }
    
      public string picture { get; set; }
    
      public string about { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region INewRank
    public class INewRank {
      #region members
      [JsonRequired]
      public string name { get; set; }
    
      public string picture { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region INewUser
    public class INewUser {
      #region members
      public string rank { get; set; }
    
      public string group { get; set; }
    
      [JsonRequired]
      public string name { get; set; }
    
      public string secname { get; set; }
    
      public string picture { get; set; }
    
      public string about { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region Query
    public class Query {
      #region members
      [JsonProperty("Group")]
      public Group Group { get; set; }
    
      [JsonProperty("Groups")]
      public IEnumberable<Group> Groups { get; set; }
    
      [JsonProperty("Rank")]
      public Rank Rank { get; set; }
    
      [JsonProperty("Ranks")]
      public IEnumberable<Rank> Ranks { get; set; }
    
      [JsonProperty("User")]
      public User User { get; set; }
    
      [JsonProperty("Users")]
      public IEnumberable<User> Users { get; set; }
      #endregion
    }
    #endregion
    
    #region Rank
    public class Rank {
      #region members
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("picture")]
      public string picture { get; set; }
      #endregion
    }
    #endregion
    
    #region IUpdateGroup
    public class IUpdateGroup {
      #region members
      public string name { get; set; }
    
      public string picture { get; set; }
    
      public string about { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region IUpdateRank
    public class IUpdateRank {
      #region members
      public string name { get; set; }
    
      public string picture { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region IUpdateUser
    public class IUpdateUser {
      #region members
      public int? rankId { get; set; }
    
      public int? groupId { get; set; }
    
      public string name { get; set; }
    
      public string secname { get; set; }
    
      public string picture { get; set; }
    
      public string about { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region User
    public class User {
      #region members
      [JsonProperty("id")]
      public int id { get; set; }
    
      [JsonProperty("rankId")]
      public string rankId { get; set; }
    
      [JsonProperty("groupId")]
      public string groupId { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("secname")]
      public string secname { get; set; }
    
      [JsonProperty("picture")]
      public string picture { get; set; }
    
      [JsonProperty("about")]
      public string about { get; set; }
      #endregion
    }
    #endregion
  }
  
}
