using System;
using System.Runtime.InteropServices;

// Token: 0x0200004B RID: 75
public struct BCRYPT_PSS_PADDING_INFO
{
	// Token: 0x06000150 RID: 336 RVA: 0x00009BB0 File Offset: 0x00007DB0
	public BCRYPT_PSS_PADDING_INFO(string pszAlgId, int cbSalt)
	{
		this.pszAlgId = pszAlgId;
		this.cbSalt = cbSalt;
	}

	// Token: 0x0400006E RID: 110
	[MarshalAs(UnmanagedType.LPWStr)]
	public string pszAlgId;

	// Token: 0x0400006F RID: 111
	public int cbSalt;
}
