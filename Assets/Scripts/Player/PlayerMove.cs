using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float step = 1f;
    public float stepRotate = 45.0f;
    public GameObject LevelMenu;
    public GameObject OverMenu;
    public GameObject TutorialMenu;
    public GameObject FinalMenu;
    public AudioSource AudioSteps;
    public AudioSource AudioPush;

    private int i = 0;
    private bool checkFloor = false;
    private bool checkCollision = false;
    private Quaternion sight;

    void Update()
    {
        if (!TutorialMenu || (TutorialMenu && TutorialMenu.activeInHierarchy == false))
        {
            if (sight.eulerAngles.y != transform.rotation.eulerAngles.y)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, sight.eulerAngles.y, 0), stepRotate * Time.deltaTime);
            }
            else if (LevelMenu.activeInHierarchy == false
                && OverMenu.activeInHierarchy == false
                && (!(SceneManager.GetActiveScene().name == "Level4") || FinalMenu.activeInHierarchy == false))
            {
                if (!checkCollision)
                {
                    if (!checkFloor)
                    {
                        if (Physics.Raycast(transform.position, Vector3.down, 0.2f))
                        {
                            AudioSteps.Play();
                            checkFloor = true;
                        }
                    }
                    else
                    {
                        if (!Physics.Raycast(transform.position, Vector3.down, 0.2f))
                        {
                            checkFloor = false;
                            AudioSteps.Stop();
                            AudioPush.Stop();
                        }
                    }
                }
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[i].transform.position, step * Time.deltaTime);
                if (transform.position == wayPoints[i].transform.position)
                {
                    i++;
                    if (i == wayPoints.Count)
                    {
                        AudioSteps.Stop();
                        if (SceneManager.GetActiveScene().name == "Level4")
                        {
                            FinalMenu.SetActive(true);
                        }
                        else
                        {
                            LevelMenu.SetActive(true);
                        }
                    }
                    else
                    {
                        sight = Quaternion.LookRotation((wayPoints[i].transform.position - transform.position).normalized, Vector3.up);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Abyss")
        {
            AudioSteps.Stop();
            OverMenu.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            checkCollision = true;
            AudioPush.Play();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            checkCollision = false;
            AudioPush.Stop();
        }
    }
}
