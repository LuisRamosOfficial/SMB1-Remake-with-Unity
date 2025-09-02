using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Physics Settings")]
    public float gravity = -9.8f;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Player Settings")]
    public int maxHealth = 100;
}