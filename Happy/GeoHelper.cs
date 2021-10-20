using System;
using System.Net;
using System.Text;

// Token: 0x02000036 RID: 54
public static class GeoHelper
{
	// Token: 0x060000DF RID: 223 RVA: 0x0000831C File Offset: 0x0000651C
	public static GeoInfo Get()
	{
		GeoInfo geoInfo = new GeoInfo();
		try
		{
			try
			{
				IpSb ipSb = Encoding.UTF8.GetString(new WebClient().DownloadData(new string(new char[]
				{
					'h',
					't',
					't',
					'p',
					's',
					':',
					'/',
					'/',
					'a',
					'p',
					'i',
					'.',
					'i',
					'p',
					'.',
					's',
					'b',
					'/',
					'g',
					'e',
					'o',
					'i',
					'p'
				}))).FromJSON<IpSb>();
				geoInfo.IP = ipSb.ip;
				if (geoInfo.IP.Contains(":"))
				{
					geoInfo.IP = null;
				}
				geoInfo.PostalCode = ipSb.postal_code;
				geoInfo.Country = ipSb.country_code;
			}
			catch (Exception)
			{
			}
			if (string.IsNullOrEmpty(geoInfo.IP))
			{
				try
				{
					geoInfo.IP = Encoding.UTF8.GetString(new WebClient().DownloadData(new string(new char[]
					{
						'h',
						't',
						't',
						'p',
						's',
						':',
						'/',
						'/',
						'i',
						'p',
						'i',
						'n',
						'f',
						'o',
						'.',
						'i',
						'o',
						'/',
						'i',
						'p'
					}))).Trim(new char[]
					{
						'\n'
					}).Trim();
				}
				catch (Exception)
				{
				}
			}
			if (string.IsNullOrEmpty(geoInfo.IP))
			{
				try
				{
					geoInfo.IP = Encoding.UTF8.GetString(new WebClient().DownloadData(new string(new char[]
					{
						'h',
						't',
						't',
						'p',
						's',
						':',
						'/',
						'/',
						'a',
						'p',
						'i',
						'.',
						'i',
						'p',
						'i',
						'f',
						'y',
						'.',
						'o',
						'r',
						'g'
					}))).Replace("\n", "");
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		return geoInfo;
	}
}
