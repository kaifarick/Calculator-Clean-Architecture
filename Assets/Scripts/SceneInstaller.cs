
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var gateway = new ExpressionRepository();
        var storage = new PlayerPrefsDataStorage();
        var saverUsecase = new ExpressionStorageUseCase(gateway, storage);
        var counterUsecase = new CounterUsecase(gateway);
        
        Container.Bind<IExpressionRepository>().FromInstance(gateway);
        Container.Bind<IDataStorage>().FromInstance(storage);
        Container.Bind<ISaverUsecase>().FromInstance(saverUsecase);
        Container.Bind<ICounterUsecase>().FromInstance(counterUsecase);
        Container.Bind<ICalculatorView>().FromComponentInHierarchy().AsSingle();;
        Container.Bind<ICalculatorPresenter>().To<CalculatorPresenter>().AsSingle().NonLazy();
    }
}
