using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonopenthedoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public door door;

    // Update is called once per frame
    void Update()
    {
        Collider2D detect=Physics2D.OverlapBox(transform.position,new Vector2(0.2f,0.2f),0);
        if(detect!=null){
            if(detect.gameObject.CompareTag("Player")||detect.gameObject.CompareTag("object")){
                door.havekey=true;
                GetComponent<Animator>().SetBool("on",true);
            }
        }
        else{
            door.havekey=false;
            GetComponent<Animator>().SetBool("on",false);
        }
    }
}
