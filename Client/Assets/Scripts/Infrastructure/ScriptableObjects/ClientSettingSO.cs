using UnityEngine;

namespace EslOnline.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(menuName = nameof(ScriptableObject) + "/" + nameof(ClientSettingSO))]
    public class ClientSettingSO : ScriptableObject
    {
        public string TelegramGroupUrl = "https://t.me/SumrovDevelopment";
        public string HostBaseUrl = "http://localhost:5182";
        public string GoogleAuthResponseString;
    }
}