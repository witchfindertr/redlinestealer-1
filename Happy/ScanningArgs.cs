using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x0200004E RID: 78
[DataContract(Name = "ScanningArgs", Namespace = "BrowserExtension")]
public class ScanningArgs
{
	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000151 RID: 337 RVA: 0x00009BC0 File Offset: 0x00007DC0
	// (set) Token: 0x06000152 RID: 338 RVA: 0x00009BC8 File Offset: 0x00007DC8
	[DataMember(Name = "ScanBrowsers")]
	public bool ScanBrowsers { get; set; }

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000153 RID: 339 RVA: 0x00009BD1 File Offset: 0x00007DD1
	// (set) Token: 0x06000154 RID: 340 RVA: 0x00009BD9 File Offset: 0x00007DD9
	[DataMember(Name = "ScanFiles")]
	public bool ScanFiles { get; set; }

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000155 RID: 341 RVA: 0x00009BE2 File Offset: 0x00007DE2
	// (set) Token: 0x06000156 RID: 342 RVA: 0x00009BEA File Offset: 0x00007DEA
	[DataMember(Name = "ScanFTP")]
	public bool ScanFTP { get; set; }

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000157 RID: 343 RVA: 0x00009BF3 File Offset: 0x00007DF3
	// (set) Token: 0x06000158 RID: 344 RVA: 0x00009BFB File Offset: 0x00007DFB
	[DataMember(Name = "ScanWallets")]
	public bool ScanWallets { get; set; }

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x06000159 RID: 345 RVA: 0x00009C04 File Offset: 0x00007E04
	// (set) Token: 0x0600015A RID: 346 RVA: 0x00009C0C File Offset: 0x00007E0C
	[DataMember(Name = "ScanScreen")]
	public bool ScanScreen { get; set; }

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600015B RID: 347 RVA: 0x00009C15 File Offset: 0x00007E15
	// (set) Token: 0x0600015C RID: 348 RVA: 0x00009C1D File Offset: 0x00007E1D
	[DataMember(Name = "ScanTelegram")]
	public bool ScanTelegram { get; set; }

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x0600015D RID: 349 RVA: 0x00009C26 File Offset: 0x00007E26
	// (set) Token: 0x0600015E RID: 350 RVA: 0x00009C2E File Offset: 0x00007E2E
	[DataMember(Name = "ScanVPN")]
	public bool ScanVPN { get; set; }

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x0600015F RID: 351 RVA: 0x00009C37 File Offset: 0x00007E37
	// (set) Token: 0x06000160 RID: 352 RVA: 0x00009C3F File Offset: 0x00007E3F
	[DataMember(Name = "ScanSteam")]
	public bool ScanSteam { get; set; }

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000161 RID: 353 RVA: 0x00009C48 File Offset: 0x00007E48
	// (set) Token: 0x06000162 RID: 354 RVA: 0x00009C50 File Offset: 0x00007E50
	[DataMember(Name = "ScanDiscord")]
	public bool ScanDiscord { get; set; }

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000163 RID: 355 RVA: 0x00009C59 File Offset: 0x00007E59
	// (set) Token: 0x06000164 RID: 356 RVA: 0x00009C61 File Offset: 0x00007E61
	[DataMember(Name = "ScanFilesPaths")]
	public List<string> ScanFilesPaths { get; set; }

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000165 RID: 357 RVA: 0x00009C6A File Offset: 0x00007E6A
	// (set) Token: 0x06000166 RID: 358 RVA: 0x00009C72 File Offset: 0x00007E72
	[DataMember(Name = "BlockedCountry")]
	public List<string> BlockedCountry { get; set; }

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x06000167 RID: 359 RVA: 0x00009C7B File Offset: 0x00007E7B
	// (set) Token: 0x06000168 RID: 360 RVA: 0x00009C83 File Offset: 0x00007E83
	[DataMember(Name = "BlockedIP")]
	public List<string> BlockedIP { get; set; }

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x06000169 RID: 361 RVA: 0x00009C8C File Offset: 0x00007E8C
	// (set) Token: 0x0600016A RID: 362 RVA: 0x00009C94 File Offset: 0x00007E94
	[DataMember(Name = "ScanChromeBrowsersPaths")]
	public List<string> ScanChromeBrowsersPaths { get; set; }

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600016B RID: 363 RVA: 0x00009C9D File Offset: 0x00007E9D
	// (set) Token: 0x0600016C RID: 364 RVA: 0x00009CA5 File Offset: 0x00007EA5
	[DataMember(Name = "ScanGeckoBrowsersPaths")]
	public List<string> ScanGeckoBrowsersPaths { get; set; }
}
