using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorPresenter
{
    private CalculatorModel _calculatorModel;
    private CalculatorView _calculatorView;

    public CalculatorPresenter(CalculatorModel calculatorModel, CalculatorView calculatorView)
    {
        _calculatorModel = calculatorModel;
        _calculatorView = calculatorView;
    }

}
