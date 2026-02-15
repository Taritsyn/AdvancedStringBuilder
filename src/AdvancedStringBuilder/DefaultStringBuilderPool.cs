using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

using AdvancedStringBuilder.Resources;

namespace AdvancedStringBuilder
{
	/// <summary>
	/// Provides a default implementation of the string builder pool.
	/// </summary>
	internal sealed class DefaultStringBuilderPool : StringBuilderPool
	{
		/// <summary>
		/// The default initial capacity of builder.
		/// </summary>
		private const int DefaultInitialBuilderCapacity = 100;

		/// <summary>
		/// The default maximum capacity of builder.
		/// </summary>
		private const int DefaultMaxBuilderCapacity = 8 * 1024;

		/// <summary>
		/// Number of builders per processor.
		/// </summary>
		private const int BuilderCountPerProcessor = 5;

		/// <summary>
		/// Initial capacity of builder.
		/// </summary>
		private readonly int _initialBuilderCapacity;

		/// <summary>
		/// Maximum capacity of builder.
		/// </summary>
		private readonly int _maxBuilderCapacity;

		/// <summary>
		/// First builder.
		/// </summary>
		/// <remarks>
		/// The first builder is stored in a dedicated field, because we expect to be able to satisfy
		/// most requests from it.
		/// </remarks>
		private StringBuilder? _firstBuilder;

		/// <summary>
		/// Array of the retained builders.
		/// </summary>
		private readonly StringBuilder?[] _builders;


		/// <summary>
		/// Constructs an instance of the default pool of string builders using the default configuration settings.
		/// </summary>
		internal DefaultStringBuilderPool()
			: this(DefaultInitialBuilderCapacity, DefaultMaxBuilderCapacity, Environment.ProcessorCount * BuilderCountPerProcessor)
		{ }

		/// <summary>
		/// Constructs an instance of the default pool of string builders using the specified pool size.
		/// </summary>
		/// <param name="poolSize">Maximum number of builders stored in the pool.</param>
		internal DefaultStringBuilderPool(int poolSize)
			: this(DefaultInitialBuilderCapacity, DefaultMaxBuilderCapacity, poolSize)
		{ }

		/// <summary>
		/// Constructs an instance of the default pool of string builders using the specified capacity settings.
		/// </summary>
		/// <param name="initialBuilderCapacity">Initial capacity of builder.</param>
		/// <param name="maxBuilderCapacity">Maximum capacity of builder.</param>
		internal DefaultStringBuilderPool(int initialBuilderCapacity, int maxBuilderCapacity)
			: this(initialBuilderCapacity, maxBuilderCapacity, Environment.ProcessorCount * BuilderCountPerProcessor)
		{ }

		/// <summary>
		/// Constructs an instance of the default pool of string builders using the specified capacity settings and
		/// pool size.
		/// </summary>
		/// <param name="initialBuilderCapacity">Initial capacity of builder.</param>
		/// <param name="maxBuilderCapacity">Maximum capacity of builder.</param>
		/// <param name="poolSize">Maximum number of builders stored in the pool.</param>
		internal DefaultStringBuilderPool(int initialBuilderCapacity, int maxBuilderCapacity, int poolSize)
		{
			if (initialBuilderCapacity <= 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(initialBuilderCapacity),
					Strings.ArgumentOutOfRange_InitialBuilderCapacityNonPositive
				);
			}

			if (maxBuilderCapacity <= 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(maxBuilderCapacity),
					Strings.ArgumentOutOfRange_MaxBuilderCapacityNonPositive
				);
			}

			if (poolSize <= 0)
			{
				throw new ArgumentOutOfRangeException(
					nameof(poolSize),
					Strings.ArgumentOutOfRange_PoolSizeNonPositive
				);
			}

			if (initialBuilderCapacity > maxBuilderCapacity)
			{
				throw new ArgumentOutOfRangeException(
					nameof(initialBuilderCapacity),
					string.Format(Strings.ArgumentOutOfRange_InitialBuilderCapacityGreaterThanMaxBuilderCapacity,
						maxBuilderCapacity)
				);
			}

			_initialBuilderCapacity = initialBuilderCapacity;
			_maxBuilderCapacity = maxBuilderCapacity;
			_builders = new StringBuilder[poolSize - 1];
		}


		public override StringBuilder Rent()
		{
			// Examine the first builder.
			// If that fails, then `RentViaScan` method will look at the remaining builders.
			StringBuilder? builder = _firstBuilder;
			if (builder is null || builder != Interlocked.CompareExchange(ref _firstBuilder, null, builder))
			{
				builder = RentViaScan();
			}

			return builder;
		}

		public override StringBuilder Rent(int capacity)
		{
			if (capacity <= _maxBuilderCapacity)
			{
				return Rent();
			}

			return new StringBuilder(capacity);
		}

		[MethodImpl((MethodImplOptions)256 /* AggressiveInlining */)]
		private StringBuilder RentViaScan()
		{
			StringBuilder?[] builders = _builders;
			int builderCount = builders.Length;

			for (int builderIndex = 0; builderIndex < builderCount; builderIndex++)
			{
				StringBuilder? builder = builders[builderIndex];
				if (builder is not null)
				{
					if (builder == Interlocked.CompareExchange(ref builders[builderIndex], null, builder))
					{
						return builder;
					}
				}
			}

			return new StringBuilder(_initialBuilderCapacity);
		}

		public override void Return(StringBuilder builder)
		{
			if (builder is null || builder.Capacity > _maxBuilderCapacity)
			{
				return;
			}

			if (_firstBuilder is null)
			{
				builder.Clear();
				_firstBuilder = builder;
			}
			else
			{
				ReturnViaScan(builder);
			}
		}

		[MethodImpl((MethodImplOptions)256 /* AggressiveInlining */)]
		private void ReturnViaScan(StringBuilder builder)
		{
			StringBuilder?[] builders = _builders;
			int builderCount = builders.Length;

			for (int builderIndex = 0; builderIndex < builderCount; builderIndex++)
			{
				if (builders[builderIndex] is null)
				{
					builder.Clear();
					builders[builderIndex] = builder;
					break;
				}
			}
		}
	}
}