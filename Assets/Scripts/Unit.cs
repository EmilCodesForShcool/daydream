using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
    }
}
