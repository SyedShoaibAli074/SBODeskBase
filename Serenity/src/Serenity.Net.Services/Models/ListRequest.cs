﻿using Newtonsoft.Json;
using Serenity.Data;
using System;
using System.Collections.Generic;

namespace Serenity.Services
{
    public class ListRequest : ServiceRequest, IIncludeExcludeColumns
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public SortBy[] Sort { get; set; }
        public string ContainsText { get; set; }
        public string ContainsField { get; set; }
        [JsonConverter(typeof(JsonSafeCriteriaConverter))]
        public BaseCriteria Criteria { get; set; }
        public bool IncludeDeleted { get; set; }
        public bool ExcludeTotalCount { get; set; }
        public Dictionary<string, object> EqualityFilter { get; set; }
        public ColumnSelection ColumnSelection { get; set; }
        [JsonConverter(typeof(JsonStringHashSetConverter))]
        public HashSet<string> IncludeColumns { get; set; }
        [JsonConverter(typeof(JsonStringHashSetConverter))]
        public HashSet<string> ExcludeColumns { get; set; }
        public SortBy[] DistinctFields { get; set; }

        /// <summary>
        /// Gets or sets the set of columns to export. 
        /// This should only be used to specify list of columns
        /// for contexts like Excel export etc.
        /// </summary>
        /// <value>
        /// The columns to export.
        /// </value>
        public System.Collections.Generic.List<string> ExportColumns { get; set; }
        public bool RefreshButtonClicked { get; set; }
        public DataSourceType DataSourceType { get; set; }
        public String? CompanyDB { get; set; }
    }
    public enum DataSourceType
    {
        SAPServiceLayer,
        SAP_DataBase
    }
}