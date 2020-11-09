using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IWish : MonoBehaviour
{
    private GameObject perintah1;
    private GameObject perintah2;
    private GameObject deskripsi1;
    Katakata kata;
    private GameObject kodekata1;
    private GameObject kodekata2;
    public string kode;
    GameManager gm;
    public Button saveButton;


    private void Awake()
    {
        kata = FindObjectOfType<Katakata>();

        perintah1 = GameObject.Find("perintah1");
        perintah2 = GameObject.Find("perintah2");
        deskripsi1 = GameObject.Find("deskripsi1");
        kodekata1 = GameObject.Find("kodekata1");
        kodekata2 = GameObject.Find("kodekata2");

    }

    private void OnEnable()
    {
        var judulBanyak = Random.Range(0, kata.judulBanyak);
        var deskripsiBanyak = Random.Range(0, kata.deskripsiBanyak);
        var judulBanyakString = judulBanyak.ToString("D2");
        var deskripsiBanyakString = deskripsiBanyak.ToString("D2");

        // var x = "CINTARA";
        // var generateRandom = x[Random.Range(0, x.Length - 1)];

        perintah1.GetComponent<Text>().text = kata.judul[judulBanyak];
        perintah2.GetComponent<Text>().text = kata.judul[judulBanyak];
        deskripsi1.GetComponent<Text>().text = kata.deskripsi[deskripsiBanyak];
        kodekata1.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyakString}{deskripsiBanyakString}";
        kodekata2.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyakString}{deskripsiBanyakString}";
        kode = $"{judulBanyakString}{deskripsiBanyakString}";
        Debug.Log(kode);
        gm = FindObjectOfType<GameManager>();

    }

    private void Update() {
        for(int i = 0 ; i < gm.savedWish.Count; i++) {
            if(kode == gm.savedWish[i]) {
                saveButton.interactable = false;
            } else {
                saveButton.interactable = true;
            }
        }
    }

    public void SaveWish() {
        gm.savedWish.Add(kode);
        PlayerPrefs.SetString("savedWish" + PlayerPrefs.GetInt("savedWishCount").ToString(), kode);
        PlayerPrefs.SetInt("savedWishCount", PlayerPrefs.GetInt("savedWishCount", 0) + 1);
        Debug.Log(PlayerPrefs.GetString("savedWish"));
        Debug.Log(gm.savedWish.Count);
        gm.notifications.SetActive(true);
        gm.notifications.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wish Saved!";
        gm.notifications.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Wish Saved!";
        StartCoroutine(gm.CloseNotif());
    }

}
