using UnityEngine;

namespace Faction
{
	[CreateAssetMenu(fileName = nameof(FactionData), menuName = "Data/Faction/Faction Data")]
	public class FactionData : ScriptableObject
	{
		[field: SerializeField] public string FactionName { get; private set; }

		[field: SerializeField, Tooltip("Contains every possible image used by a faction.")]
		public FactionImages FactionImages { get; private set; }
	}
}