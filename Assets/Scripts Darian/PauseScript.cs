using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    Transform target; 
    private int leaveMenu = 0;
    Vector3 originalPos;
    [SerializeField]
    string Pause;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(Pause).transform; // letar efter ett objekt med taggen "pause". - Darian
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && leaveMenu == 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Pause");
            leaveMenu = 1;
            originalPos = transform.position;
            transform.position = target.position; //om man trycker p� esc n�r v�rdet �r 0, s� blir man teleporterad till det objekt/st�lle man lagt in som target position - Darian
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && leaveMenu == 1)
        {
            Time.timeScale = 1f;
            Debug.Log("Unpause");
            leaveMenu = 0;
            transform.position = originalPos; //om man trycker p� esc n�r v�rdet �r 1, s� blir man teleporterad tillbaka till originalpositionen - Darian
        }
        
    }
}
