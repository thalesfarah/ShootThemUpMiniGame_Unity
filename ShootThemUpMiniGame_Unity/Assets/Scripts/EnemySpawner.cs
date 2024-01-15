using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNNING, WAITING, COUTING};
    [System.Serializable]
    public class Wave 
    {
        public GameObject inimigo;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    int nextWave = 0;
    public float timeBetweenWaves = 5f, waveCountDown;
    float searchCountDown = 1f;
    SpawnState state = SpawnState.COUTING;
    public Transform enemySpawnPoints;
    public Text contDownText;
    public static bool spawnnig, waiting, couting;
    private void Start()
    {
        waveCountDown = timeBetweenWaves;
        contDownText.gameObject.SetActive(true);

    }
    private void FixedUpdate()
    {
        
        if (state == SpawnState.WAITING) 
        {
            waiting = true;
            if (EnemyIsAlive() == false) 
            {
                WaveCompleted();
                GameController.gameController.level++;
                Debug.Log(GameController.gameController.level);
            }
            else 
            {
                return;
            }
        }
        if (waveCountDown <= 0)
        {
            waiting = false;
            waveCountDown = 0;
            contDownText.gameObject.SetActive(false);
            if (state != SpawnState.SPAWNNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
           
        }
        else
        {
            contDownText.gameObject.SetActive(true);
            waveCountDown -= Time.fixedDeltaTime;
            int intWaveCountDown = (int)waveCountDown;
            contDownText.text = "The next wave starts in " + intWaveCountDown.ToString();
            //baseText.gameObject.SetActive(false);
        }

    }
    IEnumerator SpawnWave(Wave wave_) 
    {
        state = SpawnState.SPAWNNING;
        spawnnig = true;
        for (int i = 0; i < wave_.count; i++) 
        {
            SpawnEnemy(wave_.inimigo);
            yield return new WaitForSeconds(1/wave_.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(GameObject inimigo_) 
    {
        int numeroAleatorio = Random.Range(0, enemySpawnPoints.childCount);
        GameObject enemyInstance = Instantiate(inimigo_, enemySpawnPoints.GetChild(numeroAleatorio).transform.position, Quaternion.identity);
    }
    bool EnemyIsAlive() 
    {
        searchCountDown -= Time.fixedDeltaTime;
        if (searchCountDown <= 0f) 
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Inimigo") == null)
            {
                return false;
            }
        }
        return true;
    }
    void WaveCompleted() 
    {
        state = SpawnState.COUTING;
        couting = true;
        waveCountDown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1) 
        {
            nextWave = 0;
        }
        else 
        {
            
            nextWave++;
        }
    }
    private void OnDrawGizmos()
    {
        foreach (Transform enemySpawnPoint in enemySpawnPoints) 
        {
            Gizmos.DrawSphere(enemySpawnPoint.transform.position, .5f);
        }
    }
}
