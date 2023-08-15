using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.Exceptions")]
    [BasedOnRow(typeof(ExceptionsRow), CheckNames = true)]
    public class ExceptionsForm
    {
        //    public Guid Guid { get; set; }
        //    public string ApplicationName { get; set; }
        //    public string MachineName { get; set; }
        //    public DateTime CreationDate { get; set; }
        //    public string Type { get; set; }
        //    public bool IsProtected { get; set; }
        //    public string Host { get; set; }
        //    public string Url { get; set; }
        //    public string HttpMethod { get; set; }
        //    public string IpAddress { get; set; }
        //    public string Source { get; set; }
        //    public string Message { get; set; }
        //    public string Detail { get; set; }
        //    public int StatusCode { get; set; }
        //    public string Sql { get; set; }
        //    public DateTime DeletionDate { get; set; }
        //    public string FullJson { get; set; }
        //    public int ErrorHash { get; set; }
        //    public int DuplicateCount { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Guid Guid { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String ApplicationName { get; set; }
        //public String MachineName { get; set; }
        [HalfWidth, ReadOnly(true)]
        public DateTime CreationDate { get; set; }
        //public String Type { get; set; }
        //public Boolean IsProtected { get; set; }
        //public String Host { get; set; }
        //public String Url { get; set; }
        //public String HttpMethod { get; set; }
        //public String IpAddress { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String Source { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Int32 DuplicateCount { get; set; }
        [FullWidth, TextAreaEditor, ReadOnly(true)]
        public String Message { get; set; }
        [FullWidth, TextAreaEditor, ReadOnly(true)]
        public String Detail { get; set; }
        //public Int32 StatusCode { get; set; }
        //public String Sql { get; set; }
        //public DateTime DeletionDate { get; set; }
        //public String FullJson { get; set; }
        //public Int32 ErrorHash { get; set; }
    }
}