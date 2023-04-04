using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startBalance = 250;
    [SerializeField] private TMP_Text balanceText;

    private int _currentBalance;
    public int curretnBalance
    {
        get { return _currentBalance; }
    }

    private void Start()
    {
        _currentBalance = startBalance;
        ChangeText();
    }

    public void Deposite(int value)
    {
        _currentBalance += Mathf.Abs(value);
        ChangeText();

        if(_currentBalance > 500)
        {
            ReloadScene();
        }
    }

    public void WithDraw(int value)
    {
        _currentBalance -= Mathf.Abs(value);
        ChangeText();

        if(_currentBalance < 0)
            ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ChangeText()
    {
        balanceText.text = $"Gold: {_currentBalance}";
    }
}
