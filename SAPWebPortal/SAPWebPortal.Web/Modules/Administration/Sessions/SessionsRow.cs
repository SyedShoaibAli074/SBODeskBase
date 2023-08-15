using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Sessions]")]
    [DisplayName("Sessions"), InstanceName("Sessions")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class SessionsRow : Row<SessionsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int64? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Session Id"), Column("SessionID"), Size(255), NotNull, QuickSearch, NameProperty]
        public String SessionId
        {
            get => fields.SessionId[this];
            set => fields.SessionId[this] = value;
        }
        [DisplayName("Portal Session Id"), Column("PortalSessionID"), Size(255), NotNull, QuickSearch]
        public String PortalSessionID
        {
            get => fields.PortalSessionID[this];
            set => fields.PortalSessionID[this] = value;
        }

        [DisplayName("User Name"), Size(255), NotNull]
        public String UserName
        {
            get => fields.UserName[this];
            set => fields.UserName[this] = value;
        }

        [DisplayName("Date Time Stamp"), DefaultValue("now"), Size(255), NotNull]
        public DateTime? DateTimeStamp
        {
            get => fields.DateTimeStamp[this];
            set => fields.DateTimeStamp[this] = value;
        }

        public SessionsRow()
            : base()
        {
        }

        public SessionsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public StringField SessionId;
            public StringField PortalSessionID;
            public StringField UserName;
            public DateTimeField DateTimeStamp;
        }
    }
}
