using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "test", story: "fireball", category: "Action", id: "233d241ef8dc3cc6b006143a2a513425")]
public partial class fireballattack : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<int> Fireballlimit;
    [SerializeReference] public BlackboardVariable<List<float>> Range;
    [SerializeReference] public BlackboardVariable<Vector3> Pos;
    protected override Status OnStart()
    {
        Self.Value.GetComponent<Animator>().SetBool("fire", true);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Self.Value.transform.position=Vector3.Lerp(Self.Value.transform.position,Pos.Value,Time.deltaTime*5);
        if(Mathf.Abs(Self.Value.transform.position.y-Pos.Value.y)<0.1f){
            Pos.Value=new Vector3(Pos.Value.x,UnityEngine.Random.Range(Range.Value[0],Range.Value[1]),Pos.Value.z);
        }
        if(GameObject.FindObjectsByType<fireball>(FindObjectsSortMode.None).Length>=Fireballlimit){
            Self.Value.GetComponent<Animator>().SetBool("fire", false);
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

