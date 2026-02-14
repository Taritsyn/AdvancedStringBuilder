using System;
using System.Text;

namespace AdvancedStringBuilder
{
	/// <summary>
	/// Extensions for StringBuilder
	/// </summary>
	public static class StringBuilderExtensions
	{
		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance.
		/// Each format item is replaced by the string representation of a single argument.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">An object to format.</param>
		/// <returns>A reference to this instance with <paramref name="format"/> and default line terminator
		/// appended. Each format item in <paramref name="format"/> is replaced by the string representation
		/// of <paramref name="arg0"/>.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, string format, object arg0)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(format, arg0)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of either of two arguments.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A reference to this instance with <paramref name="format"/> and default line terminator
		/// appended. Each format item in <paramref name="format"/> is replaced by the string representation
		/// of the corresponding object argument.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, string format, object arg0,
			object arg1)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(format, arg0, arg1)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of either of three arguments.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A reference to this instance with <paramref name="format"/> and default line terminator
		/// appended. Each format item in <paramref name="format"/> is replaced by the string representation
		/// of the corresponding object argument.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, string format, object arg0,
			object arg1, object arg2)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(format, arg0, arg1, arg2)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance.
		/// Each format item is replaced by the string representation of a corresponding argument in a
		/// parameter array.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An array of objects to format.</param>
		/// <returns>A reference to this instance with <paramref name="format"/> and default line terminator
		/// appended. Each format item in <paramref name="format"/> is replaced by the string representation
		/// of the corresponding object argument.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, string format,
			params object[] args)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(format, args)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of a single argument using a specified format provider.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The object to format.</param>
		/// <returns>A reference to this instance after the append operation has completed. After the append
		/// operation, this instance contains any data that existed before the operation, suffixed by a copy
		/// of <paramref name="format"/> in which any format specification is replaced by the string
		/// representation of <paramref name="arg0"/>, and default line terminator.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, IFormatProvider provider,
			string format, object arg0)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(provider, format, arg0)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of either of two arguments using a specified format provider.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <returns>A reference to this instance after the append operation has completed. After the append
		/// operation, this instance contains any data that existed before the operation, suffixed by a copy
		/// of <paramref name="format"/> where any format specification is replaced by the string representation
		/// of the corresponding object argument, and default line terminator.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, IFormatProvider provider,
			string format, object arg0, object arg1)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(provider, format, arg0, arg1)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of either of three arguments using a specified format provider.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="arg0">The first object to format.</param>
		/// <param name="arg1">The second object to format.</param>
		/// <param name="arg2">The third object to format.</param>
		/// <returns>A reference to this instance after the append operation has completed. After the append
		/// operation, this instance contains any data that existed before the operation, suffixed by a copy
		/// of <paramref name="format"/> where any format specification is replaced by the string representation
		/// of the corresponding object argument, and default line terminator.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, IFormatProvider provider,
			string format, object arg0, object arg1, object arg2)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(provider, format, arg0, arg1, arg2)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Appends the string returned by processing a composite format string, which contains zero or more
		/// format items, with default line terminator to this instance. Each format item is replaced by the
		/// string representation of a corresponding argument in a parameter array using a specified format
		/// provider.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An array of objects to format.</param>
		/// <returns>A reference to this instance after the append operation has completed. After the append
		/// operation, this instance contains any data that existed before the operation, suffixed by a copy
		/// of <paramref name="format"/> where any format specification is replaced by the string representation
		/// of the corresponding object argument, and default line terminator.</returns>
		public static StringBuilder AppendFormatLine(this StringBuilder source, IFormatProvider provider,
			string format, params object[] args)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			source
				.AppendFormat(provider, format, args)
				.AppendLine()
				;

			return source;
		}

		/// <summary>
		/// Removes the all leading and trailing white-space characters from the current <see cref="StringBuilder"/> instance.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <returns>Instance of <see cref="StringBuilder"/> without leading and trailing white-space characters.</returns>
		public static StringBuilder Trim(this StringBuilder source)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			TrimWhiteSpaceHelper(source, TrimType.Both);

			return source;
		}

		/// <summary>
		/// Removes the all leading white-space characters from the current <see cref="StringBuilder"/> instance.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <returns>Instance of <see cref="StringBuilder"/> without leading white-space characters.</returns>
		public static StringBuilder TrimStart(this StringBuilder source)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			TrimWhiteSpaceHelper(source, TrimType.Head);

			return source;
		}

		/// <summary>
		/// Removes the all trailing white-space characters from the current <see cref="StringBuilder"/> instance.
		/// </summary>
		/// <param name="source">Instance of <see cref="StringBuilder"/>.</param>
		/// <returns>Instance of <see cref="StringBuilder"/> without trailing white-space characters.</returns>
		public static StringBuilder TrimEnd(this StringBuilder source)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			TrimWhiteSpaceHelper(source, TrimType.Tail);

			return source;
		}

		private static void TrimWhiteSpaceHelper(StringBuilder sb, TrimType trimType)
		{
			int charCount = sb.Length;
			if (charCount == 0)
			{
				return;
			}

			int lastCharIndex = charCount - 1;
			int leftCharIndex = 0; // position of the first non-trimmed character on the left
			int rightCharIndex = lastCharIndex; // position of the first non-trimmed character on the right

			if ((trimType & TrimType.Head) == TrimType.Head)
			{
				while (leftCharIndex < charCount)
				{
					char charValue = sb[leftCharIndex];
					if (!char.IsWhiteSpace(charValue))
					{
						break;
					}

					leftCharIndex++;
				}

				if (leftCharIndex > lastCharIndex)
				{
					sb.Clear();
					return;
				}
			}

			if ((trimType & TrimType.Tail) == TrimType.Tail)
			{
				while (rightCharIndex >= 0)
				{
					char charValue = sb[rightCharIndex];
					if (!char.IsWhiteSpace(charValue))
					{
						break;
					}

					rightCharIndex--;
				}

				if (rightCharIndex < 0)
				{
					sb.Clear();
					return;
				}
			}

			if (rightCharIndex < lastCharIndex)
			{
				sb.Length = rightCharIndex + 1;
			}

			if (leftCharIndex > 0)
			{
				sb.Remove(0, leftCharIndex);
			}
		}
	}
}