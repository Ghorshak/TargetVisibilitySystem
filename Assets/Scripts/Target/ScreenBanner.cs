using Faction;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Target
{
	public class ScreenBanner : MonoBehaviour
	{
		[field: SerializeField] public Image BannerImage { get; set; }
		[field: SerializeField] public CanvasGroup BannerCanvasGroup { get; set; }

		private FactionData FactionData { get; set; }
		private ITargetable Target { get; set; }

		[Inject]
		public void Construct (FactionData factionData, ITargetable target)
		{
			FactionData = factionData;
			Target = target;
		}

		private void Awake ()
		{
			SetUpScreenBanner();
		}

		private void SetUpScreenBanner ()
		{
			BannerImage.sprite = FactionData.FactionImages.BannerImage;
			BannerImage.color = Target.AttitudeColor;
		}
	}
}