using System;
using Faction;
using Target.Visibility;
using UnityEngine;

namespace Target.Creatures
{
	public class Creature : MonoBehaviour, ITargetable
	{
		public event Action OnTargetDestroy = delegate { };

		[field: SerializeField] public string Name { get; private set; }
		[field: SerializeField] public Renderer Renderer { get; set; }
		[field: SerializeField] public ScreenBanner ScreenBanner { get; set; }

		[field: Header("Data")]
		[field: SerializeField] public FactionData FactionData { get; set; }
		[field: SerializeField] public AttitudeData AttitudeData { get; set; }

		public VisibilityController VisibilityController { get; } = new();

		public Color AttitudeColor => AttitudeData.Color;
		public bool IsVisible => VisibilityController.IsVisible;

		// TODO: implement IsObscured in VisibilityController, added here and SerializeFielded for testing
		[field: SerializeField] public bool IsObscured { get; set; }

		private void Awake ()
		{
			VisibilityController.Initialize();
		}

		private void Update ()
		{
			VisibilityController.UpdateController(Time.deltaTime);
		}

		private void OnDestroy ()
		{
			// TODO: temporary
			OnTargetDestroy?.Invoke();
		}
	}
}