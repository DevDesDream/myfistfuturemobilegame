using UnityEngine;

public class fireball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject spawnfireball;
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity=new Vector2(-9,0);
    }
    void OnCollisionEnter2D(Collision2D barier){
        if(barier.gameObject.name !="platform"){
            gameObject.SetActive(false);
            FindFirstObjectByType<pooler>().Releasefireball(gameObject);
        }
    }
    void OnEnable(){
        spawnfireball=GameObject.Find("fireballspawn");
        transform.position=spawnfireball.transform.position;
    }

}
