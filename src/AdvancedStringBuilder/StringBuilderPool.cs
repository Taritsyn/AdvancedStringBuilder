using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
#if NET40

using PolyfillsForOldDotNet.System.Threading;
#endif

namespace AdvancedStringBuilder
{
	/// <summary>
	/// Provides a resource pool that enables reusing instances of type <see cref="StringBuilder"/>.
	/// </summary>
	public abstract class StringBuilderPool
	{
		/// <summary>
		/// The lazily-initialized shared pool instance.
		/// </summary>
		private static StringBuilderPool s_sharedInstance = null;

		/// <summary>
		/// Retrieves a shared <see cref="StringBuilderPool"/> instance.
		/// </summary>
		public static StringBuilderPool Shared
		{
			[MethodImpl((MethodImplOptions)256 /* AggressiveInlining */)]
			get
			{
				return Volatile.Read(ref s_sharedInstance) ?? EnsureSharedCreated();
			}
		}


		/// <summary>
		/// Ensures that <see cref="s_sharedInstance"/> has been initialized to a pool and returns it.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static StringBuilderPool EnsureSharedCreated()
		{
			Interlocked.CompareExchange(ref s_sharedInstance, Create(), null);
			return s_sharedInstance;
		}

		/// <summary>
		/// Creates a new <see cref="StringBuilderPool"/> instance using the default configuration settings.
		/// </summary>
		/// <returns>A new <see cref="StringBuilderPool"/> instance.</returns>
		public static StringBuilderPool Create()
		{
			return new DefaultStringBuilderPool();
		}

		/// <summary>
		/// Creates a new <see cref="StringBuilderPool"/> instance using the specified pool size.
		/// </summary>
		/// <param name="poolSize">Maximum number of builders stored in the pool.</param>
		/// <returns>A new <see cref="StringBuilderPool"/> instance with the specified pool size.</returns>
		public static StringBuilderPool Create(int poolSize)
		{
			return new DefaultStringBuilderPool(poolSize);
		}

		/// <summary>
		/// Creates a new <see cref="StringBuilderPool"/> instance using the specified capacity settings.
		/// </summary>
		/// <param name="initialBuilderCapacity">Initial capacity of builder.</param>
		/// <param name="maxBuilderCapacity">Maximum capacity of builder.</param>
		/// <returns>A new <see cref="StringBuilderPool"/> instance with the specified capacity settings.</returns>
		public static StringBuilderPool Create(int initialBuilderCapacity, int maxBuilderCapacity)
		{
			return new DefaultStringBuilderPool(initialBuilderCapacity, maxBuilderCapacity);
		}

		/// <summary>
		/// Creates a new <see cref="StringBuilderPool"/> instance using the specified capacity settings and
		/// pool size.
		/// </summary>
		/// <param name="initialBuilderCapacity">Initial capacity of builder.</param>
		/// <param name="maxBuilderCapacity">Maximum capacity of builder.</param>
		/// <param name="poolSize">Maximum number of builders stored in the pool.</param>
		/// <returns>A new <see cref="StringBuilderPool"/> instance with the specified capacity settings and
		/// pool size.</returns>
		public static StringBuilderPool Create(int initialBuilderCapacity, int maxBuilderCapacity, int poolSize)
		{
			return new DefaultStringBuilderPool(initialBuilderCapacity, maxBuilderCapacity, poolSize);
		}

		/// <summary>
		/// Retrieves a instance of <see cref="StringBuilder"/> from the pool.
		/// </summary>
		/// <returns>Instance of <see cref="StringBuilder"/>.</returns>
		public abstract StringBuilder Rent();

		/// <summary>
		/// Retrieves a instance of <see cref="StringBuilder"/> with at least the given capacity from the pool.
		/// </summary>
		/// <remarks>
		/// If the capacity is less than or equal to our maximum capacity, then return builder from the pool.
		/// Otherwise create a new string builder, that will just get discarded when released.
		/// </remarks>
		/// <param name="capacity">Capacity of string builder.</param>
		/// <returns>Instance of <see cref="StringBuilder"/>.</returns>
		public abstract StringBuilder Rent(int capacity);

		/// <summary>
		/// Returns a instance of <see cref="StringBuilder"/> to the pool.
		/// </summary>
		/// <param name="builder">Instance of <see cref="StringBuilder"/>.</param>
		public abstract void Return(StringBuilder builder);
	}
}