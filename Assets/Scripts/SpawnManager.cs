using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _numberJelly;
    [SerializeField]
    private GameObject[] _colorFish;

    private GameObject _jellyParent;
    private GameObject _colorFishParent;

    private int _jellyCount;

    bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnJellyRoutine());
        _jellyParent = GameObject.Find("JellyParent");
        _colorFishParent = GameObject.Find("ColorFishParent");
        _jellyCount = 0;

        //StartCoroutine(SpawnColorFishRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        if (_jellyParent.transform.childCount <= 0)
            StartCoroutine(SpawnJellyRoutine());
      


    }
    private void FixedUpdate()
    {
        if (_colorFishParent.transform.childCount <= 2)
        {
            Vector3 fishSpawnPos = new Vector3(Random.Range(-11, 11), Random.Range(-7, 7), 0);
            int randomfish = Random.Range(0, 4);


            Instantiate(_colorFish[randomfish], fishSpawnPos, Quaternion.identity);
        }
    }

    IEnumerator SpawnJellyRoutine()
    {
      
        Vector3 jellySpawnPos = new Vector3(Random.Range(-11, 11), Random.Range(-7, 7), 0);
        int randomJellyNum = Random.Range(1, 9);
        for(int i = 0; i < randomJellyNum ; i++)
        {
            int col = i/ 3;
            int row = i % 3;

            Vector3 Pos = new Vector3(jellySpawnPos.x - row, jellySpawnPos.y - col, 0);
            Instantiate(_numberJelly, Pos, Quaternion.identity);
        }
            
        yield return new WaitForSeconds(5f);

    }
    //IEnumerator SpawnColorFishRoutine()
    //{
    //    while(_colorFishParent.transform.childCount <= 4)
    //    {
    //        Vector3 fishSpawnPos = new Vector3(Random.Range(-11, 11), Random.Range(-7, 7), 0);
    //        int randomfish = Random.Range(0, 2);


    //        Instantiate(_colorFish[randomfish], fishSpawnPos, Quaternion.identity);


    //        yield return new WaitForSeconds(15f);
    //    }

      

    //}

}
