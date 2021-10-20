using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x02000033 RID: 51
public static class MonitorHelper
{
	// Token: 0x060000DA RID: 218
	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

	// Token: 0x060000DB RID: 219 RVA: 0x00007FF4 File Offset: 0x000061F4
	public static double GetWindowsScreenScalingFactor(bool percentage = true)
	{
		Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
		IntPtr hdc = graphics.GetHdc();
		int deviceCaps = MonitorHelper.GetDeviceCaps(hdc, 10);
		double num = Math.Round((double)MonitorHelper.GetDeviceCaps(hdc, 117) / (double)deviceCaps, 2);
		if (percentage)
		{
			num *= 100.0;
		}
		graphics.ReleaseHdc(hdc);
		graphics.Dispose();
		return num;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x0000804C File Offset: 0x0000624C
	[return: Dynamic]
	public static dynamic MonitorSize()
	{
		object result;
		try
		{
			double windowsScreenScalingFactor = MonitorHelper.GetWindowsScreenScalingFactor(false);
			int num = (int)((double)Screen.PrimaryScreen.Bounds.Width * windowsScreenScalingFactor);
			double num2 = (double)Screen.PrimaryScreen.Bounds.Height * windowsScreenScalingFactor;
			result = new Size(num, (int)num2);
		}
		catch
		{
			result = Screen.PrimaryScreen.Bounds.Size;
		}
		return result;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x000080C8 File Offset: 0x000062C8
	public static byte[] Parse()
	{
		byte[] result;
		try
		{
			object obj = MonitorHelper.MonitorSize();
			if (MonitorHelper.<>o__4.<>p__2 == null)
			{
				MonitorHelper.<>o__4.<>p__2 = CallSite<Func<CallSite, Type, object, object, Bitmap>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(MonitorHelper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object, Bitmap> target = MonitorHelper.<>o__4.<>p__2.Target;
			CallSite <>p__ = MonitorHelper.<>o__4.<>p__2;
			Type typeFromHandle = typeof(Bitmap);
			if (MonitorHelper.<>o__4.<>p__0 == null)
			{
				MonitorHelper.<>o__4.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Width", typeof(MonitorHelper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			object arg = MonitorHelper.<>o__4.<>p__0.Target(MonitorHelper.<>o__4.<>p__0, obj);
			if (MonitorHelper.<>o__4.<>p__1 == null)
			{
				MonitorHelper.<>o__4.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Height", typeof(MonitorHelper), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Bitmap bitmap = target(<>p__, typeFromHandle, arg, MonitorHelper.<>o__4.<>p__1.Target(MonitorHelper.<>o__4.<>p__1, obj));
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.InterpolationMode = InterpolationMode.Bicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				if (MonitorHelper.<>o__4.<>p__3 == null)
				{
					MonitorHelper.<>o__4.<>p__3 = CallSite<Action<CallSite, Graphics, Point, Point, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "CopyFromScreen", null, typeof(MonitorHelper), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				MonitorHelper.<>o__4.<>p__3.Target(MonitorHelper.<>o__4.<>p__3, graphics, new Point(0, 0), new Point(0, 0), obj);
			}
			result = MonitorHelper.ImageToByte(bitmap);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x000082C0 File Offset: 0x000064C0
	private static byte[] ImageToByte(Image img)
	{
		byte[] result;
		try
		{
			if (img == null)
			{
				result = null;
			}
			else
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					img.Save(memoryStream, ImageFormat.Png);
					result = memoryStream.ToArray();
				}
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x02000034 RID: 52
	public enum DeviceCap
	{
		// Token: 0x0400002E RID: 46
		VERTRES = 10,
		// Token: 0x0400002F RID: 47
		DESKTOPVERTRES = 117
	}
}
