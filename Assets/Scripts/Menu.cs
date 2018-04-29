using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static bool level1Completed = false;
    public static bool level2Completed = false;

    public GameObject background;

    public Button buttonLevel1;
    public Button buttonLevel2;
    public Button buttonLevel3;

    Button btn1;
    Button btn2;
    Button btn3;

    // Use this for initialization
    void Start()
    {
        btn1 = buttonLevel1.GetComponent<Button>();
        btn1.onClick.AddListener(startLevel1);

        btn2 = buttonLevel2.GetComponent<Button>();
        btn2.onClick.AddListener(startLevel2);

        btn3 = buttonLevel3.GetComponent<Button>();
        btn3.onClick.AddListener(startLevel3);

    }

    // Update is called once per frame
    void Update()
    {
     

    }

    public void startLevel1()
    {
        print("button 1 click");
        SceneManager.LoadScene("Level1");
    }

    public void startLevel2()
    {
        print("button 2 click");
        SceneManager.LoadScene("Level2");
    }

    public void startLevel3()
    {
        print("button 3 click");
        SceneManager.LoadScene("Level3");
    }

}

