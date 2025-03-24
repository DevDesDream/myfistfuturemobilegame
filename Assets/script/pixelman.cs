
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pixelman : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        self=GetComponent<Animator>();
        selftrans=GetComponent<Transform>();
        selfrigid=GetComponent<Rigidbody2D>();
    }
    private Animator self;
    private Rigidbody2D selfrigid;
    private Transform selftrans;
    public GameObject runsmoke;
    public LayerMask button;
    public bool ontheroad=false;
    public float jump;
    public float speed;
    public GameObject[] gravityeffect;
    void Update()
    {
        ParticleSystem.MainModule main=runsmoke.GetComponent<ParticleSystem>().main;
        float horizonspeed=math.cos(selftrans.localEulerAngles.z/180*math.PI)*speed;
        float verticalspeed=math.cos(selftrans.localEulerAngles.z/180*math.PI-math.PI/2)*speed;
        selftrans.position=new Vector2(selftrans.position.x+Time.deltaTime*Input.GetAxisRaw("Horizontal")*horizonspeed,selftrans.position.y+Time.deltaTime*Input.GetAxisRaw("Horizontal")*verticalspeed);
        if(Input.GetKeyDown(KeyCode.A)){
            selftrans.localScale=new Vector2(-math.abs(selftrans.localScale.x), math.abs(selftrans.localScale.y));
            runsmoke.GetComponent<Transform>().localScale=new Vector3(-0.8f, 0.8f,0.8f);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            selftrans.localScale=new Vector2(math.abs(selftrans.localScale.x), math.abs(selftrans.localScale.y));
            runsmoke.GetComponent<Transform>().localScale=new Vector3(0.8f, 0.8f,0.8f);
        }
        if(ontheroad==true){
            if((Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.D)==false&&Input.GetKey(KeyCode.A)==false)){
                self.SetBool("run",false);
                main.startLifetime=0;
            }
            else{
                self.SetBool("run",true);
                main.startLifetime=0.3f;
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                selfrigid.AddForce(new Vector2(jump*verticalspeed*-1/speed,jump*horizonspeed/speed),ForceMode2D.Impulse);
            }
            self.SetBool("jump",false);
        }
        else{
            self.SetBool("jump",true);
            main.startLifetime=0;
        }
        
    }
    //detect touch the object
    void OnCollisionEnter2D(Collision2D barier){
        //touch trap
        if(barier.gameObject.tag=="dead"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //button
        Collider2D butcolli=Physics2D.OverlapBox(transform.position,new Vector2(2.1f,2.1f),0,button);
        if(butcolli!=null){
            butcolli.gameObject.SetActive(false);
            switch(butcolli.gameObject.name){
                case "up":
                    Instantiate(gravityeffect[0]);
                    Physics2D.gravity= new Vector2(0,11f);
                    selftrans.rotation=Quaternion.Euler(0,0,-180);
                    break;
                case "down":
                    Instantiate(gravityeffect[1]);
                    Physics2D.gravity= new Vector2(0,-11f);
                    selftrans.rotation=Quaternion.Euler(0,0,0);
                    break;
                case "right":
                    Instantiate(gravityeffect[2]);
                    Physics2D.gravity=new Vector2(11f,0);
                    selftrans.rotation=Quaternion.Euler(0,0,90);
                    break;
                case "left":
                    Instantiate(gravityeffect[3]);
                    Physics2D.gravity=new Vector2(-11f,0);
                    selftrans.rotation=Quaternion.Euler(0,0,-90);
                    break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(2.1f, 2.1f));
    }
    void OnCollisionExit2D(Collision2D barier){
    }
}
