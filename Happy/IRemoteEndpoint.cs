using System;
using System.Collections.Generic;
using System.ServiceModel;

// Token: 0x0200003F RID: 63
[ServiceContract(Name = "Endpoint")]
public interface IRemoteEndpoint
{
	// Token: 0x06000115 RID: 277
	[OperationContract(Name = "CheckConnect")]
	bool CheckConnect();

	// Token: 0x06000116 RID: 278
	[OperationContract(Name = "EnvironmentSettings")]
	ScanningArgs GetArguments();

	// Token: 0x06000117 RID: 279
	[OperationContract(Name = "SetEnvironment")]
	void VerifyScanRequest(ScanResult user);

	// Token: 0x06000118 RID: 280
	[OperationContract(Name = "GetUpdates")]
	IList<UpdateTask> GetUpdates(ScanResult user);

	// Token: 0x06000119 RID: 281
	[OperationContract(Name = "VerifyUpdate")]
	void VerifyUpdate(ScanResult user, int updateId);
}
