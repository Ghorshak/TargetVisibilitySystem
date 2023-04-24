using System;
using UnityEngine;

namespace Target.Visibility.States
{
	public abstract class BaseVisibilityState
	{
		public Action<VisibilityState> OnStateEnter { get; } = delegate { };
		public Action OnStateExit { get; } = delegate { };

		public abstract VisibilityState State { get; }

		public VisibilityData Data { get; set; }
		public ITargetable Target { get; set; }

		public virtual void Enter (VisibilityState previousState)
		{
			Debug.Log($"{Target.Name} changed state to {State}");
			OnStateEnter?.Invoke(State);
		}

		public abstract VisibilityState Execute (float deltaTime);
		protected abstract VisibilityState TryChangeState ();

		public virtual void Exit ()
		{
			OnStateExit?.Invoke();
		}
	}
}