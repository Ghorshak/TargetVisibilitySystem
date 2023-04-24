using UnityEngine;

namespace Target.Visibility.States
{
	public class ObscuredState : BaseVisibilityState
	{
		public override VisibilityState State => VisibilityState.OBSCURED;
		
		public CanvasGroup BannerCanvasGroup { get; set; }

		private float _animationProgress;
		private bool _runAnimation;

		public override void Enter (VisibilityState previousState)
		{
			base.Enter(previousState);
			Target.Renderer.enabled = true;
			// + some other stuff like applying non attackable, non hoverable, non selectable, deselect unit, disable outlines etc.

			if (previousState == VisibilityState.VISIBLE && Data.UseInitialAnimation)
			{
				_animationProgress = 0;
				_runAnimation = true;
			}
		}

		public override VisibilityState Execute (float deltaTime)
		{
			if (_runAnimation)
			{
				UpdateAnimation(deltaTime);
			}

			return TryChangeState();
		}

		private void UpdateAnimation (float deltaTime)
		{
			if ((_animationProgress += deltaTime) <= Data.AnimationDuration)
			{
				BannerCanvasGroup.alpha = Data.PulsingCurve.Evaluate(_animationProgress * Data.PulsingSpeed);
			}
			else
			{
				EndAnimation();
			}
		}

		private void EndAnimation ()
		{
			_runAnimation = false;
			Target.ScreenBanner.BannerImage.enabled = false;
			BannerCanvasGroup.alpha = 1;
		}

		protected override VisibilityState TryChangeState ()
		{
			VisibilityState newState = State;
			if (Target.IsVisible == false)
			{
				newState = VisibilityState.INVISIBLE;
			}
			else if (Target.IsVisible && Target.IsObscured == false)
			{
				newState = VisibilityState.VISIBLE;
			}

			return newState;
		}

		public override void Exit ()
		{
			if (_runAnimation)
			{
				EndAnimation();
			}

			base.Exit();
		}
	}
}