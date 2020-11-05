using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Katakata : MonoBehaviour
{
    public List<string> judul;
    public List<string> deskripsi;
    [HideInInspector]
    public int judulBanyak;
    [HideInInspector]
    public int deskripsiBanyak;

    private void Awake()
    {
        judulBanyak = judul.Count;
        deskripsiBanyak = deskripsi.Count;
    }

}

