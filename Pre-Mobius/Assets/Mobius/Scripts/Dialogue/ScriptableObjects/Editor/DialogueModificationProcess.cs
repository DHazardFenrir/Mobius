using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace DialogueSystem.Editor 
{
    public class DialogueModificationProcess : UnityEditor.AssetModificationProcessor
    {
        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            DialogScriptable dialogue = AssetDatabase.LoadMainAssetAtPath(sourcePath) as DialogScriptable;

            if(dialogue == null)
            {
                return AssetMoveResult.DidNotMove;
            }

           if( Path.GetDirectoryName(sourcePath) != Path.GetDirectoryName(destinationPath))
            {
                return AssetMoveResult.DidNotMove;
            }

            dialogue.name = Path.GetFileNameWithoutExtension(destinationPath);

            return AssetMoveResult.DidNotMove;
        }
    }
}

