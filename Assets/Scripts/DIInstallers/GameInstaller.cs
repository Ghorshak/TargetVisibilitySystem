using Player;
using Target.Visibility;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
	[field: SerializeField] private PlayerManager PlayerManager { get; set; }
	[field: SerializeField] private VisibilityData VisibilityData { get; set; }

	public override void InstallBindings ()
	{
		Container.Bind<PlayerManager>().FromInstance(PlayerManager).AsSingle().NonLazy();

		BindData();
	}

	private void BindData ()
	{
		Container.Bind<VisibilityData>().FromScriptableObject(VisibilityData).AsSingle().NonLazy();
	}
}