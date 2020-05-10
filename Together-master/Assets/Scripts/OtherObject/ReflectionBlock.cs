using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ReflectionBlock : MonoBehaviour
{
    bool isIn;
    public Transform block;

    public Camera camera;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (++GameFacade.Instance.tempname > 0)
        {
            camera.GetComponent<CinemachineBrain>().enabled = false;
            camera.transform.position = new Vector3(6.5f, -3.3f, -10f);
            camera.orthographicSize = 10f;
        }

    }
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            block.transform.Rotate(0, 0, 2f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            block.transform.Rotate(0, 0, -2f * Time.deltaTime);
        }

        camera.GetComponent<CinemachineBrain>().enabled = false;
        camera.transform.position = new Vector3(6.5f, -3.3f, -10f);
        camera.orthographicSize = 10f;
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (--GameFacade.Instance.tempname == 0)
        {
            camera.GetComponent<CinemachineBrain>().enabled = true;
        }
    }




}
