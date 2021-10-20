using System;
using System.Runtime.Serialization;

// Token: 0x02000046 RID: 70
[DataContract(Name = "CC", Namespace = "BrowserExtension")]
public class CC
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x0600013C RID: 316 RVA: 0x000099B3 File Offset: 0x00007BB3
	// (set) Token: 0x0600013D RID: 317 RVA: 0x000099BB File Offset: 0x00007BBB
	[DataMember(Name = "HolderName")]
	public string HolderName { get; set; }

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x0600013E RID: 318 RVA: 0x000099C4 File Offset: 0x00007BC4
	// (set) Token: 0x0600013F RID: 319 RVA: 0x000099CC File Offset: 0x00007BCC
	[DataMember(Name = "Month")]
	public int Month { get; set; }

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000140 RID: 320 RVA: 0x000099D5 File Offset: 0x00007BD5
	// (set) Token: 0x06000141 RID: 321 RVA: 0x000099DD File Offset: 0x00007BDD
	[DataMember(Name = "Year")]
	public int Year { get; set; }

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000142 RID: 322 RVA: 0x000099E6 File Offset: 0x00007BE6
	// (set) Token: 0x06000143 RID: 323 RVA: 0x000099EE File Offset: 0x00007BEE
	[DataMember(Name = "Number")]
	public string Number { get; set; }
}
