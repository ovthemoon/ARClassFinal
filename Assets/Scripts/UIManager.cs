using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text exp;
    public GameObject clearUI;
    public TMP_Text clearText;
    public GameObject attackButtons;
    public GameObject confirmPlaneButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: "+GameManager.Instance.level.ToString();
        exp.text = "Exp: "+GameManager.Instance.playerExp.ToString();
        if (GameManager.Instance.isCleared)
        {
            clearUI.SetActive(true);
            clearText.text = "Clear!";
        }
        attackButtons.SetActive(!ScanManager.Instance.isTracking);
        confirmPlaneButton.SetActive(ScanManager.Instance.isTracking);
        
    }
}
