using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler5 : MonoBehaviour
{
    // Start is called before the first frame update
    public int target;
    private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        target = WinningHandler.instance.target4;

        _textMeshPro.text = target.ToString();

    }
}
