using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneWin1;
    public string SceneLose1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneWin()
    {
        SceneManager.LoadScene(SceneWin1);
    }
    public void SceneLose()
    {
        SceneManager.LoadScene(SceneLose1);
    }
}
