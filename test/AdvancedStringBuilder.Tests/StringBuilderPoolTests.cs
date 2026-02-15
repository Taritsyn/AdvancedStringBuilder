using System;
using System.Text;

using NUnit.Framework;

namespace AdvancedStringBuilder.Tests
{
	[TestFixture]
	public class StringBuilderPoolTests
	{
		[Test]
		public void CreatingInstanceOfPool()
		{
			// Arrange
			StringBuilderPool? pool = null;

			// Act
			pool = StringBuilderPool.Create();

			// Assert
			Assert.IsNotNull(pool);
		}

		[TestCase(10)]
		public void CreatingInstanceOfPoolWithSize(int poolSize)
		{
			// Arrange
			StringBuilderPool? pool = null;

			// Act
			pool = StringBuilderPool.Create(poolSize);

			// Assert
			Assert.IsNotNull(pool);
		}

		[TestCase(0)]
		[TestCase(-1)]
		public void CreatingInstanceOfPoolWithInvalidSize(int poolSize)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => StringBuilderPool.Create(poolSize));
		}

		[TestCase(128, 4096)]
		public void CreatingInstanceOfPoolWithBuilderCapacity(int initialBuilderCapacity,
			int maxBuilderCapacity)
		{
			// Arrange
			StringBuilderPool? pool = null;

			// Act
			pool = StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity);
			StringBuilder builder = pool.Rent();

			// Assert
			Assert.IsNotNull(pool);
			Assert.AreEqual(initialBuilderCapacity, builder.Capacity);
		}

		[TestCase(0, 4096)]
		[TestCase(-1, 4096)]
		[TestCase(128, 0)]
		[TestCase(128, -1)]
		[TestCase(128, 126)]
		[TestCase(0, 0)]
		[TestCase(0, -1)]
		[TestCase(-1, -1)]
		[TestCase(-1, 0)]
		public void CreatingInstanceOfPoolWithInvalidBuilderCapacity(int initialBuilderCapacity,
			int maxBuilderCapacity)
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() => StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity));
		}

		[TestCase(100, 8192, 5)]
		public void CreatingInstanceOfPoolWithBuilderCapacityAndSize(int initialBuilderCapacity,
			int maxBuilderCapacity, int poolSize)
		{
			// Arrange
			StringBuilderPool? pool = null;

			// Act
			pool = StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity, poolSize);
			StringBuilder builder = pool.Rent();

			// Assert
			Assert.IsNotNull(pool);
			Assert.AreEqual(initialBuilderCapacity, builder.Capacity);
		}

		[TestCase(0, 4096, 5)]
		[TestCase(-1, 4096, 5)]
		[TestCase(128, 0, 5)]
		[TestCase(128, -1, 5)]
		[TestCase(128, 126, 5)]
		[TestCase(0, 0, 5)]
		[TestCase(0, -1, 5)]
		[TestCase(-1, -1, 5)]
		[TestCase(-1, 0, 5)]
		public void CreatingInstanceOfPoolWithInvalidBuilderCapacityAndSize(int initialBuilderCapacity,
			int maxBuilderCapacity, int poolSize)
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() => StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity, poolSize));
		}

		[TestCase(128, 4096, 0)]
		[TestCase(128, 4096, -1)]
		public void CreatingInstanceOfPoolWithBuilderCapacityAndInvalidSize(int initialBuilderCapacity,
			int maxBuilderCapacity, int poolSize)
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() => StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity, poolSize));
		}

		[TestCase(0, 0, 0)]
		[TestCase(-1, -1, -1)]
		public void CreatingInstanceOfPoolWithInvalidBuilderCapacityAndInvalidSize(int initialBuilderCapacity,
			int maxBuilderCapacity, int poolSize)
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() => StringBuilderPool.Create(initialBuilderCapacity, maxBuilderCapacity, poolSize));
		}

		[Test]
		public void CreatingSharedInstanceOfPoolOnFirstCall()
		{
			// Arrange
			StringBuilderPool? pool = null;

			// Act
			pool = StringBuilderPool.Shared;

			// Assert
			Assert.IsNotNull(pool);
		}

		[Test]
		public void RentingAndReturningBuilder()
		{
			// Arrange
			StringBuilderPool pool = StringBuilderPool.Create();
			const string input = "Test";

			// Act
			StringBuilder builder = pool.Rent();

			builder.Append(input);
			string contentBeforeReturn = builder.ToString();

			pool.Return(builder);
			string contentsAfterReturn = builder.ToString();

			// Assert
			Assert.IsNotNull(builder);
			Assert.AreEqual(input, contentBeforeReturn);
			Assert.IsEmpty(contentsAfterReturn);
		}

		[Test]
		public void RentingAndReturningBuilderWithCapacity()
		{
			// Arrange
			const int initialCapacity = 100;
			const int maxCapacity = 1024;
			StringBuilderPool pool = StringBuilderPool.Create(initialCapacity, maxCapacity);

			int requestedCapacity = 512;
			const string input = "Test";

			// Act
			StringBuilder builder = pool.Rent(requestedCapacity);
			int capacity = builder.Capacity;

			builder.Append(input);
			string contentBeforeReturn = builder.ToString();

			pool.Return(builder);
			string contentsAfterReturn = builder.ToString();

			// Assert
			Assert.IsNotNull(builder);
			Assert.AreEqual(initialCapacity, capacity);
			Assert.AreEqual(input, contentBeforeReturn);
			Assert.IsEmpty(contentsAfterReturn);
		}

		[Test]
		public void RentingAndReturningBuilderWithExceedingCapacity()
		{
			// Arrange
			const int initialCapacity = 100;
			const int maxCapacity = 1024;
			StringBuilderPool pool = StringBuilderPool.Create(initialCapacity, maxCapacity);

			int requestedCapacity = 1028;
			const string input = "Test";

			// Act
			StringBuilder builder = pool.Rent(requestedCapacity);
			int capacity = builder.Capacity;

			builder.Append(input);
			string contentBeforeReturn = builder.ToString();

			pool.Return(builder);
			string contentsAfterReturn = builder.ToString();

			// Assert
			Assert.IsNotNull(builder);
			Assert.AreEqual(requestedCapacity, capacity);
			Assert.AreEqual(input, contentBeforeReturn);
			Assert.AreEqual(input, contentsAfterReturn);
		}
	}
}