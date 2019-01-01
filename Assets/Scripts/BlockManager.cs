//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLightGame;

public class BlockManager : MonoBehaviour
{
    [Range(2, 10)]
    public int level = 3;
    public string colorsName = "Default";
    public Transform blockRoot;

    private static BlockManager instance;
    public static BlockManager Instance
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    [HideInInspector]
    public bool needFixed = false;
    [HideInInspector]
    public List<Block> blocks;
    //[HideInInspector]
    //public bool alreadySelected = false;
    [HideInInspector]
    public Block currentSelected = null;
    //[HideInInspector]
    //public Block prevSelected = null;
    [HideInInspector]
    public Color currentColor;
    private ColorStruct currentColors;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
        {
            MLLogger.Log("ERROR", "blockmanager already exist." + instance.gameObject.name + "will be destory.");
            Destroy(instance.gameObject);
        }
    }

    private void Start()
    {
        if (GameManager.Instance.data.FindColorByName(colorsName).HasValue)
            currentColors = GameManager.Instance.data.FindColorByName(colorsName).Value;

        CreateCube(level, GameManager.Instance.data.FindBlockByName("Normal").GetValueOrDefault());
        needFixed = level > 3 && level % 2 == 0;
    }

    public void CreateCube(int lv, BlockStruct setting)
    {
        int sum = lv * lv * lv;
        bool isOdd = sum % 2 != 0;

        int evenSum = isOdd ? sum - 1 : sum;

        setting.Init();
        List<Color> c = new List<Color>();
        for (int i = 0; i < evenSum / 2; i++)
        {
            int index = Random.Range(0, currentColors.colors.Length);
            c.Add(currentColors.colors[index]);
        }

        if (!blockRoot)
        {
            MLLogger.Log("error", "no blockRoot, blocks will not be created.");
            return;
        }

        int count = 0;
        Vector3 pos = Vector3.zero;

        int rl = lv;
        if (lv % 2 == 0)
            rl = lv - 1;

        for (int x = -lv / 2; x <= rl * 2; x++)
        {
            for (int y = lv / 2; y >= -rl / 2; y--)
            {
                for (int z = lv / 2; z >= -rl / 2; z--)
                {
                    if (isOdd && x == 0 && y == 0 && z == 0)
                        continue;

                    if (count >= evenSum)
                        break;

                    pos = new Vector3(x, y, z);
                    GameObject block = Instantiate(setting.model, pos, Quaternion.identity, blockRoot);
                    Material ma = block.GetComponent<Renderer>().material;
                    blocks.Add(block.GetComponent<Block>());

                    if (count < evenSum / 2)
                        ma.color = c[count++];
                    else if (count >= evenSum / 2 && count < evenSum)
                    {
                        int index = Random.Range(0, c.Count);
                        ma.color = c[index];
                        c.RemoveAt(index);
                        count++;
                    }
                    block.GetComponent<Block>().color = block.GetComponent<Renderer>().material.color;
                }
            }
        }

    }

    public IEnumerator CreateCubeWithAnima(int lv, BlockStruct setting)
    {
        throw new System.NotImplementedException();
        //yield return null;
    }
}
