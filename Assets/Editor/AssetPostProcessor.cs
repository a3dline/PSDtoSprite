using UnityEngine;
using UnityEditor;
using System.Collections;
using PhotoshopFile;
using Ingame.PSD;

public class AssetPostProcessor : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D text)
    {
        ///Load PSD
        if (assetPath.ToLower().EndsWith(PSDUtils.psdImportSettings.psdSuffix + ".psd"))
        {
            PsdFile psd = PSDUtils.ImportPSD(assetPath);
            if (psd != null) PSDUtils.CreatSpriteFromLayers(psd, assetImporter);
            else LogError("Can not read the PSD Atlass File: " + assetPath);
        }
    }
}
