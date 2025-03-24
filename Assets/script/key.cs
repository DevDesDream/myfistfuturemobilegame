using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public LayerMask player;
    public door door;
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f,player)){
            door.havekey=true;
            Destroy(gameObject);
        }
    }
}
