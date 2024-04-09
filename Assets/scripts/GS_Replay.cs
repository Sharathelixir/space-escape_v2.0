using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GS_Replay : MonoBehaviour
{
    [SerializeField]
    private Button replay;

    // Start is called before the first frame update
    void Start()
    {
        replay.onClick.AddListener(OnButtonClick);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonClick()
    {
        SceneManager.LoadScene("SampleScene");

        
    }
}
