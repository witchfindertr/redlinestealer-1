using System;

// Token: 0x0200002B RID: 43
public interface ITaskProcessor
{
	// Token: 0x060000BF RID: 191
	bool IsValidAction(UpdateAction action);

	// Token: 0x060000C0 RID: 192
	bool Process(UpdateTask updateTask);
}
