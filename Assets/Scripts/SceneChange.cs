using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Scene��ύX���郁�\�b�h
    public void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
