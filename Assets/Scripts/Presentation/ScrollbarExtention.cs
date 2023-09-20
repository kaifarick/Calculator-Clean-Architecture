using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScrollbarExtention : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollBar;

    private float _startSize;

    private void Start()
    {
        _startSize = _scrollBar.size;
        
        FixScrollbarValue();
    }

    private void FixScrollbarValue()
    {
        _scrollBar.onValueChanged.AddListener(arg0 => _scrollBar.value = _startSize);
    }

    
    private void Update()
    {
#if UNITY_EDITOR
        _scrollBar.size = _startSize;
#endif
    }
}
