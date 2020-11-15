using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public GameObject[] Line1spawners;
    public GameObject[] Line2spawners;
    public GameObject[] Trianglespawners;
    public GameObject line1, line2, triangleLine;
    public List<GameObject> waveEnnemies = new List<GameObject>();
    public List<GameObject> waveIn = new List<GameObject>();

    int waveNumber;

    private void Awake()
    {
        game = this;
    }

    private void Start()
    {
        waveNumber = 0;
        StartBattle();
    }

    private void Update()
    {
        
    }

    private void StartBattle()
    {
        waveNumber++;
        Debug.Log("Wave Number" + waveNumber);
        
        if(waveEnnemies.Count > 0)
        {
            int trueCount = waveEnnemies.Count;
            for (int i = 0; i < trueCount; i++)
            {
                waveEnnemies.Remove(waveEnnemies[0]);
                Debug.Log(waveEnnemies.Count);
            }
        }
        int random = Random.Range(0, 3);
        #region FirstPhase
        if (waveNumber <= 5)
        {

            if (random == 0)
            {
                for (int i = 0; i < WaveHolder.wave.rectangleWave1.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.rectangleWave1[i]);
                }
            }
            else if (random == 1)
            {
                for (int i = 0; i < WaveHolder.wave.triangleWave1.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.triangleWave1[i]);
                }
            }
            else if (random == 2)
            {
                for (int i = 0; i < WaveHolder.wave.circleWave1.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.circleWave1[i]);
                }
            }
        }
        #endregion
        #region SecondPhase
        if (waveNumber > 5 && waveNumber <= 10)
        {
            if (random == 0)
            {
                for (int i = 0; i < WaveHolder.wave.rectangleWave2.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.rectangleWave2[i]);
                }
            }
            else if (random == 1)
            {
                for (int i = 0; i < WaveHolder.wave.triangleWave2.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.triangleWave2[i]);
                }
            }
            else if (random == 2)
            {
                for (int i = 0; i < WaveHolder.wave.circleWave2.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.circleWave2[i]);
                }
            }
        }
        #endregion
        #region ThirdPhase
        if (waveNumber > 10 && waveNumber <= 15)
        {
            if (random == 0)
            {
                for (int i = 0; i < WaveHolder.wave.rectangleWave3.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.rectangleWave3[i]);
                }
            }
            else if (random == 1)
            {
                for (int i = 0; i < WaveHolder.wave.triangleWave3.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.triangleWave3[i]);
                }
            }
            else if (random == 2)
            {
                for (int i = 0; i < WaveHolder.wave.circleWave3.Count; i++)
                {
                    waveEnnemies.Add(WaveHolder.wave.circleWave3[i]);
                }
            }
        }
        #endregion
        StartCoroutine( StartSpawn(Random.Range(0,3)));
    }

    IEnumerator StartSpawn(int spawnPattern)
    {
        for(int i = 0; i < waveEnnemies.Count; i++)
        {
            yield return new WaitForSeconds(1f);
            //Line1 spawn pattern
            if(spawnPattern == 0)
            {
                GameObject ennemi = Instantiate(waveEnnemies[i], Line1spawners[i].transform.position, Quaternion.identity);
                waveIn.Add(ennemi);
            }

            if (spawnPattern == 1)
            {
                GameObject ennemi = Instantiate(waveEnnemies[i], Line2spawners[i].transform.position, Quaternion.identity);
                waveIn.Add(ennemi);
            }

            if (spawnPattern == 2)
            {
                GameObject ennemi = Instantiate(waveEnnemies[i], Trianglespawners[i].transform.position, Quaternion.identity);
                waveIn.Add(ennemi);
            }
        }
    }

    public void RemoveFromList(GameObject ennemi)
    {
        waveIn.Remove(ennemi);
        if(waveIn.Count == 0)
        {
            StartBattle();
        }
    }
}
