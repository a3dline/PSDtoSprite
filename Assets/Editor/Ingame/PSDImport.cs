using UnityEngine;
using UnityEditor;
using PhotoshopFile;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

namespace Ingame.PSD
{
    /// <summary>
    /// PSD Utils
    /// </summary>
    public static class PSDUtils
    {
        /// <summary>
        /// Load PSD file
        /// </summary>
        /// <param name="path">Path to psd file</param>
        public static PsdFile ImportPSD(string path)
        {
            PsdFile psd = null;
            psd = new PsdFile(path, Encoding.Default);
            Debug.Log("Import PSD File " + Path.GetFileNameWithoutExtension(path));
            return psd;
        }

        /// <summary>
        /// Modify Sprite atlass meta by Psd Layer
        /// </summary>
        public static void CreatSpriteFromLayers(PsdFile psd, AssetImporter importer)
        {
            TextureImporter texImp = importer as TextureImporter;
            string name = Path.GetFileNameWithoutExtension(importer.assetPath);
            name = name.Replace("_atlas", "");
            SpriteMetaData[] tmpMeta = texImp.spritesheet;
            List<SpriteMetaData> sprMeta = new List<SpriteMetaData>();
            texImp.textureType = TextureImporterType.Sprite;
            texImp.spriteImportMode = SpriteImportMode.Multiple;
            texImp.spritePixelsPerUnit = 100;
            texImp.spritePackingTag = null;

            foreach (Layer layer in psd.Layers)
            {
                if (layer.Name != "</Layer set>" &&
                    layer.Name != "</Layer group>" &&
                    layer.Visible &&
                    layer.Rect.width > 0 &&
                    layer.Rect.height > 0)
                {
                    SpriteMetaData smd = new SpriteMetaData();
                    smd.name = name + "." + layer.Name;
                    smd.rect = new Rect(
                        layer.Rect.x,
                        psd.RowCount - layer.Rect.y - layer.Rect.height,
                        layer.Rect.width,
                        layer.Rect.height);

                    foreach (SpriteMetaData s in tmpMeta)
                    {
                        if (smd.name == s.name)
                        {
                            smd.pivot = s.pivot;
                            smd.border = s.border;
                            smd.alignment = s.alignment;
                        }
                    }
                    sprMeta.Add(smd);
                }
            }

            texImp.spritesheet = sprMeta.ToArray();
        }
    }
}
