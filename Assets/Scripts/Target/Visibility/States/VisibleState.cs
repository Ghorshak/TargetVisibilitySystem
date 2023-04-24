namespace Target.Visibility.States
{
	public class VisibleState : BaseVisibilityState
	{
		public override VisibilityState State => VisibilityState.VISIBLE;

		public override void Enter (VisibilityState previousState)
		{
			base.Enter(previousState);
			Target.Renderer.enabled = true;
			Target.ScreenBanner.BannerImage.enabled = true;
			// + some other stuff like applying attackable, hoverable, selectable, enable outlines etc.
		}

		public override VisibilityState Execute (float deltaTime)
		{
			return TryChangeState();
		}

		protected override VisibilityState TryChangeState ()
		{
			VisibilityState newState = State;
			if (Target.IsVisible == false)
			{
				newState = VisibilityState.INVISIBLE;
			}
			else if (Target.IsObscured)
			{
				newState = VisibilityState.OBSCURED;
			}

			return newState;
		}
	}
}