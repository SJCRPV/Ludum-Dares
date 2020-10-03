using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PortalEnterEvent(ABoardPiece boardPiece, int portalIndex);

public class Portal : MonoBehaviour
{
    public event PortalEnterEvent OnPortalEnter;    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPortalEnter?.Invoke(collision.transform.GetComponent<ABoardPiece>(), transform.GetSiblingIndex());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
