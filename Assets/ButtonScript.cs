using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    RectTransform thisrect;
    // Start is called before the first frame update
    private float sneedX, sneedY;
    void Start()
    {
        thisrect = GetComponent<RectTransform>();
        sneedX = Random.value;//.Range(0f, 0.005f);
        sneedY = Random.value;//.Range(0f, 0.005f);
    }

    // Update is called once per frame
    public float rotationextention;

    void CheckPerlinWall()
    {
        if (PerlinPos.y > PerlinSize)
            PerlinPos = Vector2.zero;
        else
        {
            if (PerlinPos.x > PerlinSize)
                PerlinPos = new Vector2(0f, PerlinPos.y + Time.deltaTime);
            else
                PerlinPos += Vector2.right * Time.deltaTime;
        }
    }

    float PerlinWithSeed(float seed)
    {
        return Mathf.PerlinNoise(PerlinPos.x + seed, PerlinPos.y + seed);
    }

    Vector2 PerlinPos;
    public float PerlinSize;
    void Update()
    {
        thisrect.localRotation = Quaternion.Lerp(thisrect.localRotation, Quaternion.Euler(Mathf.Lerp(-rotationextention, rotationextention, PerlinWithSeed(sneedX)), Mathf.Lerp(-rotationextention, rotationextention, PerlinWithSeed(sneedY)), 0f), Time.deltaTime);
        CheckPerlinWall();
        print(PerlinPos);
    }
}
