using Generic‎.Common‎.Configuration;
using Generic.Common.Enums;
using Generic‎.Common‎.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Generic‎.Common‎.Log
{
    public static class Log
    {
        private static StreamWriter writer = null;

        //public static void Write(string str, EWriteLocation location)
        //{
        //    if (location == EWriteLocation.EventViewer)
        //    {
        //        EventLog log = new EventLog();
        //        log.Log = ApplicationConfiguration.GetEventLog();
        //        log.Source = ApplicationConfiguration.GetEventLogSource();

        //        // Create a trace listener for the event log.
        //        log.WriteEntry(str);
        //        log.Dispose();
        //        log = null;
        //    }
        //    else if (location == EWriteLocation.Database)
        //    {

        //    }
        //    else if (location == EWriteLocation.File)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        //public static void Write(CustomException ex, EWriteLocation location)
        //{
        //    if (location == EWriteLocation.EventViewer)
        //    {
        //        EventLog log = new EventLog();
        //        log.Log = ApplicationConfiguration.GetEventLog();
        //        log.Source = ApplicationConfiguration.GetEventLogSource();

        //        // Create a trace listener for the event log.
        //        log.WriteEntry(ex.ToString());
        //        log.Dispose();
        //        log = null;
        //    }
        //    else if (location == EWriteLocation.Database)
        //    {

        //    }
        //    else if (location == EWriteLocation.File)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        //public static void Write(Exception ex, EWriteLocation location)
        //{
        //    if (location == EWriteLocation.EventViewer)
        //    {
        //        EventLog log = new EventLog();
        //        log.Log = ApplicationConfiguration.GetEventLog();
        //        log.Source = ApplicationConfiguration.GetEventLogSource();

        //        // Create a trace listener for the event log.
        //        log.WriteEntry(ex.Message);
        //        log.Dispose();
        //        log = null;
        //    }
        //    else if (location == EWriteLocation.Database)
        //    {

        //    }
        //    else if (location == EWriteLocation.File)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        public static bool Write(CustomException ex, string pathAndFileName)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(pathAndFileName.Substring(0, pathAndFileName.LastIndexOf("\\")));
                if (!info.Exists)
                    info.Create();

                FileInfo fInfo = new FileInfo(string.Format("{0}", pathAndFileName));

                Write(ex, fInfo);

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

        public static bool Write(CustomException ex, string path, string fileName)
        {
            var rv = false;
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                if (!info.Exists)
                    info.Create();
               
                FileInfo fInfo = new FileInfo(string.Format("{0}{1}", info.FullName, fileName));

                Write(ex, fInfo);

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

        public static bool Write(CustomException ex, FileInfo fileInfo)
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

                //writer.WriteLine("Data: {0}", ex.Data);
                writer.WriteLine("Message: {0}", ex.Message);
                writer.WriteLine("Source: {0}", ex.Source);
                writer.WriteLine("StackTrace: {0}", ex.StackTrace);
                //writer.WriteLine("TargetSite: {0}", ex.TargetSite);
                writer.WriteLine("Date: {0}", DateTime.Now);
                writer.WriteLine();
                //if (ex.InnerException != null)
                //{
                //    writer.Write(LogInnerException(new CustomException(ex.InnerException)));
                //    if (ex.InnerException.InnerException != null)
                //    {
                //        writer.Write(LogInnerException(new CustomException(ex.InnerException.InnerException)));
                //        if (ex.InnerException.InnerException.InnerException != null)
                //            writer.Write(LogInnerException(new CustomException(ex.InnerException.InnerException.InnerException)));
                //    }
                //}
                writer.Flush();
                writer.Close();
                writer = null;
                filestream.Dispose();
                filestream.Close();
                filestream = null;

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

        //private static string WriteInnerException(CustomException ex)
        //{
        //    return string.Format("{0}{1}{2}{3}{4}", string.Empty, ex.Message, ex.Source, ex.StackTrace, string.Empty);
        //}
    }
}
