using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KiitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform topSection;
    public void Interact()
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, topSection);
        kitchenObjectTransform.localPosition = Vector3.zero;

        kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO();
    }
}
