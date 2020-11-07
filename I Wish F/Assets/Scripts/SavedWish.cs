using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedWish : MonoBehaviour
{
    public GameObject content;
    public GameObject noSavedCode;
    GameManager gameManager;
    public GameObject savedWishesPrefabs;


    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(content.transform.childCount != 0) {
            noSavedCode.SetActive(false);
        } else {
            noSavedCode.SetActive(true);
        }
    }

    private void OnEnable() {
        for(int i = 0; i < gameManager.savedWish.Count; i++) {
            var x = Instantiate(savedWishesPrefabs, transform.position, Quaternion.identity) as GameObject;
            x.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"{(i + 1).ToString()}. {gameManager.savedWish[i]}";
            x.transform.GetChild(1).gameObject.GetComponent<Text>().text = $"{(i + 1).ToString()}. {gameManager.savedWish[i]}";
            x.transform.SetParent(content.GetComponent<Transform>());
        }
    }

}
