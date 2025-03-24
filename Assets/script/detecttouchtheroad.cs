using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecttouchtheroad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public LayerMask ground;
    public pixelman man;
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f,ground)!=null){
            man.ontheroad=true;
        }
        else{
            man.ontheroad=false;
        }
        
    }
}
