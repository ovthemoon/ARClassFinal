using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: "+DataManager.Instance.PlayerLevel.ToString();
        exp.text = "Exp: "+ DataManager.Instance.PlayerExp.ToString();
        
        
    }
}
