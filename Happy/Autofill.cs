using System;
using System.Runtime.Serialization;

// Token: 0x02000043 RID: 67
[DataContract(Name = "Autofill", Namespace = "BrowserExtension")]
public class Autofill
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600011A RID: 282 RVA: 0x0000983D File Offset: 0x00007A3D
	// (set) Token: 0x0600011B RID: 283 RVA: 0x00009845 File Offset: 0x00007A45
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600011C RID: 284 RVA: 0x0000984E File Offset: 0x00007A4E
	// (set) Token: 0x0600011D RID: 285 RVA: 0x00009856 File Offset: 0x00007A56
	[DataMember(Name = "Value")]
	public string Value { get; set; }
}
