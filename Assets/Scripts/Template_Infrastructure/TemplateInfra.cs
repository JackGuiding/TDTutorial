using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TemplateInfra {

    public static void Load(TemplateContext ctx) {
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Role"; // label
            IList<RoleTM> all = Addressables.LoadAssetsAsync<RoleTM>(labelReference, null).WaitForCompletion();
            for (int i = 0; i < all.Count; i += 1) {
                RoleTM tm = all[i];
                ctx.roles.Add(tm.typeID, tm);
            }
        }

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Tower"; // label
            IList<TowerTM> all = Addressables.LoadAssetsAsync<TowerTM>(labelReference, null).WaitForCompletion();
            for (int i = 0; i < all.Count; i += 1) {
                TowerTM tm = all[i];
                ctx.towers.Add(tm.typeID, tm);
            }
        }

    }

}