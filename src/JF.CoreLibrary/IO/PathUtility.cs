using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JF.IO
{
	/// <summary>
	/// 提供有关路径和文件操作功能的静态类。
	/// </summary>
	[Obsolete]
	public static class PathUtility
	{
		public static string GetCurrentFilePathWithSerialNo(string filePath, Predicate<string> predicate)
		{
			string filePathOfCurrent = filePath;
			string filePathOfMaxSerialNo = GetFilePathOfMaxSerialNo(filePath);

			if(!string.IsNullOrEmpty(filePathOfMaxSerialNo))
			{
				filePathOfCurrent = filePathOfMaxSerialNo;
			}

			if(predicate.Invoke(filePathOfCurrent))
			{
				filePath = GetFilePathOfNextSerialNo(filePath);
			}
			else
			{
				filePath = filePathOfCurrent;
			}

			return filePath;
		}

		public static string GetFilePathOfMaxSerialNo(string filePath)
		{
			int? temp;
			return GetFilePathOfMaxSerialNo(filePath, out temp);
		}

		public static string GetFilePathOfMaxSerialNo(string filePath, out int? maxSerialNo)
		{
			if(string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException("filePath");
			}

			string directoryPath = System.IO.Path.GetDirectoryName(filePath);
			string fileName = GetFileNameOfMaxSerialNo(directoryPath, System.IO.Path.GetFileName(filePath), out maxSerialNo);

			if(string.IsNullOrEmpty(fileName))
			{
				return null;
			}

			return System.IO.Path.Combine(directoryPath, fileName);
		}

		public static string GetFileNameOfMaxSerialNo(string directoryPath, string fileName)
		{
			int? temp;
			return GetFileNameOfMaxSerialNo(directoryPath, fileName, out temp);
		}

		public static string GetFileNameOfMaxSerialNo(string directoryPath, string fileName, out int? maxSerialNo)
		{
			if(string.IsNullOrEmpty(directoryPath))
			{
				throw new ArgumentNullException("directoryPath");
			}

			if(string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}

			maxSerialNo = null;
			string fileNameOfMaxSerialNo = null;
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
			string extensionName = System.IO.Path.GetExtension(fileName);

			string[] sameFileNames = Directory.GetFiles(directoryPath, fileNameWithoutExtension + "-*" + extensionName);

			foreach(string sameFileName in sameFileNames)
			{
				Match match = Regex.Match(sameFileName, string.Format(@"{0}-(?'no'\d+)\{1}\b", fileNameWithoutExtension, extensionName));

				if(match.Success && match.Groups.Count > 1 && match.Groups["no"].Success)
				{
					int fileNo = int.Parse(match.Groups["no"].Value);

					if(fileNameOfMaxSerialNo != null)
					{
						if(fileNo > maxSerialNo)
						{
							maxSerialNo = fileNo;
							fileNameOfMaxSerialNo = sameFileName;
						}
					}
					else
					{
						maxSerialNo = int.Parse(match.Groups["no"].Value);
						fileNameOfMaxSerialNo = sameFileName;
					}
				}
			}

			return fileNameOfMaxSerialNo;
		}

		public static string GetFilePathOfNextSerialNo(string filePath)
		{
			return GetFilePathOfNextSerialNo(filePath, 1, 1);
		}

		public static string GetFilePathOfNextSerialNo(string filePath, int seed, int step)
		{
			string directoryPath = System.IO.Path.GetDirectoryName(filePath);
			string fileName = GetFileNameOfNextSerialNo(directoryPath, System.IO.Path.GetFileName(filePath));

			return System.IO.Path.Combine(directoryPath, fileName);
		}

		public static string GetFileNameOfNextSerialNo(string directoryPath, string fileName)
		{
			return GetFileNameOfNextSerialNo(directoryPath, fileName, 1, 1);
		}

		public static string GetFileNameOfNextSerialNo(string directoryPath, string fileName, int seed, int step)
		{
			int? maxSerialNo;
			GetFileNameOfMaxSerialNo(directoryPath, fileName, out maxSerialNo);

			if(maxSerialNo.HasValue)
			{
				return string.Format("{0}-{2}{1}", System.IO.Path.GetFileNameWithoutExtension(fileName), System.IO.Path.GetExtension(fileName), maxSerialNo + step);
			}
			else
			{
				return string.Format("{0}-{2}{1}", System.IO.Path.GetFileNameWithoutExtension(fileName), System.IO.Path.GetExtension(fileName), seed);
			}
		}
	}
}