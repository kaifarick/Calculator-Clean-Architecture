using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CalculatorView : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField] private TMP_InputField _inputField;
    
    [SerializeField] private ResultElement _resultElement;
    [SerializeField] private Transform _elementBox;
    
    [SerializeField] private Button _button;

    private List<ResultElement> _resultElements = new List<ResultElement>();
    
    private const int MAX_ELEMENT_COUNT = 6;
    
    
    [Inject] private ICalculatorPresenter _calculatorPresenter;
    
    private void Awake()
    {
        _button.onClick.AddListener(_calculatorPresenter.SetResult);
        _inputField.onValueChanged.AddListener(_calculatorPresenter.UpdateExpression);
        
    }

    private void Start()
    {
        _inputField.text = _calculatorPresenter.GetInitialExpression();
        _calculatorPresenter.OnOperationCompleteAction += OnOperationComplete;
    }

    public void OnOperationComplete(string result)
    {
       var element = Instantiate(_resultElement, _elementBox);
       element.Initialize(result);
       element.transform.SetAsFirstSibling();
       _resultElements.Add(element);

       if (_resultElements.Count == MAX_ELEMENT_COUNT)
       {
           _scrollRect.vertical = true;
           _verticalLayoutGroup.childControlHeight = false;
       }
       
       _inputField.text = "";
    }
    
    private void OnDestroy()
    {
        _calculatorPresenter.OnOperationCompleteAction -= OnOperationComplete;
        
        _button.onClick.RemoveListener(_calculatorPresenter.SetResult);
        _inputField.onValueChanged.RemoveListener(_calculatorPresenter.UpdateExpression);
    }
}
