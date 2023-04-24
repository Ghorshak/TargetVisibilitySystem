using System;
using UnityEngine;

namespace CustomAttributes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class IndentAttribute : PropertyAttribute
	{
		public readonly int IndentLevel;

		public IndentAttribute (int indentLevel = 1)
		{
			IndentLevel = indentLevel;
		}
	}
}