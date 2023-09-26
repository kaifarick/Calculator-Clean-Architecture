
using TMPro;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{

    [Inject] private ICalculatorPresenter _calculatorPresenter;

    [SerializeField] private CalculatorView _calculatorView;

    void Start()
    {
        _calculatorPresenter.Initialize(_calculatorView);
    }
}
