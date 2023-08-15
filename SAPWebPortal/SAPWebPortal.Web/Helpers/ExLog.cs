using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SAPWebPortal.Web.Helpers
{
    public static class ExLog
    {
        private static FileInfo _fileInfo;
        private static FileStream _sw;
        private static string _fileName;
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string GetPreviousMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);

            var method = sf.GetMethod();

            return string.Format("{0}.{1}: ", method.ReflectedType.Name, method.Name);
        }
       
        public static void LogToFile(string message)
        {
            DirectoryInfo dInfo;
            StringBuilder sb = new StringBuilder();
            var folderPath = Startup.getConfigValue("ExLog");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            dInfo = new DirectoryInfo(folderPath);

            if (_fileName == null)
            {
                var filePath = System.IO.Path.Combine(dInfo.FullName, string.Concat(Guid.NewGuid(), ".txt"));
                _fileName = filePath;
                _fileInfo = new FileInfo(filePath);
                _sw = _fileInfo.Create();

                using (StreamWriter sw = new StreamWriter(_sw))
                {
                    try
                    {
                        sb.Append("Time");
                        sb.Append(' ', 50);
                        sb.AppendLine("Error");
                        sb.Append(DateTime.Now.ToLongTimeString());
                        sb.Append(' ', 50);
                        sb.Append(message, 0, message.Length);
                        sw.WriteLine(sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + GetPreviousMethod() + ex.StackTrace);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(_fileName))
                {
                    sb.Append(DateTime.Now.ToLongTimeString());
                    sb.Append(' ', 50);
                    sb.Append(message, 0, message.Length);
                    sw.WriteLine(sb.ToString());
                }
            }
        }


    }
}
