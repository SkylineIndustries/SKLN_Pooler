using UnityEditor;
using UnityEngine;

namespace SKLN_Pooler.PoolableObject
{
    [CustomEditor(typeof(PoolableObject))]
    public class PoolableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            PoolableObject poolableObject = (PoolableObject)target;
            
            poolableObject.despawnMode = (DespawnMode)EditorGUILayout.EnumPopup("Despawn Mode", poolableObject.despawnMode);

            switch (poolableObject.despawnMode)
            {
                case DespawnMode.Timer:
                    poolableObject.despawnTime = EditorGUILayout.FloatField("Despawn Time", poolableObject.despawnTime);
                    break;
                case DespawnMode.OnCollision:
                    poolableObject.collisionThreshold = EditorGUILayout.FloatField("Collision Threshold", poolableObject.collisionThreshold);

                    EditorGUILayout.LabelField("Tags");
                    for (int i = 0; i < poolableObject.tags.Count; i++)
                    {
                        poolableObject.tags[i] = EditorGUILayout.TagField("Tag " + (i + 1), poolableObject.tags[i]);
                    }

                    if (GUILayout.Button("Add Tag"))
                    {
                        poolableObject.tags.Add("Untagged");
                    }

                    if (GUILayout.Button("Remove Tag"))
                    {
                        if (poolableObject.tags.Count > 0)
                        {
                            poolableObject.tags.RemoveAt(poolableObject.tags.Count - 1);
                        }
                    }
                
                    break;
                case DespawnMode.Manual:
                    break;
            }
        
            if (GUI.changed)
            {
                EditorUtility.SetDirty(poolableObject);
            }
        }
    }
}