using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody DiceRig;


    public float[] DiceSizes;

    Vector3[] sides =
    { Vector3.up,       // 1(+) or 6(-)
     Vector3.right,    // 2(+) or 5(-)
     Vector3.forward }; // 3(+) or 4(-)
 
    int WhichIsUp()
    {
        var maxY = float.NegativeInfinity;
        var result = -1;

        for (var i = 0; i < 3; i++)
        {
            // Transform the vector to world-space:
            var worldSpace = transform.TransformDirection(sides[i]);
            if (worldSpace.y > maxY)
            {
                result = i + 1; // index 0 is 1
                maxY = worldSpace.y;
            }
            if (-worldSpace.y > maxY)
            { // also check opposite side
                result = 6 - i; // sum of opposite sides = 7
                maxY = -worldSpace.y;
            }
        }
        return result;
    }
    
    void ChangeSize()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DiceRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public float massmultiplier = 1f;
    public int currentdicesize;
    void Update()
    {
        if (DiceRig.velocity.magnitude < 0.001f)
        {
            float DiceSizeUp = DiceSizes[WhichIsUp()-1];
            //float DiceSizeDirect = (float)WhichIsUp();

            if (transform.localScale.x != DiceSizeUp)
            {
                currentdicesize = WhichIsUp();
                transform.localScale = Vector3.one * DiceSizeUp;
                DiceRig.mass = DiceSizeUp * massmultiplier;
            }
        }
        

    }
}
