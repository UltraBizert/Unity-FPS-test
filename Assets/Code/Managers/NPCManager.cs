using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Transform SpawnPosition;
    public NPC NPCPrefab;
    public NPCConfig NPCConfig;
    public Player Player;
    public int NPCInWaveCount = 10;
    public Action AllNPCDead;

    private List<NPC> npcs = new List<NPC>();

    private void Awake()
    {
        for (var i = 0; i < NPCInWaveCount; i++)
            SwapnNPC();
    }

    public void StartRound()
    {
        foreach (var npc in npcs)
        {
            npc.transform.position = SpawnPosition.transform.position;
            npc.Resurrect();
        }
    }

    private void SwapnNPC()
    {
        var npc = Instantiate(NPCPrefab, transform);
        npc.transform.position = SpawnPosition.transform.position;
        npcs.Add(npc);
        npc.OnDie += OnNPCDie;
        npc.Initialize(NPCConfig, Player);
    }

    private void Update()
    {
        npcs.ForEach(n => n.UpdateTick());
    }

    private void OnNPCDie()
    {
        if (npcs.Any(n => !n.IsDied)) return;

        AllNPCDead?.Invoke();
    }
}
