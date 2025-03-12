using TMPro;
using UnityEngine;

public class ResultElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;

    public void Initialize(string result)
    {
        gameObject.SetActive(true);
        
        _resultText.text = result;
    }
}
