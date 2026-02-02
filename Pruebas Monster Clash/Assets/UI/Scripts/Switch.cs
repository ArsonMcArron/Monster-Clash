using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] background;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 8)
            index = 8;

        if (index < 0)
            index = 0;

        if(index == 0)
        {
            background[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;
        for(int i=0; i < background.Length; i++) 
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        Debug.Log(index);
    }

    public void Previous() 
    {
        index -= 1;

        for(int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        Debug.Log(index);
    }
}
