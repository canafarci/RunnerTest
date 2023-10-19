using Zenject;
using Runner.Painting;
using UnityEngine;

namespace Runner.Installers
{
    public class PaintingInstaller : MonoInstaller<PaintingInstaller>
    {
        [SerializeField] private Material _paintMaterial;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private ComputeShader _paintShader;
        [SerializeField] private ComputeShader _checkPixelShader;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Painter>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Paintable>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PixelChecker>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PaintingModel>()
                .AsSingle();

            BindVariables();
        }

        private void BindVariables()
        {
            Container.Bind<Material>()
                .FromInstance(_paintMaterial)
                .AsSingle();

            Container.Bind<LayerMask>()
                .FromInstance(_layerMask)
                .AsSingle();

            Container.Bind<ComputeShader>()
                .WithId(ComputeShaders.PaintShader)
                .FromInstance(_paintShader);

            Container.Bind<ComputeShader>()
                .WithId(ComputeShaders.CheckPixelsShader)
                .FromInstance(_checkPixelShader);

        }
    }
}
