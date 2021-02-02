﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionNode : Node
{
    private AIBlackboard _AI = null;

    public RepositionNode(AIBlackboard AI)
    {
        _AI = AI;
    }

    public override State EvaluateState()
    {
        Vector3 aiToHideableObject = Vector3.Normalize(_AI.transform.position - _AI.CurrentCoverObject.transform.position);
        Vector3 playerToHideableObject = Vector3.Normalize(_AI.Player.transform.position - _AI.CurrentCoverObject.transform.position);
        Vector3 resultingCrossVec = Vector3.Cross(aiToHideableObject, playerToHideableObject);
        
        _AI.angleToHideableObject += resultingCrossVec.y <= 0 ? -0.2f : 0.2f;
        
        _AI.NavAgent.destination = _AI.CurrentCoverObject.transform.position +
                                   new Vector3(Mathf.Cos(_AI.angleToHideableObject), 0,
                                       Mathf.Sin(_AI.angleToHideableObject)) * 4;// * (radius + Random.Range(0.0f,0.75f));
        return State.Running;
    }
}