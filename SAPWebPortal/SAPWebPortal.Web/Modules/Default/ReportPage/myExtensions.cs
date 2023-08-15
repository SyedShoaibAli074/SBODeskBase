//using System;
//using System.Collections.Generic;
//using System.Linq;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
//using System.Data;
//using System.Collections;

//namespace Extensions
//{
//    static class myExtensions
//        {
//           public static ParameterFieldDefinition getParameter(this ParameterFieldDefinitions arr, string name)
//            {
//                ParameterFieldDefinition parmdef = null;
//                foreach (ParameterFieldDefinition item in arr)
//                {
//                    if (item.Name == name)
//                    {
//                        parmdef = item;
//                        break;
//                    }
//                }
//                return parmdef;
//            }
//           public static bool isSQL(this CrystalDecisions.Shared.ParameterField deff)
//           {
//              return  deff.Name.ToLower().Contains("@select");
//           }
//           public static string getSQL(this CrystalDecisions.Shared.ParameterField deff)
//           {
//               string str = "";
//               if (deff.isSQL())
//               {
//                   string name = deff.Name;
//                   int i = 0; 
//                   foreach (var v in name.ToCharArray())
//                   {
//                       if (v == '@')
//                           break;
//                       i++;
//                   }
//                   str = name.Substring(i + 1);
//               }
//               return str;
//           }
//           public static List<object> getListOfDefaultValues(this ParameterFieldDefinition val)
//           {
//               List<object> LST = new List<object>();
//               for (int i = 0; i < val.DefaultValues.Count; i++)
//               {
//                   ParameterDiscreteValue pmDiscreteValue = (ParameterDiscreteValue)val.DefaultValues[i];
//                   var V = pmDiscreteValue.Value;
//                   var D = pmDiscreteValue.Description;
//                   LST.Add(new { Value = V, Description = String.Format("{0}-{1}", V, D) });

//               }
//               return LST;

//           }
//           public static DataTable getTableofDefaultValues(this CrystalDecisions.Shared.ParameterField val)
//           {
//               DataTable table = new DataTable ();
//               table.Columns.Add("Value", typeof(string));
//               table.Columns .Add ("Description",typeof (string));
//               for (int i = 0; i < val.DefaultValues .Count ; i++)
//               {
//                   ParameterDiscreteValue pmDiscreteValue = (ParameterDiscreteValue)val.DefaultValues[i];
//                   var V = pmDiscreteValue.Value;
//                   var D = pmDiscreteValue.Description;
//                   table.Rows.Add(new object[] { V, D });
//               }
//               return table;
//           }
           
//    }
//}
