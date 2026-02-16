using System;
using System.Globalization;
using System.Text;

using NUnit.Framework;

namespace AdvancedStringBuilder.Tests
{
	[TestFixture]
	public class StringBuilderExtensionsTests
	{
		[Test]
		public void AppendFormatLineWithFormatStringAndOneArgument()
		{
			// Arrange
			var builder = new StringBuilder("Hello");

			const string format = ", Foo {0}";
			const string arg0 = "Bar";

			string targetOutput = "Hello, Foo Bar" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(format, arg0);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithFormatStringAndTwoArguments()
		{
			// Arrange
			var builder = new StringBuilder("Hello");

			const string format = ", Foo {0} Baz {1}";
			const string arg0 = "Bar";
			const string arg1 = "Foo";

			string targetOutput = "Hello, Foo Bar Baz Foo" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(format, arg0, arg1);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithFormatStringAndThreeArguments()
		{
			// Arrange
			var builder = new StringBuilder("Hello");

			const string format = ", Foo {0} Baz {1} Bar {2}";
			const string arg0 = "Bar";
			const string arg1 = "Foo";
			const string arg2 = "Baz";

			string targetOutput = "Hello, Foo Bar Baz Foo Bar Baz" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(format, arg0, arg1, arg2);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithFormatStringAndFourArguments()
		{
			// Arrange
			var builder = new StringBuilder("Hello");

			const string format = ", Foo {0} Baz {1} Bar {2} Foo {3}";
			const string arg0 = "Bar";
			const string arg1 = "Foo";
			const string arg2 = "Baz";
			const string arg3 = "Bar";

			string targetOutput = "Hello, Foo Bar Baz Foo Bar Baz Foo Bar" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(format, arg0, arg1, arg2, arg3);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithFormatStringAndManyArguments()
		{
			// Arrange
			var builder = new StringBuilder("Hello");

			const string format = ", Foo {0} Baz {1} Bar {2} Foo {3} Baz {4}";
			object[] args = ["Bar", "Foo", "Baz", "Bar", "..."];

			string targetOutput = "Hello, Foo Bar Baz Foo Bar Baz Foo Bar Baz ..." + Environment.NewLine;

			// Act
			builder.AppendFormatLine(format, args);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatStringAndOneArgument()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			const string format = "{0}";
			int arg0 = 1;

			string targetOutput = "1" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatStringAndTwoArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			const string format = "{0}, {1}";
			int arg0 = 1;
			long arg1 = 2;

			string targetOutput = "1, 2" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatStringAndThreeArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			const string format = "{0}, {1}, {2}";
			int arg0 = 1;
			long arg1 = 2;
			decimal arg2 = 3;

			string targetOutput = "1, 2, 3" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1, arg2);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatStringAndFourArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			const string format = "{0}, {1}, {2}, {3}";
			int arg0 = 1;
			long arg1 = 2;
			decimal arg2 = 3;
			double arg3 = 4;

			string targetOutput = "1, 2, 3, 4" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1, arg2, arg3);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatStringAndManyArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			const string format = "{0}, {1}, {2}, {3}, {4}";
			object[] args = [1, 2, 3, 4, "..."];

			string targetOutput = "1, 2, 3, 4, ..." + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, args);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}
#if NET8_0_OR_GREATER

		[Test]
		public void AppendFormatLineWithProviderAndFormatCompositeAndOneArgument()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			CompositeFormat format = CompositeFormat.Parse("{0}");
			int arg0 = 1;

			string targetOutput = "1" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatCompositeAndTwoArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			CompositeFormat format = CompositeFormat.Parse("{0}, {1}");
			int arg0 = 1;
			long arg1 = 2;

			string targetOutput = "1, 2" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatCompositeAndThreeArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			CompositeFormat format = CompositeFormat.Parse("{0}, {1}, {2}");
			int arg0 = 1;
			long arg1 = 2;
			decimal arg2 = 3;

			string targetOutput = "1, 2, 3" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1, arg2);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatCompositeAndFourArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			CompositeFormat format = CompositeFormat.Parse("{0}, {1}, {2}, {3}");
			int arg0 = 1;
			long arg1 = 2;
			decimal arg2 = 3;
			double arg3 = 4;

			string targetOutput = "1, 2, 3, 4" + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, arg0, arg1, arg2, arg3);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}

		[Test]
		public void AppendFormatLineWithProviderAndFormatCompositeAndManyArguments()
		{
			// Arrange
			var builder = new StringBuilder();

			IFormatProvider provider = CultureInfo.InvariantCulture;
			CompositeFormat format = CompositeFormat.Parse("{0}, {1}, {2}, {3}, {4}");
			object[] args = [1, 2, 3, 4, "..."];

			string targetOutput = "1, 2, 3, 4, ..." + Environment.NewLine;

			// Act
			builder.AppendFormatLine(provider, format, args);
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(targetOutput, output);
		}
#endif

		[TestCase("  Hello, World!  ", "Hello, World!")]
		[TestCase("\r\nHi!\r\n", "Hi!")]
		[TestCase("\t|\t", "|")]
		[TestCase("      \r\n      ", "")]
		[TestCase("      \t      ", "")]
		[TestCase("      ", "")]
		[TestCase("", "")]
		public void Trim(string s, string expected)
		{
			// Arrange
			var builder = new StringBuilder(s);

			// Act
			builder.Trim();
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(expected, output);
		}

		[TestCase("  Hello, World!  ", "Hello, World!  ")]
		[TestCase("\r\nHi!\r\n", "Hi!\r\n")]
		[TestCase("\t|\t", "|\t")]
		[TestCase("      \r\n      ", "")]
		[TestCase("      \t      ", "")]
		[TestCase("      ", "")]
		[TestCase("", "")]
		public void TrimStart(string s, string expected)
		{
			// Arrange
			var builder = new StringBuilder(s);

			// Act
			builder.TrimStart();
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(expected, output);
		}

		[TestCase("  Hello, World!  ", "  Hello, World!")]
		[TestCase("\r\nHi!\r\n", "\r\nHi!")]
		[TestCase("\t|\t", "\t|")]
		[TestCase("      \r\n      ", "")]
		[TestCase("      \t      ", "")]
		[TestCase("      ", "")]
		[TestCase("", "")]
		public void TrimEnd(string s, string expected)
		{
			// Arrange
			var builder = new StringBuilder(s);

			// Act
			builder.TrimEnd();
			string output = builder.ToString();

			// Assert
			Assert.AreEqual(expected, output);
		}
	}
}
