using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Sceneを変更するメソッド
    public void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
