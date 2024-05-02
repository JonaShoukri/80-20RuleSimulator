using System.Collections;
using System.Collections.Generic;
using Logic;
using Unity.VisualScripting;
using UnityEngine;

public class ActorSpawner : MonoBehaviour
{
    public List<GameObject> npcPrefabs; // List of NPC prefabs to spawn
    public int numberOfNPCs = 100; // Number of NPCs to spawn (total)
    public float spawnRadius = 5f; // Radius within which NPCs will be spawned

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
    {
        // Calculate the number of each type of NPC to spawn
        int numberOfEachType = numberOfNPCs / npcPrefabs.Count;

        foreach (GameObject prefab in npcPrefabs)
        {
            for (int i = 0; i < numberOfEachType; i++)
            {
                // Generate a random position within the spawn radius
                Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius),
                                                                          10f, // Start raycast from a higher position to avoid hitting the NPC itself
                                                                          Random.Range(-spawnRadius, spawnRadius));

                // Raycast downwards to find the ground level
                RaycastHit hit;
                if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                {
                    // Adjust the y-coordinate to be exactly at the ground level
                    randomPosition.y = hit.point.y;
                }
                else
                {
                    // If raycast fails, use default y-coordinate
                    randomPosition.y = 0f;
                }

                // Spawn the NPC at the adjusted position
                GameObject npc = Instantiate(prefab, randomPosition, Quaternion.identity);
            }
        }
    }
}
