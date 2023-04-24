using System;
using UnityEngine;

namespace Target
{
	public interface ITargetable
	{
		event Action OnTargetDestroy;
		string Name { get; }
		Renderer Renderer { get; set; }
		ScreenBanner ScreenBanner { get; }
		Color AttitudeColor { get; }
		bool IsVisible { get; }
		bool IsObscured { get; }
	}
}