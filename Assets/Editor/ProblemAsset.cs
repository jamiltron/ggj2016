using UnityEngine;
using UnityEditor;

public class ProblemAsset {
  
  [MenuItem("Assets/Create/Problem")]
  public static void CreateAsset() {
    ScriptableObjectUtility.CreateAsset<Problem>();
  }

}