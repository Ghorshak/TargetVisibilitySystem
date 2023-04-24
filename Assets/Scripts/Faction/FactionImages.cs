using System;
using UnityEngine;

namespace Faction
{
	[Serializable]
	public class FactionImages
	{
		[field: SerializeField] public Sprite BannerImage { get; set; }
		[field: SerializeField] public Sprite SimpleImage { get; set; }
	}
}