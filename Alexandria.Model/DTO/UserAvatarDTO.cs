using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class UserAvatarDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        
        [JsonProperty("avatarid")]
        public Guid? AvatarId { get; set; }
        public virtual Avatar Avatar { get; set; }
    }
}
