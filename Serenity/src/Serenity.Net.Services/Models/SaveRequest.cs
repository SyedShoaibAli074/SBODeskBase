
using System.Collections;
using System.Collections.Generic;

namespace Serenity.Services
{
    public interface ISaveRequest
    {
        object EntityId { get; set; }
        object Entity { get; set; }
        object DBName { get; set; }
        IDictionary Localizations { get; set; }
    }

    public class SaveRequest<TEntity> : ServiceRequest, ISaveRequest
    {
        public object EntityId { get; set; }
        public TEntity Entity { get; set; }
        public string DBName { get; set; }
        public Dictionary<string, TEntity> Localizations { get; set; }

        object ISaveRequest.Entity
        {
            get { return Entity; }
            set { Entity = (TEntity)value; }
        }

        IDictionary ISaveRequest.Localizations
        {
            get { return Localizations; }
            set { Localizations = (Dictionary<string, TEntity>)value; }
        }
        public bool ReplaceCollectionsOnPatch { get; set; }
        object ISaveRequest.DBName
        {
            get { return DBName; }
            set { DBName = (string)value; }
        }
    }
}
