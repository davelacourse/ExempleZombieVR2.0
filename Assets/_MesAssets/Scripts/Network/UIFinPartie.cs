using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIFinPartie : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtZombies = default;

    private void Start()
    {
        _txtTemps.text = "Temps : " + TimeSpan.FromSeconds(GameManagerZombie.Instance.Timer).ToString("mm\\:ss\\.ff");
        _txtZombies.text = "Zombies : " + GameManagerZombie.Instance.ZombieTues.ToString();
    }
}
