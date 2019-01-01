//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Camera castCam;
    public int maxClickCount = 2;
    [SerializeField]
    private List<Block> selectedBlockList = new List<Block>();

    private RaycastHit hit;
    private Block hitBlock;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(castCam.ScreenPointToRay(Input.mousePosition), out hit, 1 << LayerMask.NameToLayer("Block")))
            {
                hitBlock = hit.collider.GetComponent<Block>();

                bool exists = selectedBlockList.Contains(hitBlock);
                if (exists)
                {
                    hitBlock.SetCilickAuto();
                    if (!hitBlock.IsSelected)
                    {
                        selectedBlockList.Remove(hitBlock);                      
                    }
                }

                if (selectedBlockList.Count < maxClickCount && !exists)
                {
                    selectedBlockList.Add(hitBlock);

                    if (hitBlock.IsSelected)
                        selectedBlockList.Remove(hitBlock);

                    hitBlock.SetCilickAuto();                   

                    if (selectedBlockList.Count == maxClickCount)
                    {
                        if (IsSatisfyEmssion())
                            Emssion();
                        else
                            foreach (Block b in selectedBlockList)
                                b.SetCilickAuto();
                            
                        selectedBlockList.Clear();
                    }
                }

            }

        }
    }

    private bool IsSatisfyEmssion()
    {
        if (selectedBlockList.Count != maxClickCount)
            return false;

        Color aim = selectedBlockList[0].color;
        for (int i = 1; i < maxClickCount; i++)
        {
            if (selectedBlockList[i].color != aim)
                return false;
        }

        return true;
    }

    private void Emssion()
    {
        foreach (Block b in selectedBlockList)
            Destroy(b.gameObject);
    }
}
