using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CrystalReportsHelper
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var json = Environment.CommandLine;
                json = json.Split(new string[] { ".exe\" " }, StringSplitOptions.None)[1];
                var info = JsonConvert.DeserializeObject<JsonData>(json);
                info.pdfPath = HttpUtility.UrlDecode(info.pdfPath);
                info.rptPath = HttpUtility.UrlDecode(info.rptPath);
                getReportPath(info);
            }
            catch (Exception ex)
            { 
                EventLog.WriteEntry("Application", ex.Message+ex.StackTrace, EventLogEntryType.Error);
            }
          
        }
        public static string test()
        {
            return Path.GetTempFileName();
        }
        public static bool getFilePath(JsonData info)
        {
           

            var rd = new ReportDocument();
            rd.Load(info.rptPath);
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = info.ServerName;
            crConnectionInfo.DatabaseName = info.CompanyDB;
            crConnectionInfo.UserID = info.DBUserName;
            crConnectionInfo.Password = info.DBPassword;
            TableLogOnInfo crTableLogoninfo = new TableLogOnInfo();
            try
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in rd.Database.Tables)
                {
                    crTableLogoninfo = CrTable.LogOnInfo;
                    crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crTableLogoninfo);
                }
            }
            catch { }
            try
            {
                foreach (ReportDocument subreport in rd.Subreports)
                {
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                    {

                        crTableLogoninfo = CrTable.LogOnInfo;
                        crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                        CrTable.ApplyLogOnInfo(crTableLogoninfo);
                    }
                }
            }
            catch { }
            //int j = 0;
            ////for (int i = 0; i <= rd.DataSourceConnections.Count; i++)
            //{
            //    NameValuePairs2 logonProps1 = rd.DataSourceConnections[j].LogonProperties;
            //    logonProps1.Set("Database Type", "ODBC (RDO)"); 

            //    logonProps1.Set("Connection String", $"DRIVER={{HDBODBC32}};SERVERNODE={info.ServerName};CS={info.CompanyDB}");

            //    logonProps1.Set("User ID", info.DBUserName);
            //    logonProps1.Set("Server", info.ServerName);
            //    logonProps1.Set("Use DSN Default Properties", "False");
            //    if (rd.DataSourceConnections.Count > 0)
            //    {
            //        rd.DataSourceConnections[j].SetLogonProperties(logonProps1);
            //      //  rd.DataSourceConnections[0].SetConnection(ConfigurationManager.AppSettings["SAPServer"], ConfigurationManager.AppSettings["CompanyDB"], ConfigurationManager.AppSettings["DbUserName"], ConfigurationManager.AppSettings["DbPassword"]);
            //    }
            //}
            var parameters = rd.ParameterFields.ToArray();
            var rptname = rd.Name;
            for (int i = 0; i < parameters.Count(); i++)
            {
                var param = ((CrystalDecisions.Shared.ParameterField)(parameters[i]));
                var paramname = param.Name.Split('@')[0];
                if (paramname.ToLower()==("dockey"))
                {
                    rd.SetParameterValue(param.Name, info.DocEntry);
                }
                else if (paramname.ToLower() == ("objectid"))
                {
                    rd.SetParameterValue(param.Name, info.ObjectCode);
                }
                else if (paramname.ToLower() == ("extparam"))
                {
                    rd.SetParameterValue(param.Name, "");
                } 
                
            }
            var strformat = info.Ext.ToLower();
            var format = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            if (strformat == ".pdf") format = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            if (strformat == ".txt") format = ExportFormatType.Text;
            if (strformat == ".csv") format = ExportFormatType.CharacterSeparatedValues; 

            rd.ExportToDisk(format, info.pdfPath);
            return true;
        }

        public static string getReportPath(JsonData info)
        {
            var rd = new ReportDocument();
            EventLog.WriteEntry("CrystalReportHelper",info.rptPath);
            rd.Load(info.rptPath);
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = info.ServerName;
            crConnectionInfo.DatabaseName = info.CompanyDB;
            crConnectionInfo.UserID = info.DBUserName;
            crConnectionInfo.Password = info.DBPassword;
            TableLogOnInfo crTableLogoninfo = new TableLogOnInfo();
            try
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in rd.Database.Tables)
                {
                    crTableLogoninfo = CrTable.LogOnInfo;
                    crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crTableLogoninfo);
                }
            }
            catch { }
            try
            {
                foreach (ReportDocument subreport in rd.Subreports)
                {
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                    {

                        crTableLogoninfo = CrTable.LogOnInfo;
                        crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                        CrTable.ApplyLogOnInfo(crTableLogoninfo);
                    }
                }
            }
            catch { }
            var parameters = rd.ParameterFields.ToArray();
            var rptname = rd.Name;
            for (int i = 0; i < parameters.Count(); i++)
            {
                var param = ((CrystalDecisions.Shared.ParameterField)(parameters[i]));
                var paramname = param.Name.Split('@')[0];
                if (paramname.ToLower() == ("dockey"))
                {
                    rd.SetParameterValue(param.Name, info.DocEntry);
                }
                else if (paramname.ToLower() == ("extparam"))
                {
                    rd.SetParameterValue(param.Name, "");
                }
            }
            var strformat = info.Ext.ToLower();
            var format = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            if (strformat == ".pdf") format = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            if (strformat == ".txt") format = ExportFormatType.Text;
            if (strformat == ".csv") format = ExportFormatType.CharacterSeparatedValues;
           
            rd.ExportToDisk(format, info.pdfPath);

            return info.pdfPath;
        }

    }
    public class JsonData
    {
        public string rptPath { get; set; }
        public int DocEntry { get; set; }
        public int  ObjectCode { get; set; }
        public string ServerName { get; set; }
        public string CompanyDB { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public string Ext
        {
            get
            {
                if (string.IsNullOrEmpty(rptPath)) throw new Exception("Please set rptPath");
                if (rptPath.Length < 3) throw new Exception("rptPath has not valid lenth");
                return rptPath.Substring(rptPath.Length - 3);
            }
        }
         
        public string pdfPath { get; set; }
    }
}
