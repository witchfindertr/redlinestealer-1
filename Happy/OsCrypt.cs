using System;
using System.Runtime.Serialization;

// Token: 0x02000059 RID: 89
[DataContract(Name = "OsCrypt")]
public class OsCrypt
{
	// Token: 0x1700006E RID: 110
	// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000A192 File Offset: 0x00008392
	// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000A19A File Offset: 0x0000839A
	[DataMember(Name = "encrypted_key")]
	public string encrypted_key { get; set; }
}
