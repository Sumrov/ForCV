using EslOnline.Infrastructure.Repositories.ContentRepository.ContentRepositoryItems;
using EslOnline.Infrastructure.ScriptableObjects;
using System;
using System.Linq;
using UnityEngine;

#nullable enable

namespace EslOnline.Infrastructure.Repositories.ContentRepository;

public class ContentRepository
{
    private readonly ContentRepositoryDatabaseSO _dataBase;

    public ContentRepository(ContentRepositoryDatabaseSO dataBase)
    {
        _dataBase = dataBase;
    }

    public string? GetText()
    {
        return _dataBase.Texts.FirstOrDefault().Content;
    }

    public Sprite? GetSprite(Func<ContentRepositoryItemSprite, bool> predicate)
    {
        var content = _dataBase.Sprites.SingleOrDefault(predicate)?.Content;
        return content ?? _dataBase.DefaultSprites;
    }

    public GameObject? GetPrefab()
    {
        return _dataBase.Prefabs.FirstOrDefault().Content;
    }
}