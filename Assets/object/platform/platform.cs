using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class platform : MonoBehaviour
{
    public float recovertime;
    public GameObject Player;

    void Update()
    {  
        if(GetComponent<Animator>().GetBool("broken")==false){
            if (transform.position.y>Player.transform.position.y){
                Debug.Log("ok");
                this.GetComponent<BoxCollider2D>().enabled=false;
            }
            else{
                GetComponent<BoxCollider2D>().enabled =true;
            }
        }
        else{
            GetComponent<BoxCollider2D>().enabled =false;
        }
        Collider2D[] hit=Physics2D.OverlapBoxAll(transform.position,new Vector2(3.5f,1.5f),0);
        if(GetComponent<Animator>().GetBool("broken")==false){
            foreach(Collider2D find in hit){
                if(find.gameObject.CompareTag("dead")){
                    disappear();
                }
            }
        }
    }
    public void appear(){
        GetComponent<Animator>().SetBool("broken",false);
    }
    public void disappear(){
        GetComponent<Animator>().SetBool("broken",true);
        StartCoroutine(waitforappear());
    }
    private IEnumerator waitforappear(){
        yield return new WaitForSeconds(recovertime);
        appear();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(3.5f, 1.5f));
    }
}
