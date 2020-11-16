using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public GameObject[] Line1spawners;
    public GameObject[] Line2spawners;
    public GameObject[] Trianglespawners;
    public GameObject[] Hexagonspawners;
    public GameObject[] Crossspawners;
    public GameObject line1, line2, triangleLine;
    public List<GameObject> waveEnnemies = new List<GameObject>();
    public List<GameObject> waveIn = new List<GameObject>();
    public Transform bossSpawnPos;
    public GameObject boss;
    int waveNumber;

    public GameObject startVisual1, startVisual2,BossVisual1,BossVisual2;

    private void Awake()
    {
        game = this;
    }

    private void Start()
    {
        waveNumber = 0;
        StartCoroutine(DisplayObjective());
    }

    IEnumerator DisplayObjective()
    {
        yield return new WaitForSeconds(2f);
        startVisual1.SetActive(true);
        yield return new WaitForSeconds(1f);
        startVisual2.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartBattle();
        yield return new WaitForSeconds(3f);
        startVisual1.SetActive(false);
        startVisual2.SetActive(false);
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
        if (waveNumber <= 3)
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
        if (waveNumber > 3 && waveNumber <= 7)
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
        if (waveNumber > 7 && waveNumber <= 12)
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

        if(waveNumber == 13)
        {
            StartCoroutine(SpawnBoss());
        }
        StartCoroutine( StartSpawn(Random.Range(0,5)));
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

            if (spawnPattern == 3)
            {
                GameObject ennemi = Instantiate(waveEnnemies[i], Hexagonspawners[i].transform.position, Quaternion.identity);
                waveIn.Add(ennemi);
            }
            if (spawnPattern == 4)
            {
                GameObject ennemi = Instantiate(waveEnnemies[i], Crossspawners[i].transform.position, Quaternion.identity);
                waveIn.Add(ennemi);
            }
        }
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(2f);
        BossVisual1.SetActive(true);
        yield return new WaitForSeconds(1f);
        BossVisual2.SetActive(true);
        yield return new WaitForSeconds(3f);
        BossVisual1.SetActive(false);
        BossVisual2.SetActive(false);
        yield return new WaitForSeconds(1f);
        Instantiate(boss, bossSpawnPos.position, Quaternion.identity);
        yield return null;
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
