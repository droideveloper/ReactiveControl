using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveControls.Common {
	
	public static class Extensions {

		public static string ToLogString(this LogLevel level) {
			switch(level) {
				case LogLevel.DEBUG:
					return "D/";
				case LogLevel.WARN:
					return "W/";
				case LogLevel.INFO:
					return "I/";
				case LogLevel.ERROR:
					return "E/";
				case LogLevel.VERBOSE:
					return "V/";
				case LogLevel.WTF:
					return "WTF/";
				default:
					throw new ArgumentOutOfRangeException("no such log level");
			}
		}

		public static void Log<TSource>(this TSource type, string message) where TSource: LogType {
			type.Log(LogLevel.DEBUG, message);
		}

		public static void Log<TSource>(this TSource type, Exception error) where TSource: LogType {
			type.Log(LogLevel.ERROR, error.StackTrace);
		}

		public static void Log<TSource>(this TSource type, LogLevel level, string message) where TSource: LogType {
			if (type.isLogEnabled()) {
				Console.WriteLine("{0}{1}: {2}", level.ToLogString(), type.getClassTag(), message);
			}
		}
	}
}
