using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameover;
    public GameObject title;
    private int score;
    public float spawnrate=1.0f;
    public bool isgameactive;
    public Button re;
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawntarget(){
        while(isgameactive){
            yield return new WaitForSeconds(spawnrate);
            int index=Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void updatescore(int sr){
        score+=sr;
        scoretext.text="Score : "+score;
    }
    public void check(){
        isgameactive=false;
        gameover.gameObject.SetActive(true);
        re.gameObject.SetActive(true);
    }
    public void restrat(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gamestart(int level){
        isgameactive=true;
        spawnrate/=level;
        StartCoroutine(spawntarget());
        updatescore(0);
        gameover.gameObject.SetActive(false);
        title.SetActive(false);
    }
}
