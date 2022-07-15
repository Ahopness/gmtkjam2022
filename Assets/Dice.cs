using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody DiceRig;
    int DiceSizes;


    Vector3[] sides =
    { Vector3.up,       // 1(+) or 6(-)
     Vector3.right,    // 2(+) or 5(-)
     Vector3.forward }; // 3(+) or 4(-)
 
    float WhichIsUp()
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(WhichIsUp());
    }
}
