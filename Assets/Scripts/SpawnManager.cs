using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _numberJelly;

    bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnJellyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnJellyRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 jellySpawnPos = new Vector3(Random.Range(-11, 11), Random.Range(-7, 7), 0);
            int randomJellyNum = Random.Range(1, 9);
            for(int i = 0; i < randomJellyNum ; i++)
            {
                int col = i/ 3;
                i = i % 3;

                jellySpawnPos = new Vector3(jellySpawnPos.x - i, jellySpawnPos.y - col, 0);
                Instantiate(_numberJelly, jellySpawnPos, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(3f);
        }
    }
 
}
