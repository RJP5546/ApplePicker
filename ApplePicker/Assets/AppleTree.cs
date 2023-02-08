using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public float edgeDistance = 10f;

    public float percentChangeDirection = 0.1f;

    public float appleDropTime = 1f;

    public float speed = 1.0f; //f stands for float

    public GameObject appleFab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(appleFab);
        apple.transform.position = transform.position;
        Invoke("DropApple", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -edgeDistance && speed < 0 || pos.x > edgeDistance && speed > 0) // or is annotared as ||
        {
            speed *= -1f;
        }


    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.x < -edgeDistance && pos.x > edgeDistance && UnityEngine.Random.value < percentChangeDirection)
        {
            speed *= -1f;
        }
    }
}
