using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform[] runners = new Transform[5];
    public float speed;
    public float passDistance;

    private int currentRunnerIndex;
    private Transform currentRunner;
    private Transform nextRunnner;
    private float distance;

    private void Start() {
        currentRunnerIndex = 0;
    }

    private void Update() {
        currentRunner = runners[currentRunnerIndex];
        nextRunnner = runners[(currentRunnerIndex + 1) % runners.Length]; // При достижении 5го бегуна, остаток от деления будет 0 
                                                                          // и текущим раннером снова станет объект с индексом 0
        SwitchRunner();
        currentRunner.LookAt(nextRunnner);
        currentRunner.position = Vector3.MoveTowards(currentRunner.position, nextRunnner.position, Time.deltaTime * speed);

    }

    public void SwitchRunner () {
        distance = Vector3.Distance(currentRunner.position, nextRunnner.position);

        if (distance <= passDistance) {
            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
        }
    }

}
