using System;
using System.Runtime.Serialization;

// Token: 0x0200004C RID: 76
[DataContract(Name = "HardwareType")]
public enum HardwareType
{
	// Token: 0x04000071 RID: 113
	[EnumMember]
	Processor,
	// Token: 0x04000072 RID: 114
	[EnumMember]
	Graphic
}
