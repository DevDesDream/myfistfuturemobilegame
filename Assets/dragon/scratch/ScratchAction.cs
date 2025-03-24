using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "scratch", story: "dragon scratch", category: "Action", id: "826b4fcd82247bb21d57a31f2aa4c418")]
public partial class ScratchAction : Action
{
    [SerializeReference]public BlackboardVariable<GameObject> self;
    [SerializeReference]public BlackboardVariable<Vector3> target;

    protected override Status OnStart()
    {
        self.Value.GetComponent<Animator>().SetBool("scratch",true);
        self.Value.GetComponent<scratchspawn>().spawnscratch();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        self.Value.transform.position=Vector3.Lerp(self.Value.transform.position,target.Value,Time.deltaTime*5);
        if(Math.Abs(self.Value.transform.position.y-target.Value.y)<0.1f){
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        self.Value.GetComponent <Animator>().SetBool("scratch",false);
    }
}

