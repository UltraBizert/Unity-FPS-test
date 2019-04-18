using UnityEngine;

[CreateAssetMenu(menuName = "Configs/NPC", fileName = "NPCConfig")]
public class NPCConfig : ScriptableObject
{
    public float MoveSpeed = 1;
    public float AttackRange = 1;
    public float AttackDelay = 3f;
    public int Health = 100;
    public float Damage = 1;
}
