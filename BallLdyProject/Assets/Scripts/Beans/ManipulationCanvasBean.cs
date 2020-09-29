using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/// <summary>
/// 操作マニュアルデータ格納Bean
/// </summary>
public class ManipulationCanvasBean
{
    /// <summary>
    /// 透明度[0f~1.0f]
    /// 数字が小さい程、透明になる。
    /// </summary>
    private float clearLevel;
    /// <summary>
    /// キー押下判定フラグ
    /// </summary>
    private bool inputKeyDowned;

    public void setClearLevel(float clearLevel)
    {
        this.clearLevel = clearLevel;
    }

    public float getClearLevel()
    {
        return this.clearLevel;
    }

    public void setInputKeyDowned(bool inputKeyDowned)
    {
        this.inputKeyDowned = inputKeyDowned;
    }

    public bool isInputKeyDowned()
    {
        return this.inputKeyDowned;
    }
}
