using System;
using System.Collections;
using System.Collections.Generic;

namespace Serenity.Services
{
    public class ListResponse<T> : ServiceResponse, IListResponse 
    {
        IList IListResponse.Entities => Entities;
    public string UserName {get;set;}
        public string DBName {get;set;}
        public string ModuleName {get;set;}
        public List<T> Entities { get; set; }
        public List<object> Values { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        private DateTime _datetime;
        public bool isExpired {
            
                // if _datetime is older than 30 seconds, return true
                get { return DateTime.Now.Subtract(_datetime).TotalSeconds > 60; }
            
        } 
        public ListResponse()
        {
            _datetime = DateTime.Now;
        }
        public bool Refresh { get; set; }
        public ListResponse<T> Clone()
        {
            ListResponse<T> clone = new ListResponse<T>();
            //make a copy of this.Entities
            clone.Entities = new List<T>(this.Entities); 
            clone.Values = this.Values;
            clone.TotalCount = this.TotalCount;
            clone.Skip = this.Skip;
            clone.Take = this.Take;
            return clone;
        }
    }
}