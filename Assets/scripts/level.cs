using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class level : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    public int diff;
    private GameManager game;
    void Start()
    {
        button=GetComponent<Button>();
        game=GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(Difficultylevel);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Difficultylevel(){
        Debug.Log(button.gameObject.name+" was named");
        game.gamestart(diff);
    }
}
