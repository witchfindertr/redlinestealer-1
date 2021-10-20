using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x02000044 RID: 68
[DataContract(Name = "ScannedBrowser", Namespace = "BrowserExtension")]
public class ScannedBrowser
{
	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600011F RID: 287 RVA: 0x0000985F File Offset: 0x00007A5F
	// (set) Token: 0x06000120 RID: 288 RVA: 0x00009867 File Offset: 0x00007A67
	[DataMember(Name = "BrowserName")]
	public string BrowserName { get; set; }

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000121 RID: 289 RVA: 0x00009870 File Offset: 0x00007A70
	// (set) Token: 0x06000122 RID: 290 RVA: 0x00009878 File Offset: 0x00007A78
	[DataMember(Name = "BrowserProfile")]
	public string BrowserProfile { get; set; }

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000123 RID: 291 RVA: 0x00009881 File Offset: 0x00007A81
	// (set) Token: 0x06000124 RID: 292 RVA: 0x00009889 File Offset: 0x00007A89
	[DataMember(Name = "Logins")]
	public IList<Account> Logins { get; set; }

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000125 RID: 293 RVA: 0x00009892 File Offset: 0x00007A92
	// (set) Token: 0x06000126 RID: 294 RVA: 0x0000989A File Offset: 0x00007A9A
	[DataMember(Name = "Autofills")]
	public IList<Autofill> Autofills { get; set; }

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000127 RID: 295 RVA: 0x000098A3 File Offset: 0x00007AA3
	// (set) Token: 0x06000128 RID: 296 RVA: 0x000098AB File Offset: 0x00007AAB
	[DataMember(Name = "CC")]
	public IList<CC> CC { get; set; }

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000129 RID: 297 RVA: 0x000098B4 File Offset: 0x00007AB4
	// (set) Token: 0x0600012A RID: 298 RVA: 0x000098BC File Offset: 0x00007ABC
	[DataMember(Name = "Cookies")]
	public IList<ScannedCookie> Cookies { get; set; }

	// Token: 0x0600012B RID: 299 RVA: 0x000098C8 File Offset: 0x00007AC8
	public bool IsEmpty()
	{
		bool result = true;
		IList<Autofill> autofills = this.Autofills;
		if (autofills != null && autofills.Count > 0)
		{
			result = false;
		}
		IList<ScannedCookie> cookies = this.Cookies;
		if (cookies != null && cookies.Count > 0)
		{
			result = false;
		}
		IList<CC> cc = this.CC;
		if (cc != null && cc.Count > 0)
		{
			result = false;
		}
		IList<Account> logins = this.Logins;
		if (logins != null && logins.Count > 0)
		{
			result = false;
		}
		return result;
	}
}
