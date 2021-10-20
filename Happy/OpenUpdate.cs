using System;
using System.Diagnostics;

// Token: 0x0200002C RID: 44
public class OpenUpdate : ITaskProcessor
{
	// Token: 0x060000C1 RID: 193 RVA: 0x00007AD8 File Offset: 0x00005CD8
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.OpenLink;
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00007AE0 File Offset: 0x00005CE0
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			System.Diagnostics.Process.Start(updateTask.TaskArg);
		}
		catch
		{
		}
		return true;
	}
}
