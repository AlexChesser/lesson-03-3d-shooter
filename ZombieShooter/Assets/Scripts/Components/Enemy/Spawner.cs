using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable[] prefabs;
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private float initialSpawnDelay;
    [SerializeField] private float respawnRate = 10f;
    [SerializeField] private int totalNumberToSpawn;
    [SerializeField] private int numberPerSpawn;

    private int numberSpawned;
    private float spawnTimer;

    private void OnEnable()
    {
        numberSpawned = 0;
        spawnTimer = respawnRate - initialSpawnDelay;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (IsTimeToSpawn()) {
            Spawn();
        }
    }

    private void Spawn()
    {
        List<Transform> availableSpawnPoints = spawnpoints.ToList();
        spawnTimer = 0;
        for (int i = 0; i < numberPerSpawn; i++) {
            if (totalNumberToSpawn > 0 && numberSpawned >= totalNumberToSpawn) {
                break;
            }
            numberSpawned++;
            Spawnable prefab = GetRandomPrefab();
            if (prefab != null) {
                Transform spawnpoint = GetRandomSpawnpoint(availableSpawnPoints);
                if (availableSpawnPoints.Contains(spawnpoint)) {
                    availableSpawnPoints.Remove(spawnpoint);
                }
                prefab.Get<Spawnable>(spawnpoint.position, spawnpoint.rotation);
            }
        }
    }

    private Spawnable GetRandomPrefab()
    {
        if (prefabs.Length == 0) { return null; }
        if (prefabs.Length == 1) {
            return prefabs[0];
        }
        return prefabs[Random.Range(0, prefabs.Length)];
    }

    private Transform GetRandomSpawnpoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0) { return transform; }
        if (availableSpawnPoints.Count == 1)
        {
            return availableSpawnPoints[0];
        }
        return spawnpoints[Random.Range(0, availableSpawnPoints.Count)];
    }


    private bool IsTimeToSpawn()
    {
        if (totalNumberToSpawn > 0 && numberSpawned >= totalNumberToSpawn)
        {
            return false;
        }
        if (spawnTimer >= respawnRate) {
            spawnTimer = 0;
            return true;
        }
        return false;
    }

#if UNITY_EDITOR

    private void MeshGizmo(GameObject prefab, Transform spawn) {
        Mesh mesh = prefab.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh;
        float scale = 0.01f;
        Gizmos.DrawWireMesh(mesh, spawn.transform.position, spawn.rotation, new Vector3(scale, scale, scale));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one);
        foreach (var spawn in spawnpoints) {
            //if (prefabs.Any())
            //{
            //    MeshGizmo(prefabs[0], spawn);
            //}
            //else {
                Gizmos.DrawSphere(spawn.transform.position, 0.5f);
            //}
        }
    }

#endif

}
