
using System.Security;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class movementplatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        selftrans=GetComponent<Transform>();
    }

    // Update is called once per frame
    private Transform selftrans;
    public float speed;
    public Vector3 begin;
    public Vector3 end;
    private float v;
    public GameObject player;
    private float originalsize;
    void Update()
    {
        v+=speed*Time.deltaTime;
        selftrans.position=Vector3.Lerp(begin,end,v);
        if(v>1){
            speed=-math.abs(speed);
        }
        if(v<0){
            speed=math.abs(speed);
        }
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag=="Player"){
            player.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collider){
        if(collider.gameObject.tag=="Player"){
            player.transform.SetParent(null);
        }
    }
}
