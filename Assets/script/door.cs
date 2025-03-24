using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = gravitysetup;
    }

    // Update is called once per frame
    public LayerMask player;
    public Vector2 gravitysetup;
    public bool havekey=false;
    void Update()
    {
        if (havekey==true){

            GetComponent<Animator>().SetBool("open",true);
        }
        else{
            GetComponent<Animator>().SetBool("open",false);
        }
        if(Physics2D.OverlapCircle(transform.position, 0.5f,player)!=null&&havekey==true){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
