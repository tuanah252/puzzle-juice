using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int target2;
    private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        target2 = WinningHandler.instance.target2;
        
        _textMeshPro.text = target2.ToString();
    }
}
