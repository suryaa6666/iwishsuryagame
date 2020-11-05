using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedWish : MonoBehaviour
{
    public GameObject content;
    public GameObject noSavedCode;



    // Update is called once per frame
    private void Update()
    {
        if(content.transform.childCount != 0) {
            noSavedCode.SetActive(false);
        } else {
            noSavedCode.SetActive(true);
        }
    }
}
