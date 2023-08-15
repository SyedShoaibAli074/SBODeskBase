using Newtonsoft.Json;
using Serenity.ComponentModel;
using System.Collections.Generic;

namespace Serenity.Services
{
    public enum RetrieveColumnSelection
    {
        Details = 0,
        KeyOnly = 1,
        List = 2
    }

    public class RetrieveRequest : ServiceRequest, IIncludeExcludeColumns
    {
        public object EntityId { get; set; }
        public RetrieveColumnSelection ColumnSelection { get; set; }
        [JsonConverter(typeof(JsonStringHashSetConverter))]
        public HashSet<string> IncludeColumns { get; set; }
        [JsonConverter(typeof(JsonStringHashSetConverter))]
        public HashSet<string> ExcludeColumns { get; set; }
        [Hidden]
        public string CompanyName { get; set; }
    }
}