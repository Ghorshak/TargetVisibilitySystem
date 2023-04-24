namespace Target.Visibility.States
{
	public class InvisibleState : BaseVisibilityState
	{
		public override VisibilityState State => VisibilityState.INVISIBLE;

		public override void Enter (VisibilityState previousState)
		{
			base.Enter(previousState);
			Target.Renderer.enabled = false;
			Target.ScreenBanner.BannerImage.enabled = false;
			// + some other stuff like applying non attackable, non hoverable, non selectable, deselect unit, disable outlines etc.
		}

		public override VisibilityState Execute (float deltaTime)
		{
			return TryChangeState();
		}

		protected override VisibilityState TryChangeState ()
		{
			VisibilityState newState = State;
			if (Target.IsVisible)
			{
				newState = Target.IsObscured ? VisibilityState.OBSCURED : VisibilityState.VISIBLE;
			}

			return newState;
		}
	}
}