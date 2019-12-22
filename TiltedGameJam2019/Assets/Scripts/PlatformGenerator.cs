using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Inspector Header")]
        [SerializeField]
        GameObject platform;

        [SerializeField]
        List<GameObject> blocks = new List<GameObject>();

        [SerializeField]
        int platformLen = 10;

        [SerializeField]
        Camera cam;

        [SerializeField]
        float camX; //hardcoded right now

        [SerializeField]
        GameObject cookie;

        [SerializeField]
        float cookieProb = 0.01f;

    private float xSpawnValue;

    private float prevCamPosition;
    [SerializeField]
    private float maxCamDistance;
    private const float START_OFFSET = 20f;



    private void Awake()
    {
        xSpawnValue = camX;
        prevCamPosition = cam.transform.position.y + 999999;
    }

    private void Update()
    {
        if (CheckCameraSurpassDistance()) 
        {
            prevCamPosition = cam.transform.position.y;
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        float ySpawnValue = cam.transform.position.y - Random.Range(1, 1) - START_OFFSET;
        GameObject motherPlatform = Instantiate(platform, new Vector2(xSpawnValue, ySpawnValue), Quaternion.identity);
        int normalCount = 0;
        List<GameObject> allBlocks = new List<GameObject>();

        int num = 0;
        while (num < platformLen) 
        {
            int blockIndex;
            if (num > 5)
                blockIndex = Random.Range(-3, blocks.Count - (3 * (platformLen - num)));
            else
                blockIndex = Random.Range(-3, blocks.Count);

            int len = (int) Mathf.Ceil((float) (blockIndex+1) / 3);

            if (blockIndex >= 0)
            {
                float xBlock = (xSpawnValue + (blocks[0].GetComponent<SpriteRenderer>().bounds.size.x) * (num)) + blocks[blockIndex].GetComponent<SpriteRenderer>().bounds.size.x / 2;

                GameObject childBlock = Instantiate(blocks[blockIndex], new Vector2(xBlock, ySpawnValue), Quaternion.identity);
                allBlocks.Add(childBlock);

                childBlock.transform.parent = motherPlatform.transform;

                if (!(childBlock.gameObject.name.Contains("p1") || childBlock.gameObject.name.Contains("p2")))
                    normalCount+= len;

                num += len;

                SpawnCookie(childBlock);
            }
            else
            {
                num++;
            }    
        }

        if (normalCount == platformLen)
        {
            Destroy(allBlocks[Random.Range(0, platformLen)]);
        }
    }

    private void SpawnCookie(GameObject block)
    {
        float rand = Random.Range(0f, 1f);
        Debug.Log("probability = " + cookieProb + "; random = " + rand);
        if (rand < cookieProb)
        {
            Vector2 pos = block.transform.position;
            GameObject newcookie = Instantiate(cookie, new Vector2(pos.x, pos.y + 1), Quaternion.identity);
            newcookie.transform.parent = block.transform;
        }
    }

    private bool CheckCameraSurpassDistance()
    {
        return Mathf.Abs(prevCamPosition - cam.transform.position.y) > maxCamDistance;
    }

}
