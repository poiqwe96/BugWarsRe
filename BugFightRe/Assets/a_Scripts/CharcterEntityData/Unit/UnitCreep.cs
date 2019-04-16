﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UnitCreep : Unit,IpoolingObj
{
  
   public GameManager myManagerGame { get ; set ; }
    public UnityAction<GameObject> OnEnqueActionObj { get; set; } 
    
    private void Awake()
    {
        
        MainSetInstance();
        
        SetDir();
       
    }
    protected override void MainSetInstance()
    {
        base.MainSetInstance();
        myManagerGame = GameManager.myInstance;

    }
    #region GetStat
    public override float GetArmor()
    {
        return myStat.m_BaseArmor;
    }
    public override float GetAttackDamage()
    {
        return myStat.m_BaseDamage;
    }
    public override float GetAttackSpeed()
    {
        return myStat.m_BaseAttackSpeed;
    }
    public override float GetMaxHealth()
    {
        return myStat.m_BaseHealth;
    }
    public override float GetSpellArmorPercent()
    {
        return myStat.m_BaseMagicArmor;
    }
    public override float GetSpellDamagePercent()
    {
        return myStat.m_BaseSpellAmply;
    }
    #endregion
    public override void GetKill()
    {
        base.GetKill();

        myObj.SetActive(false);
        OnEnqueue();
    }

    public void OnDequeue()
    {
        myIsDead = false;
        SetHpToMax();
        myUnitStatement = UnitStatement.Walk;
        OnDequeueAction?.Invoke();
        myCollider2D.enabled = true;
    }
    public void OnEnqueue()
    {
        OnEnqueueAction?.Invoke();
        OnEnqueActionObj?.Invoke(myObj);
    }

   

}
