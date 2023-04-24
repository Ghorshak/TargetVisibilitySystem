using Player;
using Target.Creatures;
using Target.Visibility.States;
using UnityEngine;
using Zenject;

namespace Target.Visibility
{
	public class VisibilityController
	{
		public bool IsVisible { get; private set; }

		private VisibilityData VisibilityData { get; set; }
		private PlayerManager PlayerManager { get; set; }
		private Creature Creature { get; set; }

		private VisibilityStatesController StatesController { get; } = new();

		private Transform _creatureTransform;
		private Vector3 _playerWorldPosition;
		private float _interferenceDelayTimer;

		[Inject]
		public void Construct (VisibilityData visibilityData, PlayerManager playerManager, Creature creature)
		{
			VisibilityData = visibilityData;
			PlayerManager = playerManager;
			Creature = creature;
		}

		public void Initialize ()
		{
			_creatureTransform = Creature.transform;
			StatesController.Initialize(Creature, VisibilityData);
		}

		public void UpdateController (float deltaTime)
		{
			_playerWorldPosition = PlayerManager.transform.position;

			UpdateVisibility(deltaTime);
			StatesController.ExecuteState(deltaTime);
		}

		private void UpdateVisibility (float deltaTime)
		{
			bool isVisibleAfterCheck = CheckIsVisible();
			if (IsVisible && isVisibleAfterCheck == false)
			{
				_interferenceDelayTimer += deltaTime;
				if (_interferenceDelayTimer > VisibilityData.InterferenceDelay)
				{
					ChangeVisibility(false);
				}
			}
			else
			{
				ChangeVisibility(isVisibleAfterCheck);
			}

			void ChangeVisibility (bool isVisible)
			{
				IsVisible = isVisible;
				_interferenceDelayTimer = 0;
			}
		}

		private bool CheckIsVisible ()
		{
			var position = _creatureTransform.position;
			var direction = _playerWorldPosition - position;
			var length = Vector3.Distance(position, _playerWorldPosition);

			if (Physics.Raycast(position, direction, out var hit, length, VisibilityData.CheckLayerMask))
			{
				return hit.collider == PlayerManager.Collider;
			}

			return false;
		}
	}
}