using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static WinningHandler instance;
    public int money = 0;
    public int target1 = 30;
    public int target2 = 30;
    public int target3 = 30;
    public int target4 = 30;
    public int turn = 25;
    public GameObject winScene;
    public GameObject loseScene;
    public GameObject Circle;
    public GameObject button;
    public Canvas canvas;
    private int limit;
    public bool isCompleted = false;
    public string scene;

    void Start()
    {
        instance = this;


    }

    // Update is called once per frame
    void Update()
    {
        if (money < 0)
        {
            money = 0;
        }
        if (target2 < 0)
        {
            target2 = 0;
        }
        if (target1 < 0)
        {
            target1 = 0;
        }
        if (target3 < 0)
        {
            target3 = 0;
        }
        if (target4 < 0)
        {
            target4 = 0;
        }
        if (turn < 0)
        {
            turn = 0;
        }
        if (SceneManager.GetActiveScene().name == "lv1" || SceneManager.GetActiveScene().name == "lv2")
        {


            if (target1 == 0 && target2 == 0 && target3 == 0 & limit == 0)
            {
                limit = 1;
                win();
            }

            if (turn == 0 && limit == 0)
            {
                limit = 1;
                lose();
            }

        }
        else if (SceneManager.GetActiveScene().name == "lv3")
        {


            if (target1 == 0 && target2 == 0 && target3 == 0 && target4 == 0 && limit == 0)
            {
                limit = 1;
                win();
            }

            if (turn == 0 && limit == 0)
            {
                limit = 1;
                lose();
            }

        }


    }

    void win()
    {
        Destroy(Circle);
        Destroy(button);
        GameObject newObject = Instantiate(winScene);
        newObject.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        isCompleted = true;
    }

    void lose()
    {

        Destroy(Circle);
        Destroy(button);
        GameObject newObject = Instantiate(loseScene);
        newObject.transform.SetParent(canvas.transform, false);
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        isCompleted = true;
    }
}




