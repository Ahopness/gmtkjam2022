using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushIt : MonoBehaviour
{
    public int DiceValueNeeded;
    List<Dice> Dices = new List<Dice>();
    TMPro.TextMeshPro DiceValueCounter;
    // Start is called before the first frame update
    void Start()
    {
        Dice[] WorldDices = Object.FindObjectsOfType<Dice>();



        DiceValueCounter = GetComponentInChildren<TMPro.TextMeshPro>();
        DiceValueCounter.text = DiceValueNeeded.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Dice DiceEntered))
            Dices.Add(DiceEntered);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Dice DiceExited))
            Dices.Remove(DiceExited);
    }

    private void Update()
    {
        int totalweight = 0;
        foreach (Dice ThisDice in Dices)
            totalweight += ThisDice.currentdicesize;

        DiceValueCounter.text = (DiceValueNeeded - totalweight).ToString();

        if (totalweight >= DiceValueNeeded)
            Destroy(gameObject);
        //GlobalSystem.Spawndice()
    }
}
