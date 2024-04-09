using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;
    private bool _stopspawnenemy = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startspawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startspawning()
    {
        while (_stopspawnenemy == false)
        {
            Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), transform.position.y);
            Instantiate(enemy, position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    public void stopspawningenemy()
    {
        _stopspawnenemy = true;
    }
}
