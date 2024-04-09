using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Fuelspawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _fuel;
    private bool _stopspawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startgenerating());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator startgenerating()
    {
        while (_stopspawn == false)
        {
            Vector2 position = new Vector2(Random.Range(-8.0f, 8.0f), transform.position.y);
            Instantiate(_fuel, position, Quaternion.identity);
            yield return new WaitForSeconds(15f);
        }
    }

    public void stopgenerating()
    {
        _stopspawn = true;
    }
}
