using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;

namespace lv_Common
{
    /// <summary>
    /// 文件（文件夹）操作帮助类
    /// </summary>
    public static class FileHelper
    {
        #region GetLinesFromTextFile
        /// <summary>
        /// 得到文本文件的数据
        /// 返回IList 每行一个字串
        /// Encoding为当前系统的ANSI
        /// </summary>
        /// <param name="FilePathAll"></param>
        /// <returns></returns>
        public static IList GetLinesFromTextFile(string FilePathAll)
        {
            IList Lines = new ArrayList();
            FileStream fs = new FileStream(FilePathAll, FileMode.Open, FileAccess.Read);
            StreamReader din = new StreamReader(fs, System.Text.Encoding.Default);
            string str = "";
            while ((str = din.ReadLine()) != null)
            {
                Lines.Add(str);
            }
            return Lines;

        }
        /// <summary>
        /// 得到文本文件的数据
        /// 返回IList 每行一个字串
        /// Encoding为指定的Encoding
        /// </summary>
        /// <param name="FilePathAll"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static IList GetLinesFromTextFile(string FilePathAll, Encoding encoding)
        {
            IList Lines = new ArrayList();
            FileStream fs = new FileStream(FilePathAll, FileMode.Open, FileAccess.Read);
            StreamReader din = new StreamReader(fs, encoding);
            string str = "";
            while ((str = din.ReadLine()) != null)
            {
                Lines.Add(str);
            }
            return Lines;
        }
        #endregion

        #region create 存在就更新
        /// <summary>
        /// 创建文件, 如果文件已经存在, 则更新内容
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="strContent">文件内容</param>
        public static void Create(string strFileName, string strContent)
        {
            try
            {
                int iIndex = strFileName.LastIndexOf(@"\");
                if (iIndex > 0)
                {
                    CreateDirectory(strFileName.Substring(0, iIndex));
                }

                StreamWriter streamWriter = File.CreateText(strFileName);
                try
                {
                    streamWriter.Write(strContent);
                    streamWriter.Flush();
                }
                catch (Exception except)
                {
                    throw new Exception(String.Format("创建文件{0}出错\r\n{1}", strFileName, except.Message));
                }
                finally
                {
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region create 存在是否备份
        /// <summary>
        /// 创建文件, 如果已经存在,是否备份原文件(文件名后加.bak)
        /// </summary>
        /// <param name="strFileName">文件名</param>
        /// <param name="strContent">文件内容</param>
        /// <param name="bBackup">是否备份</param>
        public static void Create(string strFileName, string strContent, bool bBackup)
        {
            if (bBackup && File.Exists(strFileName))
            {
                Backup(strFileName);
            }
            Create(strFileName, strContent);
        }
        /// <summary>
        /// 备份指定文件为.bak
        /// </summary>
        /// <param name="strFileName">备份文件</param>
        private static void Backup(string strFileName)
        {
            try
            {
                File.Delete(strFileName + ".bak");
                File.Move(strFileName, strFileName + ".bak");
            }
            catch (Exception except)
            {
                throw new Exception(String.Format("备份指定文件{0}出错\r\n{1}", strFileName, except.Message));
            }
        }
        #endregion

        #region delete
        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="strFileName">文件名称</param>
        public static void Delete(string strFileName)
        {
            try
            {
                if (File.Exists(strFileName))
                {
                    File.Delete(strFileName);
                }
            }
            catch (Exception except)
            {
                throw new Exception(String.Format("删除指定文件{0}出错\r\n{1}", strFileName, except.Message));
            }
        }
        #endregion

        #region 如果文件的目录不存在就建立目录
        /// <summary>
        /// 如果文件的目录不存在就建立目录
        /// </summary>
        /// <param name="strFileName"></param>
        public static void CreateDirectoryOfFileName(string strFileName)
        {
            try
            {
                int iIndex = strFileName.LastIndexOf(@"\");
                int last = strFileName.LastIndexOf(@"/");
                if (last > iIndex)
                {
                    CreateDirectory(strFileName.Substring(0, last));
                }
                else
                {
                    if (iIndex > 0)
                    {
                        CreateDirectory(strFileName.Substring(0, iIndex));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="strDirectoryName">文件夹名</param>
        public static void CreateDirectory(string strDirectoryName)
        {
            try
            {
                if (!Directory.Exists(strDirectoryName))
                    Directory.CreateDirectory(strDirectoryName);
            }
            catch
            {
                throw new Exception("不能创建文件目录!");
            }
        }
        #endregion

        #region 得到文件内容
        /// <summary>
        /// 得到文件内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static ArrayList ReadFileLines(string path)
        {
            StreamReader sr;
            ArrayList array = new ArrayList();
            sr = File.OpenText(path);
            string line = sr.ReadLine();
            while (line != null)
            {
                array.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return array;
        }
        #endregion

        #region 获取某目录下的所有文件(包括子目录下文件)的数量
        /// <summary>
        /// 获取某目录下的所有文件(包括子目录下文件)的数量
        /// </summary>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        public static int GetFileNum(string srcPath)
        {
            int fileNum = 0;
            try
            {

                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就重新调用GetFileNum(string srcPath)
                    if (System.IO.Directory.Exists(file))
                        GetFileNum(file);
                    else
                        fileNum++;
                }

            }
            catch
            {
                throw new Exception("遍历目录文件时出错！");
            }
            return fileNum;
        }
        #endregion

        #region GetFilesCount

        /// <summary>
        /// 得到文件夹下的文件数
        /// </summary>
        /// <param name="dirInfo">目录名称</param>
        /// <returns></returns>
        public static int GetFilesCount(System.IO.DirectoryInfo dirInfo)
        {
            int totalFile = 0;
            totalFile += dirInfo.GetFiles().Length;
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        #endregion

        #region GetFileName(string FileNamePath)
        /// <summary>
        /// 得到文件名
        /// </summary>
        /// <param name="FileNamePath">包含路径的文件名</param>
        /// <returns>不含路径的文件名</returns>
        public static string GetFileName(string FileNamePath)
        {
            int iIndex = FileNamePath.LastIndexOf(@"\");
            if (iIndex >= 0)
            {
                string fileName = FileNamePath.Substring(iIndex + 1);
                return fileName;
            }
            else
            {
                return FileNamePath;
            }
        }
        #endregion

        #region 备份文件
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!System.IO.File.Exists(sourceFileName))
            {
                throw new Exception(sourceFileName + "文件不存在！");
            }
            if (!overwrite && System.IO.File.Exists(destFileName))
            {
                return false;
            }
            try
            {
                System.IO.File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch
            {
                throw new Exception("备份此文件时出错！");
            }
        }


        /// <summary>
        /// 备份文件,当目标文件存在时覆盖
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }


        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!System.IO.File.Exists(backupFileName))
                {
                    throw new Exception(backupFileName + "文件不存在！");
                }
                if (backupTargetFileName != null)
                {
                    if (!System.IO.File.Exists(targetFileName))
                    {
                        throw new Exception(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    else
                    {
                        System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                    }
                }
                System.IO.File.Delete(targetFileName);
                System.IO.File.Copy(backupFileName, targetFileName);
            }
            catch
            {
                throw new Exception(targetFileName + "备份此文件时出错！");
            }
            return true;
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }

        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }
        #endregion
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>创建是否成功</returns>
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);
    }
}
