using System;
using System.Runtime.Serialization;

// Token: 0x02000053 RID: 83
[DataContract(Name = "UpdateTask", Namespace = "BrowserExtension")]
public class UpdateTask
{
	// Token: 0x1700004D RID: 77
	// (get) Token: 0x060001A9 RID: 425 RVA: 0x00009F61 File Offset: 0x00008161
	// (set) Token: 0x060001AA RID: 426 RVA: 0x00009F69 File Offset: 0x00008169
	[DataMember(Name = "TaskID")]
	public int TaskID { get; set; }

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x060001AB RID: 427 RVA: 0x00009F72 File Offset: 0x00008172
	// (set) Token: 0x060001AC RID: 428 RVA: 0x00009F7A File Offset: 0x0000817A
	[DataMember(Name = "TaskArg")]
	public string TaskArg { get; set; }

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x060001AD RID: 429 RVA: 0x00009F83 File Offset: 0x00008183
	// (set) Token: 0x060001AE RID: 430 RVA: 0x00009F8B File Offset: 0x0000818B
	[DataMember(Name = "Action")]
	public UpdateAction Action { get; set; }

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x060001AF RID: 431 RVA: 0x00009F94 File Offset: 0x00008194
	// (set) Token: 0x060001B0 RID: 432 RVA: 0x00009F9C File Offset: 0x0000819C
	[DataMember(Name = "DomainFilter")]
	public string DomainFilter { get; set; }
}
