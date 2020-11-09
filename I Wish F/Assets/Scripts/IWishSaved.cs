using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IWishSaved : MonoBehaviour
{
    private GameObject perintah1;
    private GameObject perintah2;
    private GameObject deskripsi1;
    Katakata kata;
    private GameObject kodekata1;
    private GameObject kodekata2;
    // private string kode;
    GameManager gm;


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
        gm = FindObjectOfType<GameManager>();

    }

    private void Update() {
        // kode = $"{judulBanyakString}{deskripsiBanyakString}";
        // Debug.Log(kode);
        var x = gm.kodeTerbukaSavedWish;
        var judulBanyakString = x.Substring(0,2);
        var deskripsiBanyakString = x.Substring(2,2);
        var judulBanyak = Convert.ToInt32(x.Substring(0, 2));
        var deskripsiBanyak = Convert.ToInt32(x.Substring(2, 2));

        Debug.Log($"judulBanyak : {judulBanyak}");
        Debug.Log($"deskripsiBanyak : {deskripsiBanyak}");


        perintah1.GetComponent<Text>().text = kata.judul[judulBanyak];
        perintah2.GetComponent<Text>().text = kata.judul[judulBanyak];
        deskripsi1.GetComponent<Text>().text = kata.deskripsi[deskripsiBanyak];
        kodekata1.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyakString}{deskripsiBanyakString}";
        kodekata2.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyakString}{deskripsiBanyakString}";
        
    }

    // public void SaveWish() {
    //     gm.savedWish.Add(kode);
    //     PlayerPrefs.SetString("savedWish" + PlayerPrefs.GetInt("savedWishCount").ToString(), kode);
    //     PlayerPrefs.SetInt("savedWishCount", PlayerPrefs.GetInt("savedWishCount", 0) + 1);
    //     Debug.Log(PlayerPrefs.GetString("savedWish"));
    //     Debug.Log(gm.savedWish.Count);
    // }
}
