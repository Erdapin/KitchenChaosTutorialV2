using UnityEngine;

[CreateAssetMenu]
public class BurningRecipeSO : ScriptableObject
{
    public KiitchenObjectSO input;
    public KiitchenObjectSO output;
    public float burningTimerMax;
}
