using System;
using System.Runtime.Serialization;

// Token: 0x02000051 RID: 81
[DataContract(Name = "BrowserVersion", Namespace = "BrowserExtension")]
public class BrowserVersion
{
	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000196 RID: 406 RVA: 0x00009E7F File Offset: 0x0000807F
	// (set) Token: 0x06000197 RID: 407 RVA: 0x00009E87 File Offset: 0x00008087
	[DataMember(Name = "NameOfBrowser")]
	public string NameOfBrowser { get; set; }

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000198 RID: 408 RVA: 0x00009E90 File Offset: 0x00008090
	// (set) Token: 0x06000199 RID: 409 RVA: 0x00009E98 File Offset: 0x00008098
	[DataMember(Name = "Version")]
	public string Version { get; set; }

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x0600019A RID: 410 RVA: 0x00009EA1 File Offset: 0x000080A1
	// (set) Token: 0x0600019B RID: 411 RVA: 0x00009EA9 File Offset: 0x000080A9
	[DataMember(Name = "PathOfFile")]
	public string PathOfFile { get; set; }
}
