using UnityEngine;

namespace Target
{
	[CreateAssetMenu(fileName = nameof(AttitudeData), menuName = "Data/Target/Attitude Data")]
	public class AttitudeData : ScriptableObject
	{
		[field: SerializeField] public AttitudeType Attitude { get; private set; }
		[field: SerializeField] public Color Color { get; private set; }
	}
}