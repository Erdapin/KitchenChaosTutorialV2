using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KiitchenObjectSO kitchenObjectSO;



    public KiitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

}
