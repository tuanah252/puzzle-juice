using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> fruits = new List<GameObject>();
    private int randomFruit;
    public int fruitNumber;
    private int totalFruit;
    private int prefabCount = 0;
    public int money;
    void Awake()
    {

    }
    void Start()
    {
        for (int i = 0; i < fruitNumber; i++)
        {
            randomFruit = Random.Range(0, fruits.Count);
            Instantiate(fruits[randomFruit], new Vector3(0, 1, 0), Quaternion.identity);
        }
        prefabCount = GameObject.FindGameObjectsWithTag("MatchingObject").Length;
        Debug.Log("Total prefabs: " + prefabCount);
    }


    // Update is called once per frame
    bool isFull = false;
    void Update()
    {
        money = WinningHandler.instance.money;
        int currentPrefabCount = GameObject.FindGameObjectsWithTag("MatchingObject").Length;
        if (currentPrefabCount != prefabCount)
        {
            prefabCount = currentPrefabCount;
            if (prefabCount >= 100)
            {
                isFull = true;
            }
            else if (prefabCount <= 50)
            {
                isFull = false;
            }

        }
    }
    public void SpawnFruit()
    {
        if (!isFull && money >= 30)
        {
            for (int i = 0; i < fruitNumber / 2; i++)
            {
                randomFruit = Random.Range(0, fruits.Count);
                Instantiate(fruits[randomFruit], new Vector3(0, 1, 0), Quaternion.identity);
            }
            WinningHandler.instance.money -= 300;
        }


    }
}
