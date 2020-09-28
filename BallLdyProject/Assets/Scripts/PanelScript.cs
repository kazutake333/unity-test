using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {
    //Material m_Material;
    [SerializeField] private CanvasGroup a;
    float clearLevel = 1.0f;
    bool fadeOutSwitch = false;

    // Use this for initialization
    void Start () {
        //m_Material = GetComponent<Renderer>().material;
        //m_Material.color = Color.red;
        //m_Material.color = new Color(0, 0, 0, 1.0f);
        
        //Debug.Log("動く？");
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

        if (fadeOutSwitch && 0f <= clearLevel)
        {
            clearLevel = clearLevel - 0.1f;
            a.alpha = clearLevel;
            Debug.Log("clearLevel：[" + clearLevel + "]");
        }
        else
        {
            fadeOutSwitch = false;
            Debug.Log("clearLevel：[" + clearLevel + "]");
            Debug.Log("0になった");
        }
    }
}
