using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PrismCore.Demo.Entity
{
    public class UserEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("UserName")]
        public string Username { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("UserIcon")]
        public string UserIcon { get; set; }
        [JsonProperty("RealName")]
        public string RealName { get; set; }

        public List<MenuEntity> Menus { get; set; }
    }
}
