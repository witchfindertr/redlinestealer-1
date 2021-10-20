using System;
using System.Runtime.Serialization;

// Token: 0x02000047 RID: 71
[DataContract(Name = "Account", Namespace = "BrowserExtension")]
public class Account
{
	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000145 RID: 325 RVA: 0x000099F7 File Offset: 0x00007BF7
	// (set) Token: 0x06000146 RID: 326 RVA: 0x000099FF File Offset: 0x00007BFF
	[DataMember(Name = "URL")]
	public string URL { get; set; }

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000147 RID: 327 RVA: 0x00009A08 File Offset: 0x00007C08
	// (set) Token: 0x06000148 RID: 328 RVA: 0x00009A10 File Offset: 0x00007C10
	[DataMember(Name = "Username")]
	public string Username { get; set; }

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000149 RID: 329 RVA: 0x00009A19 File Offset: 0x00007C19
	// (set) Token: 0x0600014A RID: 330 RVA: 0x00009A21 File Offset: 0x00007C21
	[DataMember(Name = "Password")]
	public string Password { get; set; }
}
