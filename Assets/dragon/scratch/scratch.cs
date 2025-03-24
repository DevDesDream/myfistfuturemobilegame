using UnityEngine;

public class scratch : MonoBehaviour
{
    public void scratchdisable(){
        FindFirstObjectByType<pooler>().GetComponent<pooler>().ScratchDisable(gameObject);
    }
}
