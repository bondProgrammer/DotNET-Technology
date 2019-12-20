//------------------------------------------------------------------------------
//  Copyright (c) The Textronics Design System(I) Pvt. Ltd 2018 all rights reserved.
//
//  File:           CLog.cs       
//  Author:         Abhijit Nagale
//  Date written:   31-March-18 11:10:10 AM
//  Description:
//
//  Amendments
//  Date                        Who             Ref     Description
//  ----                     -----------        ---     -----------
//   31-March-18 11:10:10 AM   Abhijit Nagale    n/a     Created    
//------------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Configuration;

namespace RServer
{
    // ReSharper disable UnusedMember.Global
    // ReSharper disable EmptyGeneralCatchClause
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    // ReSharper disable UnusedAutoPropertyAccessor.Global

    /// <summary>  CLog </summary>
    public class CLog
    {
        #region Field and Constant Member

        static internal string ApplicationPath = string.Empty;
        private static string _strLogFilePath = string.Empty;
        private static string _strLogFileName = string.Empty;
        private static XmlDocument _xDoc;

        #endregion Field and Constant Member

        #region Member Functions

        /// <summary> Init the log file. </summary>
        /// <param name="applicationError">if set to <c>true</c> [application error].</param>
        private static void InitLogFile(bool applicationError)
        {
            var oDate = DateTime.Now;
            var intStart = (oDate.DayOfWeek - 1);
            var intEnd = (7 - Convert.ToInt32(oDate.DayOfWeek));
            if (oDate.DayOfWeek == 0)
            {
                intStart = (oDate.DayOfWeek - 6);
                intEnd = Convert.ToInt32(oDate.DayOfWeek);
            }

            //_strLogFilePath = Path.Combine("C:\\Logs\\DesignArchive", "logreport\\");
            _strLogFilePath = Convert.ToString(ConfigurationManager.AppSettings["logreport"]);
            if (!Directory.Exists(_strLogFilePath))
                Directory.CreateDirectory(_strLogFilePath);

            var strStartDate = oDate.AddDays(Convert.ToDouble(intStart)).ToString("dd-MM-yyyy");
            var strEndDate = oDate.AddDays(intEnd).ToString("dd-MM-yyyy");

            var strInitialName = (applicationError ? "app_" : "log_");

            _strLogFileName = string.Format(_strLogFilePath + "{0}" + strStartDate + "_" + strEndDate + ".xml", strInitialName);

            LoadLogFile();
        }

        /// <summary>  Loads the log file. </summary>
        private static void LoadLogFile()
        {
            if (!File.Exists(_strLogFileName))
            {
                var xWriter = new XmlTextWriter(_strLogFileName, Encoding.UTF8) { Indentation = 4, IndentChar = ' ' };

                xWriter.Formatting = (Formatting)xWriter.Indentation;
                xWriter.WriteStartDocument();

                xWriter.WriteComment("Error log of web application.");
                xWriter.WriteStartElement("log");
                xWriter.WriteStartElement("errors");
                xWriter.WriteEndElement();
                //errors
                xWriter.WriteStartElement("entries");
                xWriter.WriteEndElement();
                //entries
                xWriter.WriteEndElement();
                //log

                xWriter.WriteEndDocument();

                xWriter.Flush();
                xWriter.Close();
            }

            if (!File.Exists(_strLogFileName) || _xDoc != null) return;
            _xDoc = new XmlDocument();
            _xDoc.Load(_strLogFileName);
        }

