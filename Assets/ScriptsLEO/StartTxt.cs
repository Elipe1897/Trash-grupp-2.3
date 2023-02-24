using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTxt : MonoBehaviour
{

    public GameObject StartText;
    public GameObject ObjectiveText;
    public bool GameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        GameStarted = false;
        Time.timeScale = 0;
        ObjectiveText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        print("hej");
        if(Input.GetKeyDown(KeyCode.Space) && GameStarted == false)
        {
            print("hej igen");
            GameStarted = true;
            StartText.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine(Objective());
        }
    }

    public IEnumerator Objective()
    {
        ObjectiveText.SetActive(true);
        yield return new WaitForSeconds(5);
        ObjectiveText.SetActive(false);
    }

}
