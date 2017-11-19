using System.Collections;
using System.Collections.Generic;
using Game.Weapons;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get { return instance == null ? FindObjectOfType<GameManager>() : instance; }
    }

    private static GameManager instance;

    public Camera GameCamera;
    public Player Player;
    public WeaponController PlayerWeaponController;

    void Awake()
    {
        instance = this;
    }

}
