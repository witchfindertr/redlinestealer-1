using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Token: 0x02000037 RID: 55
public static class NativeHelper
{
	// Token: 0x060000E0 RID: 224
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr LoadLibrary(string fileName);

	// Token: 0x060000E1 RID: 225
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FreeLibrary(IntPtr hModule);

	// Token: 0x060000E2 RID: 226
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	// Token: 0x060000E3 RID: 227 RVA: 0x000084B8 File Offset: 0x000066B8
	public static void Hide()
	{
		try
		{
			IntPtr hModule = NativeHelper.LoadLibrary("kernel32");
			IntPtr hModule2 = NativeHelper.LoadLibrary("user32.dll");
			IntPtr procAddress = NativeHelper.GetProcAddress(hModule, "GetConsoleWindow");
			IntPtr procAddress2 = NativeHelper.GetProcAddress(hModule2, "ShowWindow");
			IntPtr hWnd = NativeHelper.GetDelegate<NativeHelper.GetConsoleWindow>(procAddress)();
			NativeHelper.GetDelegate<NativeHelper.SetConsole>(procAddress2)(hWnd, 0);
		}
		catch
		{
		}
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00008520 File Offset: 0x00006720
	private static T GetDelegate<T>(IntPtr arg1) where T : class
	{
		return Marshal.GetDelegateForFunctionPointer(arg1, typeof(T)) as T;
	}

	// Token: 0x02000038 RID: 56
	// (Invoke) Token: 0x060000E6 RID: 230
	private delegate IntPtr GetConsoleWindow();

	// Token: 0x02000039 RID: 57
	// (Invoke) Token: 0x060000EA RID: 234
	private delegate bool SetConsole(IntPtr hWnd, int nCmdShow);
}
