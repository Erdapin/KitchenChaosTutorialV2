using UnityEngine;

[CreateAssetMenu]
public class FryingRecipeSO : ScriptableObject
{
    public KiitchenObjectSO input;
    public KiitchenObjectSO output;
    public float fryingTimerMax;
}
