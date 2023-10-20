using Zenject;
using TMPro;
using Runner.UI;
using UnityEngine;

public class UIInstaller : MonoInstaller<UIInstaller>
{
    [SerializeField] private GameObject _coinVisualPrefab;
    public override void InstallBindings()
    {
        Container.Bind<TextMeshProUGUI>()
            .FromComponentInChildren()
            .AsTransient();

        Container.Bind<RectTransform>()
            .FromComponentInChildren()
            .AsTransient();

        Container.BindMemoryPool<CoinVisual, CoinVisual.Pool>()
        .WithInitialSize(20)
        .FromComponentInNewPrefab(_coinVisualPrefab)
        .UnderTransformGroup("CoinVisualPrefabPool");
    }
}
