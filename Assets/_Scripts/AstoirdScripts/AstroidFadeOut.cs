using UnityEngine;
using System.Collections;

public class AstroidFadeOut : MonoBehaviour
{
    void Start(){Destroy(this.gameObject, 8f);}
}