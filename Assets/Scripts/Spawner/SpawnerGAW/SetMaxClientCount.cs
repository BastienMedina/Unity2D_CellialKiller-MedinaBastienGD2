using UnityEngine;

public class SetMaxClientCount : MonoBehaviour
{
    [SerializeField] private Counts _exitCount;
    [SerializeField] private ScoresCount _arcadeScore;
    [SerializeField] private int _securCount = 2;

    public int SetMax() //Retourne le max de clients selon exit et score
    {
        int count = _exitCount.count * _arcadeScore.Score;
        if (count > 0) //Si le calcul est positif
        {
            return count;
        }
        else //Sinon retourne le minimum
        {
            return _securCount;
        }
    }
}
