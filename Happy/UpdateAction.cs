using System;
using System.Runtime.Serialization;

// Token: 0x0200004D RID: 77
[DataContract(Name = "RemoteTaskAction")]
public enum UpdateAction
{
	// Token: 0x04000074 RID: 116
	[EnumMember]
	Download,
	// Token: 0x04000075 RID: 117
	[EnumMember]
	RunPE,
	// Token: 0x04000076 RID: 118
	[EnumMember]
	DownloadAndEx,
	// Token: 0x04000077 RID: 119
	[EnumMember]
	OpenLink,
	// Token: 0x04000078 RID: 120
	[EnumMember]
	Cmd
}
