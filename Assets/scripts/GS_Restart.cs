using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GS_Restart : MonoBehaviour
{
    [SerializeField]
    private Button restart;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnButtonClick()
    {
        SceneManager.LoadScene("GS_MENU");
    }
}
