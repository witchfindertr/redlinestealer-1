using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200003E RID: 62
public abstract class FileScannerRule
{
	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000110 RID: 272 RVA: 0x0000982C File Offset: 0x00007A2C
	// (set) Token: 0x06000111 RID: 273 RVA: 0x00009834 File Offset: 0x00007A34
	public string Name { get; set; }

	// Token: 0x06000112 RID: 274
	public abstract string GetFolder(FileScannerArg scannerArg, FileInfo filePath);

	// Token: 0x06000113 RID: 275
	public abstract IEnumerable<FileScannerArg> GetScanArgs();
}
