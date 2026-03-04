using EslOnline.Infrastructure.Repositories.ContentRepository.ContentRepositoryItems;
using System.Collections.Generic;
using UnityEngine;

namespace EslOnline.Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(menuName = nameof(ScriptableObject) + "/" + nameof(ContentRepositoryDatabaseSO))]
    public class ContentRepositoryDatabaseSO : ScriptableObject
    {
        public string DefautTexts;
        public Sprite DefaultSprites;
        public GameObject DefautPrefabs;
        public List<ContentRepositoryItemText> Texts;
        public List<ContentRepositoryItemSprite> Sprites;
        public List<ContentRepositoryItemPrefab> Prefabs;
    }
}