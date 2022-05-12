using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData",menuName = "ScriptableObject/PlayerData")]
public class PlayerData :ScriptableObject
{
    public float moveSpeed;
    public float originalMoveSpeed;
    public float jumpForce;
    public float dashCoefficient;
    public float slideCoefficient;
    public int atk;
    public int def;
    public int maxHP;
    public int currentHP;
    public int maxMP;
    public int currentMP;
}
