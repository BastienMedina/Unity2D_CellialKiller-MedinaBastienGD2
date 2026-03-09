using UnityEngine;

public class UpgradeSurvivor : MonoBehaviour
{
    public void Speed()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMouvements>().IncreaseSpeed();
    }

    public void Life()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerArcade>().RestoreLife();
    }

    public void MaxLife()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerArcade>().IncreaseMaxLife();
    }

    public void Rate()
    {
        GameObject.FindWithTag("Player").GetComponent<AutoAttacker>().DecreaseInterval();
    }

    public void Damages()
    {
        GameObject.FindWithTag("Player").GetComponent<AutoAttacker>().IncreaseDamages();
    }

    public void Phone()
    {
        GameObject.FindWithTag("Player").GetComponent<PhoneThrower>().IncreasePhoneStock();
    }
}
