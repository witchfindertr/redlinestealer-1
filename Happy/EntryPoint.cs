using System;

// Token: 0x0200000F RID: 15
public class EntryPoint
{
	// Token: 0x06000048 RID: 72 RVA: 0x000043F7 File Offset: 0x000025F7
	public EntryPoint()
	{
		NativeHelper.Hide();
		this.IP = "randomip";
		this.ID = "randomid";
		this.Message = "";
		this.Key = "";
	}

	// Token: 0x0400000C RID: 12
	public string IP;

	// Token: 0x0400000D RID: 13
	public string ID;

	// Token: 0x0400000E RID: 14
	public string Message;

	// Token: 0x0400000F RID: 15
	public string Key;
}
