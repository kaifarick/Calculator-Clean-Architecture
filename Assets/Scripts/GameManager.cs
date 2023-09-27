using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{

    [Inject] private ICounterUsecase _counterUsecase;

    [SerializeField] private CalculatorView _calculatorView;

    void Start()
    {
        _calculatorView.Initialize(_counterUsecase.GetExpression());
    }
}
