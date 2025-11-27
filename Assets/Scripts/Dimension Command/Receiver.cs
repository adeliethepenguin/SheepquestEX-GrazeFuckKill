using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{

    private Stack<int> dimensions = new Stack<int>();

    public void NewDim(int newDim)
    {
        dimensions.Push(newDim);
    }

    public void GoBack()
    {
        dimensions.Pop();
    }

    public int DimensionCheck()
    {
        return dimensions.Peek();
    }

    public bool EmptyCheck()
    {
        if (dimensions.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
