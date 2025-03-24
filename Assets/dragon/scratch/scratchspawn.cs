using UnityEngine;

public class scratchspawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject scratchpooler;
    public GameObject scratchspawner;
    public float[] range;
    public void spawnscratch(){
        scratchspawner.transform.position = new Vector3(Random.Range(range[0],range[1]),scratchspawner.transform.position.y,scratchspawner.transform.position.z);
        scratchpooler.GetComponent<pooler>().ScratchActive();
    }
}
