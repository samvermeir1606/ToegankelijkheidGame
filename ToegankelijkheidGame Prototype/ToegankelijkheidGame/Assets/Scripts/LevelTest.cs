using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class TestingRow
{
    public List<bool> each=new List<bool>();
}

public class LevelTest : MonoBehaviour
{
    //[TableList()]
    //public List<TestingRow> Rows = new List<TestingRow>();

    [ShowInInspector]
    [TableMatrix(HorizontalTitle = "Read Only Matrix", IsReadOnly = true)]
    public int[,] ReadOnlyMatrix = new int[5, 5];

    [ShowInInspector]
    //[TableMatrix(HorizontalTitle = "X axis", VerticalTitle = "Y axis",SquareCells =true,)]
    //public bool[,] LabledMatrix = new bool[6, 6];



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
