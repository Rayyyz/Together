using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class InsectHome : MonoBehaviour
{
    public GameObject Insect;
    public Transform insectPos;

    [HideInInspector]
    public Vector3 applePos;
    public Transform apple;
    public bool hasApple;

    public List<Transform> points = new List<Transform>();
    public List<Light2D> light2Ds = new List<Light2D>();

    int nums;
    float deltaTime = 4f;

    bool isStart;


    // Start is called before the first frame update
    void Start()
    {
        applePos = apple.position;
        // StartCoroutine(Generate());
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            hasApple = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            hasApple = false;
        }
        if (collision.CompareTag("Player"))
        {
            if (isStart == false)
            {
                StartCoroutine(Generate());
                isStart = true;
            }
        }
    }

    IEnumerator Generate()
    {
        if (points.Count == 0)
        {
            Insect ins = Instantiate(Insect).GetComponent<Insect>();
            ins.transform.SetParent(this.transform);
            ins.transform.localPosition = Vector3.zero;
            ins.insectHome = this;
            ins.GetComponent<BoxCollider2D>().isTrigger = true;
            ins.index = -1;
        }
        if (points.Count != 0)
        {
            while (nums < points.Count)
            {
                Insect ins = Instantiate(Insect).GetComponent<Insect>();
                ins.transform.SetParent(this.transform);
                ins.transform.localPosition = insectPos.localPosition;
                ins.insectHome = this;
                ins.index = nums;
                nums++;

                yield return new WaitForSeconds(deltaTime);
            }

        }
    }

    public void ResetApple()
    {
        apple.gameObject.SetActive(false);
        apple.transform.position = applePos;
        apple.gameObject.SetActive(true);
    }


}
