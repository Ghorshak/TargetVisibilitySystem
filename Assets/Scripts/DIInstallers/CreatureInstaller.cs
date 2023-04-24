using Faction;
using Target.Creatures;
using Target.Visibility;
using UnityEngine;
using Zenject;

namespace DIInstallers
{
	public class CreatureInstaller : MonoInstaller<CreatureInstaller>
	{
		[field: SerializeField] private Creature Creature { get; set; }

		public override void InstallBindings ()
		{
			Container.BindInterfacesAndSelfTo<Creature>().FromInstance(Creature).AsSingle().NonLazy();

			BindData();
			BindAndQueueNonMonoBehaviours();
		}

		private void BindData ()
		{
			Container.Bind<FactionData>().FromScriptableObject(Creature.FactionData).AsSingle().NonLazy();
		}

		private void BindAndQueueNonMonoBehaviours ()
		{
			Container.Bind<VisibilityController>().FromInstance(Creature.VisibilityController).AsSingle().NonLazy();
			Container.QueueForInject(Creature.VisibilityController);
		}
	}
}