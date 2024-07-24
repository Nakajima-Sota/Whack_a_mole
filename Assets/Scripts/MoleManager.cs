using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public MoleMovement[] moles;
    private float moleUpTime = 1.0f;
    public Timer timerManager;
    private float delayBetweenMoles = 0.2f;

    private bool twoMolesActive = false;
    private bool threeMolesActive = false;

    void Start()
    {
        StartCoroutine(ManageMoles());
    }

    IEnumerator ManageMoles()
    {
        while (timerManager.TimeRemaining > 0)
        {
            if (timerManager.TimeRemaining <= 30 && !twoMolesActive)
            {
                twoMolesActive = true;
            }
            if (timerManager.TimeRemaining <= 15 && !twoMolesActive)
            {
                threeMolesActive = true;
            }
            if (twoMolesActive)
            {
                int firstMoleIndex = Random.Range(0, moles.Length);
                int secondMoleIndex;

                
                do
                {
                    secondMoleIndex = Random.Range(0, moles.Length);
                } while (secondMoleIndex == firstMoleIndex);

                moles[firstMoleIndex].SetUp(true);

                yield return new WaitForSeconds(delayBetweenMoles);

                moles[secondMoleIndex].SetUp(true);

                yield return new WaitForSeconds(moleUpTime);

                moles[firstMoleIndex].SetUp(false);
                moles[secondMoleIndex].SetUp(false);
            }
            else
            {
                int moleIndex = Random.Range(0, moles.Length);
                moles[moleIndex].SetUp(true);

                yield return new WaitForSeconds(moleUpTime);

                moles[moleIndex].SetUp(false);
            }

            yield return new WaitForSeconds(moleUpTime);
        }
    }
}