using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace EslOnline.Domain.Aggregates;

public class User(
    int balance,
    string gmail,
    string language,
    string? profilePictureUrl,
    string? telegram,
    UserId id,
    CitizenId citizenId
    )
    : AggregateRoot<UserId>(id)
{
    protected User() : this(default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public int Balance { get; private set; } = balance;
    [EmailAddress]
    public string GMail { get; private set; } = gmail;
    public string Language { get; private set; } = language;
    public string? ProfilePictureUrl { get; private set; } = profilePictureUrl;
    public string? Telegram { get; private set; } = telegram;
    public CitizenId CitizenId { get ; private set; } = citizenId;

    internal static User Create(
        string gmail,
        string language,
        CitizenId citizenId,
        string? profilePictureURL = null,
        string? telegram = null
        )
    {
        UserId id = new(Guid.CreateVersion7());

        return new(
            balance: 0,
            gmail: gmail,
            language: language,
            profilePictureUrl: profilePictureURL,
            telegram: telegram,
            id: id,
            citizenId: citizenId
            );
    }
}