using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void Enter(Enemy enemy); // Called when entering the state
    void Update(Enemy enemy); // Called every frame in this state
    void Exit(Enemy enemy); // Called when exiting the state
}
