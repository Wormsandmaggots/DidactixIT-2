using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool canInteract;
    public bool CanInteract => canInteract;
    public virtual void CollisionWithPlayerAction()
    {
        
    }
}
