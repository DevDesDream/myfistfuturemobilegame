using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegravityobject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity=new Vector2(0,-9.8f);
    }
    public LayerMask playermask;
    public GameObject[] gravityeffect;
    public GameObject player;
    bool inrange=false;
    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapBox(transform.position, new Vector2(0.5f,0.5f),0,playermask)!=null){
            if(inrange==false){
                inrange=true;
                Destroy(GameObject.FindGameObjectWithTag("gravityeffect"));
                switch(gameObject.name){
                    case "up":
                        Instantiate(gravityeffect[0]);
                        Physics2D.gravity= new Vector2(0,9.8f);
                        player.transform.rotation=Quaternion.Euler(0,0,-180);
                        break;
                    case "down":
                        Instantiate(gravityeffect[1]);
                        Physics2D.gravity= new Vector2(0,-9.8f);
                        player.transform.rotation=Quaternion.Euler(0,0,0);
                        break;
                    case "right":
                        Instantiate(gravityeffect[2]);
                        Physics2D.gravity=new Vector2(9.8f,0);
                        player.transform.rotation=Quaternion.Euler(0,0,90);
                        break;
                    case "left":
                        Instantiate(gravityeffect[3]);
                        Physics2D.gravity=new Vector2(-9.8f,0);
                        player.transform.rotation=Quaternion.Euler(0,0,-90);
                        break;
                }
            }
        }
        else{
            inrange=false;
        }
    }
}
