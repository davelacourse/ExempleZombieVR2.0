using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerZombie : MonoBehaviour
{
    public static GameManagerZombie Instance;
    
    private float _timer = 0f;
    public float Timer => _timer;
    
    private int _zombieTues = 0;
    public int ZombieTues => _zombieTues;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerPrefs.SetInt("PartieEnCours", 1);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void AugmenterZombies()
    {
        _zombieTues++;
    }
}
