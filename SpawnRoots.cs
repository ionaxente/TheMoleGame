using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rootsList1;
    [SerializeField]
    private GameObject[] rootsList2;
    [SerializeField]
    private GameObject[] rootsList3;
    [SerializeField]
    private GameObject[] rootsList4;
    [SerializeField]
    private GameObject[] rootsList5;
    [SerializeField]
    private GameObject[] rootsList6;

    private uint _NR_OF_LISTS = 6;

    private GameObject[][] rootsLists;
    private uint[] rootsShowedForEachList;


    // Start is called before the first frame update
    void Start()
    {
        rootsLists = new GameObject[_NR_OF_LISTS][];
        rootsShowedForEachList = new uint[_NR_OF_LISTS];
        rootsLists[0] = rootsList1;
        rootsLists[1] = rootsList2;
        rootsLists[2] = rootsList3;
        rootsLists[3] = rootsList4;
        rootsLists[4] = rootsList5;
        rootsLists[5] = rootsList6;
        for (int i = 0; i < _NR_OF_LISTS; i++)
        {
            rootsShowedForEachList[i] = 0;
            for(int j = 0; j < rootsLists[i].Length; j++)
            {
                rootsLists[i][j].gameObject.SetActive(false);
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showOneRoot()
    {
        uint rdmNumber = (uint)Random.Range(0.0f, _NR_OF_LISTS);
        if(rootsShowedForEachList[rdmNumber] < rootsLists[rdmNumber].Length)
        {
            rootsLists[rdmNumber][rootsShowedForEachList[rdmNumber]++].gameObject.SetActive(true);
        }
    }
}
