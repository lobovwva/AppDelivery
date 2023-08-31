using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float lineDistance;

    [SerializeField] 
    private float speed;    

    private Vector3 dir;
    private CharacterController controller;
    private int lineToMove = 1;

    public int fire;
    public int numOfFire;
    public Image[] fires;
    public Sprite fullFire;
    public Sprite emptyFire;

    public GameObject panelGO;
    public GameObject panelGP;

    private ScoreManager sm;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        sm = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if(lineToMove < 2)
            {
                lineToMove++;
            }
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        dir.z = speed;
        controller.Move(dir * Time.fixedDeltaTime);

        if (fire > numOfFire)
        {
            fire = numOfFire;
        }

        for (int i = 0; i < fires.Length; i++)
        {
            if (i < Mathf.RoundToInt(fire))
            {
                fires[i].sprite = fullFire;
            }
            else
            {
                fires[i].sprite = emptyFire;
            }

            if (i < numOfFire)
            {
                fires[i].enabled = true;
            }
            else
            {
                fires[i].enabled = false;
            }
        }

        if (fire == 5 || fire == 0)
        {
            Time.timeScale = 0; 
            panelGO.SetActive(true);
            panelGP.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TorchDrag")
        {
            fire++;
            sm.PickUp();
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Barrel")
        {
            fire--;
            Destroy(other.gameObject);
        }
    }
}
