using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPWebPortal.Drafts.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Drafts.Endpoints.Tests
{
    [TestClass()]
    public class DataDictionaryViewControllerTests : TestBase<DataDictionaryViewController, Object>
    {
        //constructor
        public DataDictionaryViewControllerTests() : base("imran")
        {
        }
        [TestMethod()]
        public void GetDataDictionariesTest()
        {
            //start stopwatch
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var dictionaries = controller.GetDataDictionaries();
            //serialize
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(dictionaries, Newtonsoft.Json.Formatting.Indented);
            //print on debug
            System.Diagnostics.Debug.WriteLine(jsonResult);
            //stop stopwatch
            stopwatch.Stop();
            //print on debug
            System.Diagnostics.Debug.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds.ToString() + " ms");

        }

        [TestMethod()]
        public void GetSessionsTest()
        {
            //start stopwatch
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var sessions = controller.GetSessions();
            //serialize
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(sessions, Newtonsoft.Json.Formatting.Indented);
            //print on debug
            System.Diagnostics.Debug.WriteLine(jsonResult);
            //stop stopwatch
            stopwatch.Stop();
            //print on debug
            System.Diagnostics.Debug.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
        }
    }
}