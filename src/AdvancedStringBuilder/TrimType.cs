// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Text
{
	/// <summary>
	/// Specifies which portions of the <see cref="StringBuilder"/> instance should be trimmed in a trimming operation.
	/// </summary>
	[Flags]
	internal enum TrimType
	{
		/// <summary>
		/// Trim from the beginning of the <see cref="StringBuilder"/> instance.
		/// </summary>
		Head = 1 << 0,

		/// <summary>
		/// Trim from the end of the <see cref="StringBuilder"/> instance.
		/// </summary>
		Tail = 1 << 1,

		/// <summary>
		/// Trim from both the beginning and the end of the <see cref="StringBuilder"/> instance.
		/// </summary>
		Both = Head | Tail
	}
}