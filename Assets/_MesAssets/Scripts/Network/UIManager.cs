using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtZombies = default;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateTextZombie();
    }

    private void LateUpdate()
    {
        _txtTemps.text = "Temps : " + TimeSpan.FromSeconds(GameManagerZombie.Instance.Timer).ToString("mm\\:ss\\.ff");
    }

    public void UpdateTextZombie()
    {
        _txtZombies.text = "Zombies : " + GameManagerZombie.Instance.ZombieTues.ToString();
    }
}
