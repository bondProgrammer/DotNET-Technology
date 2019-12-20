//------------------------------------------------------------------------------
//  Copyright (c) The Textronics Design System(I) Pvt. Ltd 2017 all rights reserved.
//
//  File:           Tableorder.cs       
//  Author:         Abhijit Nagale
//  Date written:   16-04-17  12:50:45 PM
//  Description:
//
//  Amendments
//  Date                  Who             Ref     Description
//  ----                  -----------     ---     -----------
//  16-04-17 12:50:45 PM Abhijit Nagale    n/a     Created    
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TDSConvertor
{
    public class Tableorder
    {
        static SqlConnection con;

        /// <summary> Method for getting table filling order</summary>
        /// <param name="str">sql connection string </param>
        /// <returns> list of table names  </returns>
        public static List<string> GetTableFillingOrder(string str)
        {
            List<string> tblsList = new List<string>();
            con = new SqlConnection(str);
            con.Open();
            DataTable schema = con.GetSchema("Tables");
            List<string> TableNames = new List<string>();
            foreach (DataRow row in schema.Rows)
                TableNames.Add(row[2].ToString());
            return TableNames;
        }

        /// <summary> Method for find primary and foregin key in table</summary>
        /// <param name="str">sql connection string</param>
        /// <returns> list of table names </returns>
        public static List<string> FindPrimaryandForeginKeyinTable(string str)
        {
            try
            {
                HashSet<string> resolvedTbls = new HashSet<string>();
                HashSet<string> unresolvedTbls = new HashSet<string>();
                List<string> tblsList = new List<string>();
                List<string> GettblsList = new List<string>();
                string Query;
                GettblsList = GetTableFillingOrder(str);
                con = new SqlConnection(str);
                con.Open();
                foreach (var item in GettblsList)
                {
                    Query = "SELECT  object_name(parent_object_id),  object_name(referenced_object_id),name FROM sys.foreign_keys WHERE parent_object_id = object_id('" + item + "')";
                    var dsForeginkey = GetDataSet1(Query, item, str);
                    if (dsForeginkey.Tables[0].Rows.Count == 0)
                    {
                        tblsList.Add(item);
                        resolvedTbls.Add(item);
                    }
                    if (dsForeginkey.Tables[0].Rows.Count != 0)
                    {
                        unresolvedTbls.Add(item);
                    }
                }
                //At this point we have a list of un-resolved tables....
                foreach (string tblName in unresolvedTbls)
                {
                    resolveTable(tblName, tblsList, resolvedTbls, str);
                }
                con.Close();
                //tblsList.Remove("__MigrationHistory");
                tblsList.Remove("schema_info");
                tblsList.Remove("scope_config");
                tblsList.Remove("scope_info");
                tblsList.Remove("sysdiagrams");
                tblsList.Remove("UserUsesRecords");
                tblsList.Remove("CustomerFeedBackDetails");

                List<String> tableNames = new List<string>();
                foreach (var tablenameitem in tblsList)
                {
                    if (!tablenameitem.Contains("_tracking"))
                        tableNames.Add(tablenameitem);
                }
                tableNames.Remove("__MigrationHistory");
                return tableNames;
            }
            catch (Exception e) { }
            return null;
        }

        /// <summary> Method for resolve Table </summary>
        /// <param name="tblName"> table name</param>
        /// <param name="tblsList"> list of table name</param>
        /// <param name="resolvedTbls"> list of resolved tables</param>
        /// <param name="str"> connecton string </param>
        private static void resolveTable(string tblName, List<string> tblsList, HashSet<string> resolvedTbls, string str)
        {
            if (resolvedTbls.Contains(tblName))
                return;
            con = new SqlConnection(str);
            con.Open();
            string Query = "SELECT object_name(parent_object_id) as ParentTableName,object_name(referenced_object_id) as RefTableName,name" +
                " FROM sys.foreign_keys WHERE parent_object_id = object_id('" + tblName + "')";
            var dsForeginkey = GetDataSet1(Query, tblName, str);
            if (dsForeginkey.Tables[0].Rows.Count >= 0)
            {
                foreach (DataRow item in dsForeginkey.Tables[0].Rows)
                {
                    string RefTableName = item["RefTableName"].ToString();
                    if (!resolvedTbls.Contains(RefTableName))
                        resolveTable(RefTableName, tblsList, resolvedTbls, str);
                }
                tblsList.Add(tblName);
                resolvedTbls.Add(tblName);
            }
            con.Close();
        }

        /// <summary> Method for getting Data Set</summary>
        /// <param name="strQuery"> sql query</param>
        /// <param name="strTableName"> table name</param>
        /// <param name="con"> sql connection string </param>
        /// <returns> dataset </returns>
        public static DataSet GetDataSet1(string strQuery, string strTableName, string con)
        {
            try
            {
                //var data = new SqlData(con);
                //var dataset = new DataSet();
                //data.Command.CommandTimeout = 0;
                //data.Command.CommandType = CommandType.Text;
                //data.Command.CommandText = strQuery;
                //data.Fill(ref dataset, strTableName);
                //return dataset;

                SqlConnection sqlconnection = new SqlConnection(con);
                sqlconnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, sqlconnection);
                sqlconnection.Close();
                DataSet dataset = new DataSet();
                da.Fill(dataset, strTableName);
                return dataset;
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
