using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gravityeffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        selfrigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public float speed;
    private Rigidbody2D selfrigid;
    void Update()
    {
        selfrigid.linearVelocity=new Vector2(math.sin(transform.eulerAngles.z/180*math.PI)*speed*-1,math.cos(transform.eulerAngles.z/180*math.PI)*speed);
    }
}
