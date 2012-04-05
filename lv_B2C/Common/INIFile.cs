using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace lv_Common
{
    /// <summary>
    /// INI�ļ���д�ࡣ
    /// Copyright (C) lvcn.com.cn
    /// </summary>
    public static class INIFile
	{
        public static string path;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def, StringBuilder retVal,int size,string filePath);

	
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


		/// <summary>
		/// дINI�ļ�
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <param name="Value"></param>
        public static void IniWriteValue(string Section, string Key, string Value)
		{
			WritePrivateProfileString(Section,Key,Value,path);
		}

		/// <summary>
		/// ��ȡINI�ļ�
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <returns></returns>
        public static string IniReadValue(string Section, string Key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Section,Key,"",temp, 255, path);
			return temp.ToString();
		}
        public static byte[] IniReadValues(string section, string key)
		{
			byte[] temp = new byte[255];
			int i = GetPrivateProfileString(section, key, "", temp, 255, path);
			return temp;

		}


		/// <summary>
		/// ɾ��ini�ļ������ж���
		/// </summary>
        public static void ClearAllSection()
		{
			IniWriteValue(null,null,null);
		}
		/// <summary>
		/// ɾ��ini�ļ���personal�����µ����м�
		/// </summary>
		/// <param name="Section"></param>
        public static void ClearSection(string Section)
		{
			IniWriteValue(Section,null,null);
		}

	}


}
