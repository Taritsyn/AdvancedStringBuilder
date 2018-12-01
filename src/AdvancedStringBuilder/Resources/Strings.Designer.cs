//------------------------------------------------------------------------------
// <auto-generated>
//	 This code was generated by a tool.
//
//	 Changes to this file may cause incorrect behavior and will be lost if
//	 the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace AdvancedStringBuilder.Resources
{
	using System;
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	/// <summary>
	/// A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	internal class Strings
	{
		private static Lazy<ResourceManager> _resourceManager =
			new Lazy<ResourceManager>(() => new ResourceManager(
				"AdvancedStringBuilder.Resources.Strings",
#if NET40
				typeof(Strings).Assembly
#else
				typeof(Strings).GetTypeInfo().Assembly
#endif
			));

		private static CultureInfo _resourceCulture;

		/// <summary>
		/// Returns a cached ResourceManager instance used by this class
		/// </summary>
		internal static ResourceManager ResourceManager
		{
			get
			{
				return _resourceManager.Value;
			}
		}

		/// <summary>
		/// Overrides a current thread's CurrentUICulture property for all
		/// resource lookups using this strongly typed resource class
		/// </summary>
		internal static CultureInfo Culture
		{
			get
			{
				return _resourceCulture;
			}
			set
			{
				_resourceCulture = value;
			}
		}

		/// <summary>
		/// Looks up a localized string similar to "Initial capacity of builder must be less than or equal to the maximum capacity - {0}."
		/// </summary>
		internal static string ArgumentOutOfRange_InitialBuilderCapacityGreaterThanMaxBuilderCapacity
		{
			get { return GetString("ArgumentOutOfRange_InitialBuilderCapacityGreaterThanMaxBuilderCapacity"); }
		}

		/// <summary>
		/// Looks up a localized string similar to "Initial capacity of builder must be a positive value."
		/// </summary>
		internal static string ArgumentOutOfRange_InitialBuilderCapacityNonPositive
		{
			get { return GetString("ArgumentOutOfRange_InitialBuilderCapacityNonPositive"); }
		}

		/// <summary>
		/// Looks up a localized string similar to "Maximum capacity of builder must be a positive value."
		/// </summary>
		internal static string ArgumentOutOfRange_MaxBuilderCapacityNonPositive
		{
			get { return GetString("ArgumentOutOfRange_MaxBuilderCapacityNonPositive"); }
		}

		/// <summary>
		/// Looks up a localized string similar to "Pool size must be a positive value."
		/// </summary>
		internal static string ArgumentOutOfRange_PoolSizeNonPositive
		{
			get { return GetString("ArgumentOutOfRange_PoolSizeNonPositive"); }
		}

		private static string GetString(string name)
		{
			string value = ResourceManager.GetString(name, _resourceCulture);

			return value;
		}
	}
}