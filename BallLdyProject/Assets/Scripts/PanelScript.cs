using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {
    //Material m_Material;
    [SerializeField] private CanvasGroup a;
    float clearLevel = 1.0f;
    // [visibled / none]
    string displayStates;
    bool fadeOutSwitch = false;

    // Use this for initialization
    void Start () {
        //m_Material = GetComponent<Renderer>().material;
        //m_Material.color = Color.red;
        //m_Material.color = new Color(0, 0, 0, 1.0f);

        //Debug.Log("動く？");
        displayStates = "visibled";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.M))
        {
            fadeOutSwitch = true;
        }

        if (displayStates.Equals("visibled") && fadeOutSwitch && 0f <= clearLevel)
        {
            //StartCoroutine("Corou3");
            Debug.Log("clearLevel_bef：[" + clearLevel + "]");
            clearLevel -= 0.1f;
            a.alpha = clearLevel;
            Debug.Log("clearLevel_aft：[" + clearLevel + "]");
        }
        else if (fadeOutSwitch)
        {
            fadeOutSwitch = false;
            clearLevel = 0f;
            displayStates = "none";
            Debug.Log("clearLevel：[" + clearLevel + "]");
            //Debug.Log("clearLevel：[" + clearLevel + "]");
            //Debug.Log("0になった");
        }
        else
        {
            Debug.Log("それ以外");
            Debug.Log("clearLevel：[" + clearLevel + "]");
        }
    }
    //コルーチン関数を定義
    private IEnumerator Corou3() //コルーチン関数の名前
    {
        yield return new WaitForSeconds(1.0f);
        clearLevel -= 0.1f;
        a.alpha = clearLevel;
        Debug.Log("clearLevel：[" + clearLevel + "]");

        //コルーチンの内容
        //Debug.Log("a");
        //yield return null;
        //Debug.Log("b");
    }
}
