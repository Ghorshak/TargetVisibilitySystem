using UnityEngine;

namespace Player
{
	public class PlayerManager : MonoBehaviour
	{
		public Collider Collider { get; set; }

		private void Awake ()
		{
			Collider = GetComponent<Collider>();
		}
	}
}