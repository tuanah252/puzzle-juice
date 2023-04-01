using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler4 : MonoBehaviour
{
    // Start is called before the first frame update
    public int target1;
    private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        target1 = WinningHandler.instance.target1;
        
        _textMeshPro.text = target1.ToString();

    }
}
