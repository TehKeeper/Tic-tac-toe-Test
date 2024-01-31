using general;
using general.save;
using general.win.condition;
using general.win.message;
using ui.button;
using Zenject;

namespace injections
{
    public class DependencyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
            Container.Bind<BtnViewer>().AsTransient();
            Container.Bind<WinCheckBase>().To<WinCheckOne>().AsTransient();
            Container.Bind<IEndMsgProcessor>().To<EndGameMessage>().AsTransient();
            Container.Bind<ISaveSys>().To<SaveSys>().AsSingle().NonLazy();
        }
    }
}