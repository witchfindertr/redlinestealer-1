using System;
using System.Web.Script.Serialization;

// Token: 0x02000032 RID: 50
public static class Json
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000D7 RID: 215 RVA: 0x00007F80 File Offset: 0x00006180
	public static JavaScriptSerializer JSON
	{
		get
		{
			JavaScriptSerializer result;
			if ((result = Json.json) == null)
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				javaScriptSerializer.MaxJsonLength = int.MaxValue;
				result = javaScriptSerializer;
				Json.json = javaScriptSerializer;
			}
			return result;
		}
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00007FA4 File Offset: 0x000061A4
	public static T FromJSON<T>(this string @this)
	{
		T result;
		try
		{
			result = Json.JSON.Deserialize<T>(@this.Trim());
		}
		catch (Exception)
		{
			result = default(T);
		}
		return result;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00007FE4 File Offset: 0x000061E4
	public static string ToJSON(this object @this)
	{
		return Json.JSON.Serialize(@this);
	}

	// Token: 0x0400002C RID: 44
	private static JavaScriptSerializer json;
}
