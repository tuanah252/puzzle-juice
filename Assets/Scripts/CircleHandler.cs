using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static CircleHandler instance;
    public Transform circleCenter;  // Tham chiếu đến Transform của vòng tròn
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
