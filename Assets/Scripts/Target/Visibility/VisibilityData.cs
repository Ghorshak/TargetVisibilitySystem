using CustomAttributes;
using UnityEngine;

namespace Target.Visibility
{
	[CreateAssetMenu(fileName = nameof(VisibilityData), menuName = "Data/Target/Visibility Data")]
	public class VisibilityData : ScriptableObject
	{
		[field: Space, Header("General Visibility Settings")]
		[field: SerializeField, Tooltip("Layer mask included in raycast check while determining visibility of a target object.")]
		public LayerMask CheckLayerMask { get; private set; }

		[field: SerializeField, Min(0), Tooltip("Delay after which target object will become invisible. " +
				"This delay should be relatively low and be used only to mitigate small objects interference.")]
		public float InterferenceDelay { get; private set; } = 0.1f;

		// TODO: consider to separate those settings per each state
		// TODO: (this one only applies to the ObscuredState at the moment, but also may change in the future)
		[field: Space, Header("State's Animation Settings")]
		[field: SerializeField, Tooltip("Turns on/off animation started on state enter.")]
		public bool UseInitialAnimation { get; private set; } = true;

		[field: SerializeField, Tooltip("Animation's duration in seconds."), Indent, Min(0)]
		public float AnimationDuration { get; private set; } = 2.5f;

		[field: SerializeField, Tooltip("Animation curve used to represent pulsing effect. Should be set to ping pong."), Indent]
		public AnimationCurve PulsingCurve { get; private set; }

		[field: SerializeField, Tooltip("Animation speed in seconds."), Indent, Min(0)]
		public float PulsingSpeed { get; private set; } = 1;
	}
}