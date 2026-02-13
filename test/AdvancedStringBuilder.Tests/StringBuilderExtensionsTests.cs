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
		public void AppendFormatLineWithOneArgument()
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
		public void AppendFormatLineWithTwoArguments()
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
		public void AppendFormatLineWithThreeArguments()
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
		public void AppendFormatLineWithFourArguments()
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
		public void AppendFormatLineWithProviderAndOneArgument()
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
		public void AppendFormatLineWithProviderAndTwoArguments()
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
		public void AppendFormatLineWithProviderAndThreeArguments()
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
		public void AppendFormatLineWithProviderAndFourArguments()
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

		[TestCase("  Hello, World!  ", "Hello, World!  ")]
		[TestCase("\r\nHi!\r\n", "Hi!\r\n")]
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
