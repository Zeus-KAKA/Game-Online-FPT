using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystem : NetworkBehaviour
{
    public TextMeshProUGUI textMassage;
    public TMP_InputField inputFieldMessage;
    public GameObject buttonSend;
    //chay ngay sau khi player dc spawn trong mang
    public override void Spawned()
    {
        textMassage = GameObject.Find("Text Message")
            .GetComponent<TextMeshProUGUI>();
        inputFieldMessage = GameObject.Find("InputField Message")
            .GetComponent<TMP_InputField>();
        buttonSend = GameObject.Find("Button Send");
        buttonSend.GetComponent<Button>()
            .onClick.AddListener(SendMessageChat);
    }
    public void SendMessageChat()
    {
        var message = inputFieldMessage.text;
        if (string.IsNullOrWhiteSpace(message)) return;
        var id = Runner.LocalPlayer.PlayerId;
        var text = $"Player {id}: {message}";
        RpcChat(text);
        inputFieldMessage.text = "";
    }
    //Sources: gui tu dau
    //Targets: doi tuong nhan
    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RpcChat(string msg)
    {
        textMassage.text += msg + "\n";
    }
}
