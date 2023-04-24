using UnityEditor;
using UnityEngine;

namespace CustomAttributes.Editor
{
	[CustomPropertyDrawer(typeof(IndentAttribute))]
	public class IndentDrawer : DecoratorDrawer
	{
		public override void OnGUI (Rect position)
		{
			IndentAttribute indentAttribute = attribute as IndentAttribute;
			EditorGUI.indentLevel += indentAttribute.IndentLevel;
		}

		public override float GetHeight () => 0;
	}
}