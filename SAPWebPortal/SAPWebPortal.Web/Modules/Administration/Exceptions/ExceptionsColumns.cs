using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.Exceptions")]
    [BasedOnRow(typeof(ExceptionsRow), CheckNames = true)]
    public class ExceptionsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 Id { get; set; }
        [EditLink]
        public String ApplicationName { get; set; }
        [Width(200)]
        public DateTime CreationDate { get; set; }
        public String Source { get; set; }
        public String Message { get; set; }
        public Int32 DuplicateCount { get; set; }

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public long Id { get; set; }
        //public Guid Guid { get; set; }
        //[EditLink]
        //public string ApplicationName { get; set; }
        //public string MachineName { get; set; }
        //public DateTime CreationDate { get; set; }
        //public string Type { get; set; }
        //public bool IsProtected { get; set; }
        //public string Host { get; set; }
        //public string Url { get; set; }
        //public string HttpMethod { get; set; }
        //public string IpAddress { get; set; }
        //public string Source { get; set; }
        //public string Message { get; set; }
        //public string Detail { get; set; }
        //public int StatusCode { get; set; }
        //public string Sql { get; set; }
        //public DateTime DeletionDate { get; set; }
        //public string FullJson { get; set; }
        //public int ErrorHash { get; set; }
        //public int DuplicateCount { get; set; }
    }
}