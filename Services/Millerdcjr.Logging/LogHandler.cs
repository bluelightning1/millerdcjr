using Generic.Common.DataAccessLayer;
using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Millerdcjr.Logging
{
    public class LogHandler
    {
        private static StreamWriter writer = null;

        public static void Write(string str, string location, string eventLogName = null, string eventLogSource = null)
        {
            if (location.Equals("eventviewer", StringComparison.OrdinalIgnoreCase))
            {

                EventLog log = new EventLog();
                log.Log = eventLogName;
                log.Source = eventLogSource;

                // Create a trace listener for the event log.
                log.WriteEntry(str);
                log.Dispose();
                log = null;
            }
            else if (location.Equals("database", StringComparison.OrdinalIgnoreCase))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[LogsCreate]";

                command.Parameters.AddRange(BuildParms(str, DateTime.Now));
                SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
                wrapper.Create(command);
            }
        }

        private static SqlParameter[] BuildParms(string applicationName, DateTime time, string type = null
            , string description = null, string source = null, string message = null, string stacktrace = null)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            // @ApplicationName
            var parm = new SqlParameter("@ApplicationName", System.Data.SqlDbType.NVarChar, 50);
            parm.Value = applicationName;
            parms.Add(parm);
            parm = null;

            //,@Type
            parm = new SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 50);
            parm.Value = type == null ? string.Empty : type;
            parms.Add(parm);
            parm = null;

            //,@Description
            parm = new SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 150);
            parm.Value = description == null ? string.Empty : description;
            parms.Add(parm);
            parm = null;

            //,@TimeStamp
            parm = new SqlParameter("@TimeStamp", System.Data.SqlDbType.DateTime);
            parm.Value = time;
            parms.Add(parm);
            parm = null;

            //,@Source
            parm = new SqlParameter("@Source", System.Data.SqlDbType.NVarChar, 250);
            parm.Value = source == null ? string.Empty : source;
            parms.Add(parm);
            parm = null;

            //,@Message
            parm = new SqlParameter("@Message", System.Data.SqlDbType.NVarChar, 500);
            parm.Value = message == null ? string.Empty : message;
            parms.Add(parm);
            parm = null;

            //,@StackTrace
            parm = new SqlParameter("@StackTrace", System.Data.SqlDbType.NVarChar, 4000);
            parm.Value = stacktrace == null ? string.Empty : stacktrace;
            parms.Add(parm);
            parm = null;

            return parms.ToArray();
        }

        public static void Write(string appName, string description, Exception ex, string location, string eventLogName = null, string eventLogSource = null)
        {
            if (location.Equals("eventviewer", StringComparison.OrdinalIgnoreCase))
            {
                EventLog log = new EventLog();
                log.Log = eventLogName;
                log.Source = eventLogSource;

                // Create a trace listener for the event log.
                log.WriteEntry(ex.Message);
                log.Dispose();
                log = null;
            }
            else if (location.Equals("database", StringComparison.OrdinalIgnoreCase))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "[dbo].[LogsCreate]";

                command.Parameters.AddRange(BuildParms(appName, DateTime.Now, "Exception", description, ex.Source, ex.Message, ex.StackTrace));
                SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
                wrapper.Create(command);
            }
        }

        public static bool Write(string appName, string description, Exception ex, string pathAndFileName)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
                if (!info.Exists)
                {
                    info.Create();
                }

                FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));

                Write(appName, description, ex, fInfo);

                info = null;
                fInfo = null;
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            return rv;
        }

        public static bool Write(string appName, string description, Exception ex, string path, string fileName)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                if (!info.Exists)
                {
                    info.Create();
                }
                FileInfo fInfo = new FileInfo(string.Format("{0}{1}", info.FullName, fileName));

                Write(appName, description, ex, fInfo);

                info = null;
                fInfo = null;
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            return rv;
        }

        public static bool Write(string appName, string description, Exception ex, FileInfo fileInfo)
        {
            FileStream filestream = null;
            var rv = false;
            try
            {

                if (!fileInfo.Exists)
                    filestream = fileInfo.Create();
                else
                    filestream = fileInfo.OpenWrite();

                writer = new StreamWriter(filestream);

                writer.WriteLine("Message: {0}", ex.Message);
                writer.WriteLine("Source: {0}", ex.Source);
                writer.WriteLine("StackTrace: {0}", ex.StackTrace);
                writer.WriteLine("Date: {0}", DateTime.Now);
                writer.WriteLine();
                writer.Flush();
                rv = true;
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            finally
            {
                //Dispose();
            }
            return rv;
        }

        /// <summary>
        /// Removes all the files in the path past a certain point in time
        /// </summary>
        /// <param name="path">Directory to clean up / clear files</param>
        /// <param name="numberOfDaysToKeep">number of days from today to keep</param>
        public static bool Clear(string path, int numberOfDaysToKeep, int skip = 5)
        {
            bool rv = false;
            try
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);
                    var filesDelete = files.Select(x => new FileInfo(x)).Skip(skip).ToList();

                    filesDelete.ForEach(item =>
                    {
                        if (item != null &&
                            item.LastAccessTime < DateTime.Now.AddDays(-numberOfDaysToKeep))

                            item.Delete();
                    });
                    rv = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rv;
        }

        /// <summary>
        /// Removes all the files except the number to skip.  Specifcally for unit testing so the directory doesn't get filled up.
        /// </summary>
        /// <param name="path">Directory to clean up / clear files</param>
        /// <param name="numberToSkip">number of days from today to keep</param>
        public static void UnitTestClear(string path, int numberToSkip)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path).OrderByDescending(x => x).Skip(numberToSkip);
                    if (files != null && files.Count() > 0)
                    {
                        var filesDelete =
                            files.Select(x => new FileInfo(x)).ToList();

                        filesDelete.ForEach(item =>
                        {
                            if (item != null)
                                item.Delete();
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string WriteInnerException(Exception ex)
        {
            return string.Format("{0}{1}{2}{3}{4}", string.Empty, ex.Message, ex.Source, ex.StackTrace, string.Empty);
        }

        public static bool SaveIncomingMessage(string pathAndFileName, string xmlString)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
                if (!info.Exists)
                {
                    info.Create();
                }

                FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));

                FileStream filestream = null;

                if (!fInfo.Exists)
                    filestream = fInfo.Create();
                else
                    filestream = fInfo.OpenWrite();

                writer = new StreamWriter(filestream);
                writer.Write(xmlString);

                info = null;
                fInfo = null;
                rv = true;

                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }

                if (filestream != null)
                {
                    filestream.Dispose();
                    filestream = null;
                }
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            return rv;
        }

        public static void SaveIncomingMessage(string pathAndFileName, Stream stream)
        {
            //var rv = false;
            //try
            //{
            //    DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
            //    if (!info.Exists)
            //    {
            //        info.Create();
            //    }

            //    FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));

            //    FileStream filestream = null;

            //    if (!fInfo.Exists)
            //        filestream = fInfo.Create();
            //    else
            //        filestream = fInfo.OpenWrite();


            //    writer = new StreamWriter(stream);
            //    writer.Write();

            //    info = null;
            //    fInfo = null;
            //    rv = true;

            //    if (writer != null)
            //    {
            //        writer.Dispose();
            //        writer = null;
            //    }

            //    if (filestream != null)
            //    {
            //        filestream.Dispose();
            //        filestream = null;
            //    }
            //}
            //catch (Exception)
            //{
            //    rv = false;
            //    throw;
            //}
            //return rv;
        }

        public static bool SaveIncomingMessage(string pathAndFileName, System.Xml.XmlDocument EnvelopeXml)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
                if (!info.Exists)
                {
                    info.Create();
                }

                FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));

                FileStream filestream = null;

                if (!fInfo.Exists)
                    filestream = fInfo.Create();
                else
                    filestream = fInfo.OpenWrite();

                writer = new StreamWriter(filestream);
                writer.Write(EnvelopeXml);

                info = null;
                fInfo = null;
                rv = true;

                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }

                if (filestream != null)
                {
                    filestream.Dispose();
                    filestream = null;
                }
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            return rv;
        }

        public static bool SaveOutgoingMessage(string pathAndFileName, string xmlString)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
                if (!info.Exists)
                {
                    info.Create();
                }

                FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));
                FileStream filestream = null;

                if (!fInfo.Exists)
                    filestream = fInfo.Create();
                else
                    filestream = fInfo.OpenWrite();

                writer = new StreamWriter(filestream);
                writer.Write(xmlString);

                info = null;
                fInfo = null;
                rv = true;

                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }

                if (filestream != null)
                {
                    filestream.Dispose();
                    filestream = null;
                }
            }
            catch (Exception)
            {
                rv = false;
                throw;
            }
            return rv;
        }
    }
}
