using System;
using System.Runtime.Serialization;

// Token: 0x02000045 RID: 69
[DataContract(Name = "ScannedCookie", Namespace = "BrowserExtension")]
public class ScannedCookie
{
	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600012D RID: 301 RVA: 0x0000993C File Offset: 0x00007B3C
	// (set) Token: 0x0600012E RID: 302 RVA: 0x00009944 File Offset: 0x00007B44
	[DataMember(Name = "Host")]
	public string Host { get; set; }

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600012F RID: 303 RVA: 0x0000994D File Offset: 0x00007B4D
	// (set) Token: 0x06000130 RID: 304 RVA: 0x00009955 File Offset: 0x00007B55
	[DataMember(Name = "Http")]
	public bool Http { get; set; }

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000131 RID: 305 RVA: 0x0000995E File Offset: 0x00007B5E
	// (set) Token: 0x06000132 RID: 306 RVA: 0x00009966 File Offset: 0x00007B66
	[DataMember(Name = "Path")]
	public string Path { get; set; }

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000133 RID: 307 RVA: 0x0000996F File Offset: 0x00007B6F
	// (set) Token: 0x06000134 RID: 308 RVA: 0x00009977 File Offset: 0x00007B77
	[DataMember(Name = "Secure")]
	public bool Secure { get; set; }

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000135 RID: 309 RVA: 0x00009980 File Offset: 0x00007B80
	// (set) Token: 0x06000136 RID: 310 RVA: 0x00009988 File Offset: 0x00007B88
	[DataMember(Name = "Expires")]
	public long Expires { get; set; }

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000137 RID: 311 RVA: 0x00009991 File Offset: 0x00007B91
	// (set) Token: 0x06000138 RID: 312 RVA: 0x00009999 File Offset: 0x00007B99
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000139 RID: 313 RVA: 0x000099A2 File Offset: 0x00007BA2
	// (set) Token: 0x0600013A RID: 314 RVA: 0x000099AA File Offset: 0x00007BAA
	[DataMember(Name = "Value")]
	public string Value { get; set; }
}