        /// <summary> Exceptions the error. </summary>
        /// <param name="exc">The exc.</param>
        public static void ExceptionError(Exception exc)
        {

            var ex = new Exception("no error");
            XmlElement xDateNode = null;
            var strDate = DateTime.Now.ToString("dd-MM-yyyy dddd");

            var strBuilder = new StringBuilder();

            try
            {
                if (exc != null)
                    ex = exc;

                InitLogFile(true);

                if (!File.Exists(_strLogFileName)) return;

                strBuilder.Append("Message: " + ex.Message + Microsoft.VisualBasic.Constants.vbNewLine);
                strBuilder.Append("Target: ");
                strBuilder.Append(ex.TargetSite);
                strBuilder.Append(Microsoft.VisualBasic.Constants.vbNewLine + Microsoft.VisualBasic.Constants.vbNewLine);
                strBuilder.Append("Stack: " + Microsoft.VisualBasic.Constants.vbNewLine + ex.StackTrace + Microsoft.VisualBasic.Constants.vbNewLine + Microsoft.VisualBasic.Constants.vbNewLine);

                var strDetail = ex.ToString();
                var intSubIndex = strDetail.IndexOf("--- End of inner exception stack trace ---");
                if (intSubIndex > 0)
                    strBuilder.Append("Detail: " + Microsoft.VisualBasic.Constants.vbNewLine + strDetail.Substring(0, intSubIndex).Trim());

                if (ex.InnerException != null)
                {
                    strBuilder.Append("Inner Message: " + ex.InnerException.Message + Microsoft.VisualBasic.Constants.vbNewLine);
                    if (ex.InnerException.InnerException != null)
                        strBuilder.Append("Inner Message: " + ex.InnerException.InnerException.Message +
                                          Microsoft.VisualBasic.Constants.vbNewLine);
                }

                var xNode = _xDoc.SelectSingleNode("descendant::errors");
                if (xNode != null)
                {
                    if (xNode.HasChildNodes)
                        xDateNode = (XmlElement)xNode.SelectSingleNode("descendant::error[@date='" + strDate + "']");

                    if (xDateNode == null)
                    {
                        xDateNode = _xDoc.CreateElement("error");
                        xDateNode.SetAttribute("date", strDate);
                        xNode.AppendChild(xDateNode);
                    }
                }

                if ((xDateNode != null))
                {
                    var xErrorNode = _xDoc.CreateElement("detail");
                    xErrorNode.SetAttribute("time", DateTime.Now.ToString("hh:mm:ss tt"));
                    xErrorNode.AppendChild(_xDoc.CreateCDataSection(strBuilder.ToString()));
                    xDateNode.AppendChild(xErrorNode);
                }

                _xDoc.Save(_strLogFileName);
            }
            catch (Exception)
            {
            }
            finally
            {
                _xDoc = null;
            }
        }

        /// <summary> Logs the error. </summary>
        /// <param name="strErrorMessage">The STR error message.</param>
        /// <param name="applicationError">if set to <c>true</c> [application error].</param>
        public static void LogError(string strErrorMessage, bool applicationError)
        {
            XmlElement xDateNode = null;
            var strDate = DateTime.Now.ToString("dd-MM-yyyy dddd");

            try
            {
                InitLogFile(applicationError);

                if (!File.Exists(_strLogFileName)) return;

                var xNode = _xDoc.SelectSingleNode("descendant::errors");
                if (xNode != null && xNode.HasChildNodes)
                    xDateNode = (XmlElement)xNode.SelectSingleNode("descendant::error[@date='" + strDate + "']");

                if (xDateNode == null)
                {
                    xDateNode = _xDoc.CreateElement("error");
                    xDateNode.SetAttribute("date", strDate);
                    if (xNode != null) xNode.AppendChild(xDateNode);
                }

                var xErrorNode = _xDoc.CreateElement("detail");
                xErrorNode.SetAttribute("time", DateTime.Now.ToString("hh:mm:ss tt"));
                xErrorNode.AppendChild(_xDoc.CreateCDataSection(strErrorMessage));
                xDateNode.AppendChild(xErrorNode);

                _xDoc.Save(_strLogFileName);
            }
            catch (Exception)
            {
            }
            finally
            {
                // Release objects.
                _xDoc = null;
            }
        }

        /// <summary>  Logs the message. </summary>
        /// <param name="strMessage">The STR message.</param>
        public static void LogMessage(string strMessage)
        {
            XmlElement xDateNode = null;
            var strDate = DateTime.Now.ToString("dd-MM-yyyy dddd");

            try
            {
                InitLogFile(true);

                if (!File.Exists(_strLogFileName)) return;

                var xNode = _xDoc.SelectSingleNode("descendant::entries");
                if (xNode != null)
                {
                    if (xNode.HasChildNodes)
                        xDateNode = (XmlElement)xNode.SelectSingleNode("descendant::entry[@date='" + strDate + "']");

                    if (xDateNode == null)
                    {
                        xDateNode = _xDoc.CreateElement("entry");
                        xDateNode.SetAttribute("date", strDate);
                        xNode.AppendChild(xDateNode);
                    }
                }

                var xErrorNode = _xDoc.CreateElement("detail");
                xErrorNode.SetAttribute("time", DateTime.Now.ToString("hh:mm:ss tt"));
                xErrorNode.AppendChild(_xDoc.CreateTextNode(strMessage));
                if (xDateNode != null) xDateNode.AppendChild(xErrorNode);

                _xDoc.Save(_strLogFileName);
            }
            catch (Exception)
            {
            }
            finally
            {
                // Release objects.
                _xDoc = null;
            }
        }

        #endregion Member Functions
    }

    // ReSharper restore UnusedMember.Global
    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore UnusedAutoPropertyAccessor.Local
    // ReSharper restore UnusedAutoPropertyAccessor.Global
    // ReSharper restore EmptyGeneralCatchClause
}
