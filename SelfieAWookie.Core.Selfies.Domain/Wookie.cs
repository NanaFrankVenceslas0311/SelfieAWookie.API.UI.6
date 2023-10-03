using SelfieAWookie.API.UI._6;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Wookie
    {
        #region Properties
        public int Id { get; set; }

       // [JsonIgnore] // Empêche de resérializer les Selfies des Wookies
       public List<Selfie>Selfies { get; set; }
        #endregion

    }
}
