using System.Collections;
using System.Collections.Generic;
using Logic;
using Unity.VisualScripting;
using UnityEngine;

public class ActorSpawner : MonoBehaviour
{
    public List<GameObject> npcPrefabs; // List of NPC prefabs to spawn
    public int numberOfNPCs = 100; // Number of NPCs to spawn (total)
    public float spawnRadius = 20f; // Radius within which NPCs will be spawned

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
{
    // Calculate the side length of the square grid
    int sideLength = Mathf.CeilToInt(Mathf.Sqrt(numberOfNPCs));

    // Calculate the distance between each NPC on the grid
    float distanceBetweenEach = spawnRadius / sideLength;

    // Initialize the starting position
    Vector3 startPosition = transform.position - new Vector3(spawnRadius / 2, 0, spawnRadius / 2);

    int npcIndex = 0;
    for (int i = 0; i < sideLength; i++)
    {
        for (int j = 0; j < sideLength; j++)
        {
            if (npcIndex >= numberOfNPCs)
            {
                return;
            }

            // Select the prefab for this NPC
            GameObject prefab = npcPrefabs[npcIndex % npcPrefabs.Count];

            // Calculate the position for this NPC
            Vector3 npcPosition = startPosition + new Vector3(i * distanceBetweenEach, 10f, j * distanceBetweenEach);

            // Raycast downwards to find the ground level
            RaycastHit hit;
            if (Physics.Raycast(npcPosition, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                // Adjust the y-coordinate to be exactly at the ground level
                npcPosition.y = hit.point.y;

                // Add an offset to the y-coordinate to prevent the NPC from spawning halfway through the floor
                float offset = prefab.GetComponent<Collider>().bounds.extents.y;
                npcPosition.y += offset;
            }
            else
            {
                // If raycast fails, use default y-coordinate
                npcPosition.y = 1f;
            }

            // Spawn the NPC at the adjusted position
            GameObject npc = Instantiate(prefab, npcPosition, Quaternion.identity);

            npcIndex++;
        }
    }
}
}
