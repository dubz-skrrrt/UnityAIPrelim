using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    public int Life = 3;
    public Text healhtext;
    void Start()
    {
        
        var lives = GameObject.FindGameObjectWithTag("Lives");
        Debug.Log(Life);
        DontDestroyOnLoad(lives);
    }

    // Update is called once per frame
    void Update()
    {
        healhtext = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        ChangeText();
        
    }

    void ChangeText(){
        healhtext.text = "LIVES: " + GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>().Life;
    }
}
