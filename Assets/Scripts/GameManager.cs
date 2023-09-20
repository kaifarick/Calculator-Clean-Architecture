using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CalculatorView calculatorView;
    void Start()
    {
        CalculatorModel calculatorModel = new CalculatorModel();
        CalculatorPresenter calculatorPresenter = new CalculatorPresenter(calculatorModel,calculatorView);
    }

    
}
