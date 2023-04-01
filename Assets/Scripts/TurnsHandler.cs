using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI turnText;

    void Start()
    {
        turnText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        turnText.text = WinningHandler.instance.turn.ToString();
    }
}
