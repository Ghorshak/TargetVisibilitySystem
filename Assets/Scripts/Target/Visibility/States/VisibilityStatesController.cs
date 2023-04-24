using System.Collections.Generic;

namespace Target.Visibility.States
{
	public class VisibilityStatesController
	{
		public BaseVisibilityState CurrentState { get; private set; }

		private BaseVisibilityState this [VisibilityState key] => States[key];
		private Dictionary<VisibilityState, BaseVisibilityState> States { get; set; }

		private ITargetable Target { get; set; }

		public void Initialize (ITargetable target, VisibilityData visibilityData)
		{
			Target = target;

			States = new()
			{
				{ VisibilityState.VISIBLE, new VisibleState { Data = visibilityData, Target = Target } },
				{ VisibilityState.OBSCURED, new ObscuredState { Data = visibilityData, Target = Target,
					BannerCanvasGroup = Target.ScreenBanner.BannerCanvasGroup } },
				{ VisibilityState.INVISIBLE, new InvisibleState { Data = visibilityData, Target = Target } },
			};

			EnterNewState(States[VisibilityState.INVISIBLE]);
		}

		private void EnterNewState (BaseVisibilityState state, VisibilityState previousState = VisibilityState.INVISIBLE)
		{
			CurrentState = state;
			state.Enter(previousState);
		}

		public void ExecuteState (float deltaTime)
		{
			VisibilityState newState = CurrentState.Execute(deltaTime);
			if (newState != CurrentState.State)
			{
				EnterState(newState);
			}
		}

		private void EnterState (VisibilityState newState)
		{
			var state = States[newState];
			SetCurrentState();

			void SetCurrentState ()
			{
				CurrentState?.Exit();
				var previousState = CurrentState?.State ?? VisibilityState.INVISIBLE;
				EnterNewState(state, previousState);
			}
		}
	}
}