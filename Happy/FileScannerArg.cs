using System;

// Token: 0x0200003D RID: 61
public class FileScannerArg
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000107 RID: 263 RVA: 0x000097E8 File Offset: 0x000079E8
	// (set) Token: 0x06000108 RID: 264 RVA: 0x000097F0 File Offset: 0x000079F0
	public string Tag { get; set; }

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000109 RID: 265 RVA: 0x000097F9 File Offset: 0x000079F9
	// (set) Token: 0x0600010A RID: 266 RVA: 0x00009801 File Offset: 0x00007A01
	public string Directory { get; set; }

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600010B RID: 267 RVA: 0x0000980A File Offset: 0x00007A0A
	// (set) Token: 0x0600010C RID: 268 RVA: 0x00009812 File Offset: 0x00007A12
	public string Pattern { get; set; }

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600010D RID: 269 RVA: 0x0000981B File Offset: 0x00007A1B
	// (set) Token: 0x0600010E RID: 270 RVA: 0x00009823 File Offset: 0x00007A23
	public bool Recoursive { get; set; }
}
