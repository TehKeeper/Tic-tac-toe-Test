using general.win;
using ui.button;
using Zenject;

namespace general
{
    public class DependencyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
            Container.Bind<BtnViewer>().AsTransient();
            Container.Bind<WinCheckBase>().To<WinCheckOne>().AsTransient();
        }
    }
}