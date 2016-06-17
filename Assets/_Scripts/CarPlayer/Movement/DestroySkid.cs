using UnityEngine;
using System.Collections;

public class DestroySkid : MonoBehaviour 
{
    public void Start()
    {
        Destroy(gameObject,10f);
    }
}
