using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
    void TakeMagicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition mana { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue == 0f) 
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f) 
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Eat(float amount)
    {
        hunger.Add(amount);
    }
    private void Die()
    {
        Debug.Log("DIe!");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
    public void TakeMagicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
        //마나 감소는 어디에서 하나용
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue-amount<0f)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }
    public bool UseMana(float cost)
    {
        if (mana.curValue - cost < 0f)
        {
            return false;
        }
        mana.Subtract(cost);
        Debug.Log(mana.curValue);
        return true;
    }
    public void ManaAdd(float amount)
    {
        mana.Add(amount);
    }

}
