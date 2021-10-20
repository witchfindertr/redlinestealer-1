using System;
using System.Runtime.Serialization;

// Token: 0x02000058 RID: 88
[DataContract(Name = "LocalState")]
public class LocalState
{
	// Token: 0x1700006D RID: 109
	// (get) Token: 0x060001ED RID: 493 RVA: 0x0000A181 File Offset: 0x00008381
	// (set) Token: 0x060001EE RID: 494 RVA: 0x0000A189 File Offset: 0x00008389
	[DataMember(Name = "os_crypt")]
	public OsCrypt os_crypt { get; set; }
}
