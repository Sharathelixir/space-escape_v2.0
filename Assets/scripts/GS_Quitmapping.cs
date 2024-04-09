using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GS_Quitmapping : MonoBehaviour
{
    [SerializeField]
    private Button exit;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(OnButtonClick);          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonClick()
    {
        Application.Quit();
    }
}
