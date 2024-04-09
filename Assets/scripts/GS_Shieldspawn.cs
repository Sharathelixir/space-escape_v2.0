using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_Shieldspawn : MonoBehaviour
{

    [SerializeField]
    private GameObject _shield;
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
            Instantiate(_shield, position, Quaternion.identity);
            yield return new WaitForSeconds(20f);
        }
    }

    public void stopgenerating()
    {
        _stopspawn = true;
    }
}
