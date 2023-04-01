using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler3 : MonoBehaviour
{
    // Start is called before the first frame update
    public int target3;
    private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        target3 = WinningHandler.instance.target3;
        
        _textMeshPro.text = target3.ToString();
    }
}
