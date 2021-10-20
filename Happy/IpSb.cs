using System;
using System.Runtime.Serialization;

// Token: 0x02000057 RID: 87
[DataContract(Name = "IpSb")]
public class IpSb
{
	// Token: 0x1700006A RID: 106
	// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000A14E File Offset: 0x0000834E
	// (set) Token: 0x060001E7 RID: 487 RVA: 0x0000A156 File Offset: 0x00008356
	[DataMember(Name = "postal_code")]
	public string postal_code { get; set; }

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000A15F File Offset: 0x0000835F
	// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000A167 File Offset: 0x00008367
	[DataMember(Name = "ip")]
	public string ip { get; set; }

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x060001EA RID: 490 RVA: 0x0000A170 File Offset: 0x00008370
	// (set) Token: 0x060001EB RID: 491 RVA: 0x0000A178 File Offset: 0x00008378
	[DataMember(Name = "country_code")]
	public string country_code { get; set; }
}
