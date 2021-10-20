using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000009 RID: 9
public class CryptoProvider
{
	// Token: 0x06000022 RID: 34
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptOpenAlgorithmProvider(out IntPtr phAlgorithm, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, [MarshalAs(UnmanagedType.LPWStr)] string pszImplementation, uint dwFlags);

	// Token: 0x06000023 RID: 35
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint flags);

	// Token: 0x06000024 RID: 36
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptGetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbOutput, int cbOutput, ref int pcbResult, uint flags);

	// Token: 0x06000025 RID: 37
	[DllImport("bcrypt.dll", EntryPoint = "BCryptSetProperty")]
	internal static extern uint BCryptSetAlgorithmProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, int cbInput, int dwFlags);

	// Token: 0x06000026 RID: 38
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptImportKey(IntPtr hAlgorithm, IntPtr hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out IntPtr phKey, IntPtr pbKeyObject, int cbKeyObject, byte[] pbInput, int cbInput, uint dwFlags);

	// Token: 0x06000027 RID: 39
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptDestroyKey(IntPtr hKey);

	// Token: 0x06000028 RID: 40
	[DllImport("bcrypt.dll")]
	public static extern uint BCryptDecrypt(IntPtr hKey, byte[] pbInput, int cbInput, ref BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo, byte[] pbIV, int cbIV, byte[] pbOutput, int cbOutput, ref int pcbResult, int dwFlags);

	// Token: 0x06000029 RID: 41 RVA: 0x00003964 File Offset: 0x00001B64
	public static string Decrypt(byte[] bMasterKey, string chiperText)
	{
		Encoding encoding = Encoding.GetEncoding("windows-1251");
		byte[] array = new byte[bMasterKey.Length - 5];
		Array.Copy(bMasterKey, 5, array, 0, bMasterKey.Length - 5);
		byte[] bMasterKey2 = CryptoHelper.DecryptBlob(array, DataProtectionScope.CurrentUser, null);
		return encoding.GetString(CryptoProvider.Decrypt(encoding.GetBytes(chiperText), bMasterKey2));
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000039B0 File Offset: 0x00001BB0
	private static byte[] Decrypt(byte[] bEncryptedData, byte[] bMasterKey)
	{
		byte[] array = new byte[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			0,
			0,
			0,
			0
		};
		Array.Copy(bEncryptedData, 3, array, 0, 12);
		try
		{
			byte[] array2 = new byte[bEncryptedData.Length - 15];
			Array.Copy(bEncryptedData, 15, array2, 0, bEncryptedData.Length - 15);
			byte[] array3 = new byte[16];
			byte[] array4 = new byte[array2.Length - array3.Length];
			Array.Copy(array2, array2.Length - 16, array3, 0, 16);
			Array.Copy(array2, 0, array4, 0, array2.Length - array3.Length);
			return new CryptoProvider().Get(bMasterKey, array, null, array4, array3);
		}
		catch
		{
		}
		return null;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00003A58 File Offset: 0x00001C58
	private byte[] Get(byte[] key, byte[] iv, byte[] aad, byte[] cipherText, byte[] authTag)
	{
		IntPtr intPtr = this.OpenAlgorithmProvider("AES", "Microsoft Primitive Provider", "ChainingModeGCM");
		IntPtr hKey;
		IntPtr hglobal = this.ImportKey(intPtr, key, out hKey);
		BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO bcrypt_AUTHENTICATED_CIPHER_MODE_INFO = new BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag);
		byte[] array2;
		using (bcrypt_AUTHENTICATED_CIPHER_MODE_INFO)
		{
			byte[] array = new byte[this.MaxAuthTagSize(intPtr)];
			int num = 0;
			if (CryptoProvider.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array, array.Length, null, 0, ref num, 0) != 0U)
			{
				throw new CryptographicException();
			}
			array2 = new byte[num];
			uint num2 = CryptoProvider.BCryptDecrypt(hKey, cipherText, cipherText.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array, array.Length, array2, array2.Length, ref num, 0);
			if (num2 == 3221266434U)
			{
				throw new CryptographicException();
			}
			if (num2 != 0U)
			{
				throw new CryptographicException();
			}
		}
		CryptoProvider.BCryptDestroyKey(hKey);
		Marshal.FreeHGlobal(hglobal);
		CryptoProvider.BCryptCloseAlgorithmProvider(intPtr, 0U);
		return array2;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003B38 File Offset: 0x00001D38
	private int MaxAuthTagSize(IntPtr hAlg)
	{
		byte[] property = this.GetProperty(hAlg, "AuthTagLength");
		return BitConverter.ToInt32(new byte[]
		{
			property[4],
			property[5],
			property[6],
			property[7]
		}, 0);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00003B78 File Offset: 0x00001D78
	private IntPtr OpenAlgorithmProvider(string alg, string provider, string chainingMode)
	{
		IntPtr zero = IntPtr.Zero;
		if (CryptoProvider.BCryptOpenAlgorithmProvider(out zero, alg, provider, 0U) != 0U)
		{
			throw new CryptographicException();
		}
		byte[] bytes = Encoding.Unicode.GetBytes(chainingMode);
		if (CryptoProvider.BCryptSetAlgorithmProperty(zero, "ChainingMode", bytes, bytes.Length, 0) != 0U)
		{
			throw new CryptographicException();
		}
		return zero;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003BC4 File Offset: 0x00001DC4
	private IntPtr ImportKey(IntPtr hAlg, byte[] key, out IntPtr hKey)
	{
		int num = BitConverter.ToInt32(this.GetProperty(hAlg, "ObjectLength"), 0);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		byte[] array = this.Concat(new byte[][]
		{
			BitConverter.GetBytes(1296188491),
			BitConverter.GetBytes(1),
			BitConverter.GetBytes(key.Length),
			key
		});
		uint num2 = CryptoProvider.BCryptImportKey(hAlg, IntPtr.Zero, "KeyDataBlob", out hKey, intPtr, num, array, array.Length, 0U);
		if (num2 != 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptImportKey() failed with status code:{0}", num2));
		}
		return intPtr;
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003C50 File Offset: 0x00001E50
	private byte[] GetProperty(IntPtr hAlg, string name)
	{
		int num = 0;
		uint num2 = CryptoProvider.BCryptGetProperty(hAlg, name, null, 0, ref num, 0U);
		if (num2 != 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() (get size) failed with status code:{0}", num2));
		}
		byte[] array = new byte[num];
		num2 = CryptoProvider.BCryptGetProperty(hAlg, name, array, array.Length, ref num, 0U);
		if (num2 != 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() failed with status code:{0}", num2));
		}
		return array;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003CB8 File Offset: 0x00001EB8
	public byte[] Concat(params byte[][] arrays)
	{
		int num = 0;
		foreach (byte[] array in arrays)
		{
			if (array != null)
			{
				num += array.Length;
			}
		}
		byte[] array2 = new byte[num - 1 + 1];
		int num2 = 0;
		foreach (byte[] array3 in arrays)
		{
			if (array3 != null)
			{
				Buffer.BlockCopy(array3, 0, array2, num2, array3.Length);
				num2 += array3.Length;
			}
		}
		return array2;
	}
}
