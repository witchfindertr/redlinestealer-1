using System;
using System.Runtime.InteropServices;

// Token: 0x0200004A RID: 74
public struct BCRYPT_OAEP_PADDING_INFO
{
	// Token: 0x0600014F RID: 335 RVA: 0x00009B95 File Offset: 0x00007D95
	public BCRYPT_OAEP_PADDING_INFO(string alg)
	{
		this.pszAlgId = alg;
		this.pbLabel = IntPtr.Zero;
		this.cbLabel = 0;
	}

	// Token: 0x0400006B RID: 107
	[MarshalAs(UnmanagedType.LPWStr)]
	public string pszAlgId;

	// Token: 0x0400006C RID: 108
	public IntPtr pbLabel;

	// Token: 0x0400006D RID: 109
	public int cbLabel;
}
