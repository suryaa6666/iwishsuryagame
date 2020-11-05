using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private GameObject panel;
    public GameObject notifications;
    private GameObject background;
    public List<GameObject> BGList;
    private int currentBGIndex;
    SfxManager sfx;
    public int chance;
    public int banyakChanceSehari;
    private GameObject canOpen;
    public List<string> savedWish = new List<string>();



    private void Awake()
    {
        canOpen = GameObject.Find("CanOpen");
        // kata = new string[2, 2];
        sfx = FindObjectOfType<SfxManager>();
        // Disini buat playerprefs untuk mendeteksi background yang sudah dipilih.
        int pp = PlayerPrefs.GetInt("BGChange", 0);
        background = GameObject.Find("Background");
        background.GetComponent<Image>().sprite = BGList[pp].GetComponent<Image>().sprite;
        // Buat kondisionalnya biar bisa refill.
        // Debug.Log(dt.ToString("HHmm"));
        PlayerPrefs.SetInt("a", 1);

        var permission = PlayerPrefs.GetInt("a");
        var permission1 = PlayerPrefs.GetInt("b", 0);

        if (permission == 1 && permission1 == 0)
        {
            DateTime dt = DateTime.Now;
            var now = dt.ToString("yyyyMMddHHmm");
            PlayerPrefs.SetString("date", now);
            Debug.Log(PlayerPrefs.GetString("date"));
            PlayerPrefs.SetInt("a", 0);
            PlayerPrefs.SetInt("b", 1);
        }
        else
        {
            Debug.Log("Maaf sekali saja");
        }

        if (Convert.ToInt64(PlayerPrefs.GetString("date").Substring(0, 8)) < Convert.ToInt64(DateTime.Now.ToString("yyyyMMdd")))
        {
            // Buat menjadikan 0 lagi.
            PlayerPrefs.SetInt("b", 0);
            PlayerPrefs.SetInt("wish", banyakChanceSehari);
            Debug.Log("Refill");
        }
        // PlayerPrefs.SetInt("canGet", 1);
        // if (now == Convert.ToInt32("0001"))
        //     PlayerPrefs.SetInt("wish", 1);
        // PlayerPrefs.SetInt("date", DateTime)
        chance = PlayerPrefs.GetInt("wish", banyakChanceSehari);
    }

    public void Panel(GameObject panel)
    {
        if (panel.gameObject.name != "IWISH")
        {
            panel.SetActive(true);
            var anim = panel.GetComponent<Animator>();
            anim.Play("Panel");
            SfxManager.source.clip = sfx.sfxList[0];
            SfxManager.source.Play();
        }
        else
        {
            if (chance > 0)
            {
                chance--;
                PlayerPrefs.SetInt("wish", chance);
                panel.SetActive(true);
                var anim = panel.GetComponent<Animator>();
                anim.Play("Panel");
                SfxManager.source.clip = sfx.sfxList[0];
                SfxManager.source.Play();
                Debug.Log(chance.ToString());
                SfxManager.source.clip = sfx.sfxList[1];
                SfxManager.source.Play();
            }
            else if (chance <= 0)
            {
                notifications.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Usage limit has been reached, see you tomorrow ^_^";
                notifications.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Usage limit has been reached, see you tomorrow ^_^";
                notifications.SetActive(true);
                StartCoroutine(CloseNotif());
            }
        }
    }

    public void PanelBalik(GameObject newPanel)
    {
        panel = newPanel;
        var anim = panel.GetComponent<Animator>();
        anim.Play("PanelBalik");
        SfxManager.source.clip = sfx.sfxList[0];
        SfxManager.source.Play();
        StartCoroutine(ClosePanel());
    }

    public void ChangeBGButton(int indexBG)
    {
        // kondisi default dulu.
        for (int i = 0; i < BGList.Count; i++)
        {
            BGList[i].GetComponent<Button>().interactable = true;
            var b = BGList[i].gameObject.transform.GetChild(0);
            b.gameObject.SetActive(false);
        }
        GameObject buttonImage = BGList[indexBG];
        background.GetComponent<Image>().sprite = buttonImage.GetComponent<Image>().sprite;
        notifications.SetActive(true);
        var a = buttonImage.transform.GetChild(0);
        a.gameObject.SetActive(true);
        buttonImage.GetComponent<Button>().interactable = false;
        PlayerPrefs.SetInt("BGChange", indexBG);
        SfxManager.source.clip = sfx.sfxList[0];
        SfxManager.source.Play();
        StartCoroutine(CloseNotif());
    }

    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(0.50f);
        panel.SetActive(false);
    }

    IEnumerator CloseNotif()
    {
        yield return new WaitForSeconds(0.50f);
        notifications.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Saved!";
        notifications.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Saved!";
        notifications.SetActive(false);
    }

    // Menghilangkan semua playerprefs 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("BGChange");
            Debug.Log("PlayerPrefs Deleted!");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(DateTime.Now.ToString());
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            var x = Convert.ToInt64(PlayerPrefs.GetString("date").Substring(0, 8)) - 1;
            PlayerPrefs.SetString("date", x.ToString());
            Debug.Log(PlayerPrefs.GetString("date"));
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Deleted All Key!");
        }
        canOpen.transform.GetChild(0).GetComponent<Text>().text = "You can open " + chance.ToString() + "x this day!";
        canOpen.transform.GetChild(1).GetComponent<Text>().text = "You can open " + chance.ToString() + "x this day!";

    }



}
