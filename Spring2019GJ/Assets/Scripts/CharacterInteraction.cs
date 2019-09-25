using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInteraction : MonoBehaviour
{
    private int characterMask;
    private int interactMask;
    private float rayLength = 50f;
    // Use this for initialization
    void Start()
    {
        characterMask = LayerMask.GetMask("Character");
        interactMask = characterMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Interactions();
    }
    void Interactions()
    {
        RaycastHit rc;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out rc, rayLength, interactMask))
        {
            if(rc.transform.gameObject.layer == LayerMask.NameToLayer("Character"))
            {
                if(rc.transform.name == "KnightOfThePie")
                {
                    if (GetComponentInParent<PlayerQuestLog>().checkQuestActive(2))
                        GetComponentInParent<PlayerQuestLog>().setHelloToKnight();
                }
            }
        }
    }
}
