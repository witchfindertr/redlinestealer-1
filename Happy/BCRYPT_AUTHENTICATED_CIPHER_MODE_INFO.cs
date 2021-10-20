using System;
using System.Runtime.InteropServices;

// Token: 0x02000048 RID: 72
public struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
{
	// Token: 0x0600014C RID: 332 RVA: 0x00009A2C File Offset: 0x00007C2C
	public BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag)
	{
		this = default(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
		this.dwInfoVersion = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
		this.cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
		if (iv != null)
		{
			this.cbNonce = iv.Length;
			this.pbNonce = Marshal.AllocHGlobal(this.cbNonce);
			Marshal.Copy(iv, 0, this.pbNonce, this.cbNonce);
		}
		if (aad != null)
		{
			this.cbAuthData = aad.Length;
			this.pbAuthData = Marshal.AllocHGlobal(this.cbAuthData);
			Marshal.Copy(aad, 0, this.pbAuthData, this.cbAuthData);
		}
		if (tag != null)
		{
			this.cbTag = tag.Length;
			this.pbTag = Marshal.AllocHGlobal(this.cbTag);
			Marshal.Copy(tag, 0, this.pbTag, this.cbTag);
			this.cbMacContext = tag.Length;
			this.pbMacContext = Marshal.AllocHGlobal(this.cbMacContext);
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00009B0C File Offset: 0x00007D0C
	public void Dispose()
	{
		if (this.pbNonce != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbNonce);
		}
		if (this.pbTag != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbTag);
		}
		if (this.pbAuthData != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbAuthData);
		}
		if (this.pbMacContext != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbMacContext);
		}
	}

	// Token: 0x0400005A RID: 90
	public static readonly int BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 1;

	// Token: 0x0400005B RID: 91
	public int cbSize;

	// Token: 0x0400005C RID: 92
	public int dwInfoVersion;

	// Token: 0x0400005D RID: 93
	public IntPtr pbNonce;

	// Token: 0x0400005E RID: 94
	public int cbNonce;

	// Token: 0x0400005F RID: 95
	public IntPtr pbAuthData;

	// Token: 0x04000060 RID: 96
	public int cbAuthData;

	// Token: 0x04000061 RID: 97
	public IntPtr pbTag;

	// Token: 0x04000062 RID: 98
	public int cbTag;

	// Token: 0x04000063 RID: 99
	public IntPtr pbMacContext;

	// Token: 0x04000064 RID: 100
	public int cbMacContext;

	// Token: 0x04000065 RID: 101
	public int cbAAD;

	// Token: 0x04000066 RID: 102
	public long cbData;

	// Token: 0x04000067 RID: 103
	public int dwFlags;
}
