using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableBlock : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent(out IInteractable obj))
        {
            //obj.do
        }
    }

    public virtual void OnCollide()
    {

    }

}
