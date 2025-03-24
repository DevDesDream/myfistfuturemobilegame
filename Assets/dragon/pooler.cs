using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class pooler : MonoBehaviour
{
    public GameObject fireballpre;
    private ObjectPool<GameObject> fireballpool;
    public GameObject scratchpre;
    private ObjectPool<GameObject> scratchpool;

    // Update is called once per frame
    void Awake(){
        fireballpool= new ObjectPool<GameObject>(
            createFunc: ()=>Instantiate(fireballpre),
            actionOnGet: fireball => fireball.SetActive(true),
            actionOnRelease: fireball => fireball.SetActive(false),
            collectionCheck: false,
            defaultCapacity: 5,
            maxSize: 10
        );
        scratchpool= new ObjectPool<GameObject>(
            createFunc: ()=>Instantiate(scratchpre),
            actionOnGet: scratch =>{
                scratch.SetActive(true);
                scratch.transform.position=GameObject.Find("scratchspawner").transform.position;
            },
            actionOnRelease: scratch=>scratch.SetActive(false),
            collectionCheck: false,
            defaultCapacity:2,
            maxSize: 3
        );
    }
    public void ScratchActive(){
        scratchpool.Get();
    }
    public void ScratchDisable(GameObject scratch){
        scratchpool.Release(scratch);
    }
    public void Getfireball()
    {
        fireballpool.Get();
    }
    public void Releasefireball(GameObject fireball){
        fireballpool.Release(fireball);
    }
}
