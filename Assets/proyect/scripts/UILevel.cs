using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    public Level level;
    public Text levelIDText;
    private Transform startParent;
    public GameObject lockImage;
    private Image[] stars;
    void Awake()
    {
        startParent = transform.Find("stars").transform; //aunque find busca en todo el codigo el primero que va a encontrar es el más cercano a donde este el script
        stars = startParent.GetComponentsInChildren<Image>();
    }

    public void SetStars(int stars)
    {
        for (int i = 0;i < stars; i++)
        {
            this.stars[i].color =Color.white;
            Debug.Log(i);
        }
    }
}
