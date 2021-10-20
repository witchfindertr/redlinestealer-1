using System;
using System.Text;

// Token: 0x0200000B RID: 11
public static class StringDecrypt
{
	// Token: 0x06000036 RID: 54 RVA: 0x00003EA4 File Offset: 0x000020A4
	private static string Xor(string input, string stringKey)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			stringBuilder.Append(input[i] ^ stringKey[i % stringKey.Length]);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003EEC File Offset: 0x000020EC
	private static string FromBase64(string base64str)
	{
		return StringDecrypt.BytesToStringConverted(Convert.FromBase64String(base64str));
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003EF9 File Offset: 0x000020F9
	private static string BytesToStringConverted(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00003F08 File Offset: 0x00002108
	public static string Decrypt(string b64, string stringKey)
	{
		string result;
		try
		{
			if (string.IsNullOrWhiteSpace(b64))
			{
				result = string.Empty;
			}
			else
			{
				result = StringDecrypt.FromBase64(StringDecrypt.Xor(StringDecrypt.FromBase64(b64), stringKey));
			}
		}
		catch
		{
			result = b64;
		}
		return result;
	}
}
