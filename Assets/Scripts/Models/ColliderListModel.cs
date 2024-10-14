using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColliderListModel
{
    public List<ColliderListItem> CollidersList;

    public ColliderListItem GetColliderByBodyPart(AttackBodyPart bodyPart)
    {
        foreach (ColliderListItem item in CollidersList)
        {
            if (item.BodyPart == bodyPart) return item;
        }
        return null;
    }
}

[Serializable]
public class ColliderListItem 
{ 
    public AttackBodyPart BodyPart;
    public Collider Collider;
}
