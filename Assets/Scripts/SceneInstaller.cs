
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        var gateway = new ExpressionDbGateway();
        var saverUsecase = new SaverUsecase(gateway);
        var counterUsecase = new CounterUsecase(gateway);
        var presenter = new CalculatorPresenter(counterUsecase, saverUsecase);
        

        Container
            .Bind<IExpressionDbGateway>()
            .FromInstance(gateway);

        Container
            .Bind<ICounterUsecase>()
            .FromInstance(counterUsecase);
        
        Container
            .Bind<ISaverUsecase>()
            .FromInstance(saverUsecase);

        Container
            .Bind<ICalculatorPresenter>()
            .FromInstance(presenter);
        

    }
}
