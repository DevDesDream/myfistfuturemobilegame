using UnityEngine;

public class fireballspawn : MonoBehaviour
{
    public GameObject fireballpooler;
    public void spawnfireball(){
        fireballpooler.GetComponent<pooler>().Getfireball();
    } 

}
