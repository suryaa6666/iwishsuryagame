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
    private string kode;
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
        var judulBanyak = Random.Range(0, kata.judulBanyak);
        var deskripsiBanyak = Random.Range(0, kata.deskripsiBanyak);
        var x = "CINTARA";
        var generateRandom = x[Random.Range(0, x.Length - 1)];

        perintah1.GetComponent<Text>().text = kata.judul[judulBanyak];
        perintah2.GetComponent<Text>().text = kata.judul[judulBanyak];
        deskripsi1.GetComponent<Text>().text = kata.deskripsi[deskripsiBanyak];
        kodekata1.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyak}{deskripsiBanyak}";
        kodekata2.gameObject.GetComponent<Text>().text = $"Kode wish : {judulBanyak}{deskripsiBanyak}";
        kode = $"{judulBanyak}{deskripsiBanyak}";
        Debug.Log(kode);
        gm = FindObjectOfType<GameManager>();

    }

    public void SaveWish() {
        gm.savedWish.Add(kode);
        PlayerPrefs.SetString("savedWish" + PlayerPrefs.GetInt("savedWishCount").ToString(), kode);
        PlayerPrefs.SetInt("savedWishCount", PlayerPrefs.GetInt("savedWishCount", 0) + 1);
        Debug.Log(PlayerPrefs.GetString("savedWish"));
        Debug.Log(gm.savedWish.Count);
    }

}
