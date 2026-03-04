using EslOnline.SharedKernel.Domain.Enums;
using System;
using UnityEngine;

namespace EslOnline.Infrastructure.Repositories.ContentRepository.ContentRepositoryItems;

[Serializable]
public class ContentRepositoryItemSprite : ContentRepositoryItem<Sprite>
{
    [SerializeField] public GoodType GoodType;
}