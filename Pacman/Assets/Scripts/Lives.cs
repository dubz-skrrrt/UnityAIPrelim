using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    public int Life = 3;
    public Text healthtext;
    void Start()
    {
        
        var lives = GameObject.FindGameObjectWithTag("Lives");

        DontDestroyOnLoad(lives);
    }

    // Update is called once per frame
    void Update()
    {
        
        ChangeText();
        
    }

    void ChangeText(){
        healthtext = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        healthtext.text = "LIVES: " + GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>().Life;
    }
}
