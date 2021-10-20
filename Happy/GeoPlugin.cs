using System;
using System.Runtime.Serialization;

// Token: 0x02000056 RID: 86
[DataContract(Name = "GeoPlugin")]
public class GeoPlugin
{
	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060001D9 RID: 473 RVA: 0x0000A0E8 File Offset: 0x000082E8
	// (set) Token: 0x060001DA RID: 474 RVA: 0x0000A0F0 File Offset: 0x000082F0
	[DataMember(Name = "geoplugin_request")]
	public string geoplugin_request { get; set; }

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060001DB RID: 475 RVA: 0x0000A0F9 File Offset: 0x000082F9
	// (set) Token: 0x060001DC RID: 476 RVA: 0x0000A101 File Offset: 0x00008301
	[DataMember(Name = "geoplugin_city")]
	public string geoplugin_city { get; set; }

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060001DD RID: 477 RVA: 0x0000A10A File Offset: 0x0000830A
	// (set) Token: 0x060001DE RID: 478 RVA: 0x0000A112 File Offset: 0x00008312
	[DataMember(Name = "geoplugin_region")]
	public string geoplugin_region { get; set; }

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060001DF RID: 479 RVA: 0x0000A11B File Offset: 0x0000831B
	// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000A123 File Offset: 0x00008323
	[DataMember(Name = "geoplugin_countryCode")]
	public string geoplugin_countryCode { get; set; }

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000A12C File Offset: 0x0000832C
	// (set) Token: 0x060001E2 RID: 482 RVA: 0x0000A134 File Offset: 0x00008334
	[DataMember(Name = "geoplugin_latitude")]
	public string geoplugin_latitude { get; set; }

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000A13D File Offset: 0x0000833D
	// (set) Token: 0x060001E4 RID: 484 RVA: 0x0000A145 File Offset: 0x00008345
	[DataMember(Name = "geoplugin_longitude")]
	public string geoplugin_longitude { get; set; }
}
