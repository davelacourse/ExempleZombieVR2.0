using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;  // ajoute la librairie réseau

public class Spawner : NetworkBehaviour  // change la classe hérité
{
    public static Spawner Instance;

    [SerializeField] private float spawnTime = 1;
    public float SpawnTime => spawnTime;
    
    [SerializeField] private GameObject spawnGameObject;
    [SerializeField] private Transform[] spawnPoints;
    
    private float timer;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(timer > spawnTime)
        {
            // Si je ne suis pas le serveur je resort du update car seulement le serveur
            // instancie les zombies et gère le timer
            if(!IsServer)
            {
                return;
            }
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject spawnedZombie = Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
            
            // Instancie le gameobject sur le réseau
            spawnedZombie.GetComponent<NetworkObject>().Spawn(true);
            
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // Méthode appellé pour réduire le temps de spawn en 4
    public void ReduireSpawnTime()
    {
        spawnTime -= spawnTime / 4;
    }
}


