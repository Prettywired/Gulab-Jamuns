/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
   private int stars=3;

   public void DecreaseStars(){
    stars--;
   }
   public int GetStars(){
    return stars;
   }
}*/
using UnityEngine;

public class Stars : MonoBehaviour
{
    public static int mistakes = 0;

    public static void IncrementMistakes()
    {
        mistakes++;
    }

    public static int GetStars()
    {
        if (mistakes == 0)
        {
            return 3;
        }
        else if (mistakes == 1)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public static void ResetMistakes()
    {
        mistakes = 0;
    }
}
