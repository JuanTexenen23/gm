using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    private int countPickUps;
    private int countKey;
    public GameObject wallLvl;
    public GameObject rampWall;
    public GameObject ramp;

    public GameObject msg1;


    void Start()
    {
        //InitialPositionCam();
        rb = GetComponent<Rigidbody>();
        countPickUps = 0;
        countKey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveH, 0, MoveV);
        rb.AddForce(movement * speed);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FalseWall"))
        {
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("PickUps"))
            {
            other.gameObject.SetActive(false);
            countPickUps++;
            if (countPickUps == 3)
            {
                NextLvl();
            }else if (countPickUps != 3)
            {
                msg1.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            countKey++;
            KeyTaken();
            
        }
        else
        {
            resetScene();
        }
    }
   
    private void NextLvl()
    {
        wallLvl.SetActive(false);
        msg1.SetActive(true);
    }
    private void KeyTaken()
    {
        ramp.SetActive(true);
        rampWall.SetActive(false);
        if (countKey == 2)
        {

        }
    }
    private void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("First Map").buildIndex);
    }
}