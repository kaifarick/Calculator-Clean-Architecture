using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorView : MonoBehaviour, ICalculatorView
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField] private TMP_InputField _inputField;
    
    [SerializeField] private ResultElement _resultElement;
    [SerializeField] private Transform _elementBox;
    
    [SerializeField] private Button _button;

    private List<ResultElement> _resultElements = new();
    
    private const int MAX_ELEMENT_COUNT = 6;
    
    
    public event Action<string> OnExpressionChanged;
    public event Action OnCalculatePressed;
    
    
    private void Awake()
    {
        _inputField.onValueChanged.AddListener(ExpressionChanged);
        _button.onClick.AddListener(CalculatePressed);
    }

    private void CalculatePressed()
    {
        OnCalculatePressed?.Invoke();
    }

    private void ExpressionChanged(string value)
    {
        OnExpressionChanged?.Invoke(value);
    }
    

    public void SetValueInField(string result)
    {
        _inputField.text = result;
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
       
       SetValueInField("");
    }

    private void OnDestroy()
    {
        _inputField.onValueChanged.RemoveListener(ExpressionChanged);
        _button.onClick.RemoveListener(CalculatePressed);
    }
}
