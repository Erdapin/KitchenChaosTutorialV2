using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCut;
    public class OnProgressChangedEventArgs: EventArgs
    {
        public float progressNormalized;
    }
    [SerializeField] private CuttingRecepieSO[] cuttingRecipeSOArray;
    private int cuttingProgress;

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
                    cuttingProgress = 0;

                    CuttingRecepieSO cuttingRecepieso = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecepieso.cuttingProgressMax
                    });
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
            cuttingProgress++;
            //Theres a kitchen object in ehre
            OnCut?.Invoke(this, EventArgs.Empty);
            CuttingRecepieSO cuttingRecepieso = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / cuttingRecepieso.cuttingProgressMax
            });

            if (cuttingProgress>= cuttingRecepieso.cuttingProgressMax) { 
                KiitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                
                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KiitchenObjectSO kitchenObjectSO) 
    {
        CuttingRecepieSO cuttingRecepieso = GetCuttingRecipeSOWithInput(kitchenObjectSO);
        return cuttingRecepieso != null;
    }

    private KiitchenObjectSO GetOutputForInput(KiitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecepieSO cuttingRecepieso = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if(cuttingRecepieso != null)
        {
            return cuttingRecepieso.output;
        }
        else { 
            return null;
        }
    }

    private CuttingRecepieSO GetCuttingRecipeSOWithInput(KiitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecepieSO cuttingRecepieSO in cuttingRecipeSOArray)
        {
            if (cuttingRecepieSO.input == inputKitchenObjectSO)
            {
                return cuttingRecepieSO;
            }
        }
        return null;
    }

}
