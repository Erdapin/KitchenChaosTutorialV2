using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecepieSO[] cuttingRecipeSOArray;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Grab
            if (player.HasKitchenObject())
            {
                //player Carring

                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) { 
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
            else
            {
                //player not carrying
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                //player carrying
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            //Theres a kitchen object in ehre
            KiitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KiitchenObjectSO kitchenObjectSO) 
    {
        foreach (CuttingRecepieSO cuttingRecepieSO in cuttingRecipeSOArray)
        {
            if (cuttingRecepieSO.input == kitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KiitchenObjectSO GetOutputForInput(KiitchenObjectSO inputKitchenObjectSO)
    {
        foreach(CuttingRecepieSO cuttingRecepieSO in cuttingRecipeSOArray)
        {
            if(cuttingRecepieSO.input == inputKitchenObjectSO)
            {
                return cuttingRecepieSO.output;
            }
        }
        return null;
    }

}
