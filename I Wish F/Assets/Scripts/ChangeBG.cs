using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBG : MonoBehaviour
{

    public List<GameObject> BGList;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        BGList = new List<GameObject>(new GameObject[gameManager.BGList.Count]);
        for (int i = 0; i < gameManager.BGList.Count; i++)
        {
            BGList[i] = gameManager.BGList[i];
        }
    }

    private void OnEnable()
    {
        var pp = PlayerPrefs.GetInt("BGChange", 0);
        BGList[pp].GetComponent<Button>().interactable = false;
        var a = BGList[pp].transform.GetChild(0);
        a.gameObject.SetActive(true);
        // Tambahin backsound BARU.

    }

}
