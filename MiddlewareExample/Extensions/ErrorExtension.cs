using System.Diagnostics;

namespace MiddlewareExample.Extensions
{
    public class ErrorExtension
    {
		private static StackFrame GetStackFrame(Exception ex)
		{
			return new StackTrace(ex, true).GetFrame(0) ?? new StackFrame();
		}

		public static int GetErrorLineNumber(Exception ex)
		{
			return GetStackFrame(ex).GetFileLineNumber();
		}

		public static string GetErrorMethodName(Exception ex)
		{
			var sf = GetStackFrame(ex);

			if (sf.GetMethod() != null && StringExtension.IsValid(sf.GetMethod().Name))
			{
				return sf.GetMethod().Name;
			}

			return String.Empty;
		}

		public static string GetErrorFileName(Exception ex)
		{
			return GetStackFrame(ex).GetFileName() ?? String.Empty;
		}
	}
}
