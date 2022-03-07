using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeZone : MonoBehaviour
{
    public Image TimeStock;
    public float leak = 0.1f;
    public GameObject arrow;
    public GameObject LevelMenu;
    public GameObject OverMenu;
    public GameObject TutorialMenu;
    static private float stock;
    static private bool timeZone;

    private void Start()
    {
        stock = 1f;
        timeZone = false;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (LevelMenu.activeInHierarchy == false
            && OverMenu.activeInHierarchy == false
            && (!TutorialMenu || (TutorialMenu && TutorialMenu.activeInHierarchy == false))
            && stock > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeZone = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                timeZone = false;
            }
            if (timeZone)
            {
                TimeStock.fillAmount = stock;
                arrow.transform.localRotation = Quaternion.Euler(0, 0, 360 * stock);
                stock -= leak * Time.deltaTime;
            }
        }
        else
        {
            timeZone = false;
        }
    }

    static public float GetAmount()
    {
        return (stock);
    }

    public void SetTimeZone()
    {
        timeZone = !timeZone;
    }

    static public bool GetTimeZone()
    {
        return (timeZone);
    }
}
