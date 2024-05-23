using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public partial class Asset : IPublishable
{
    
    public AcmeAssetIdentifier AssetIdentifier { get; private set; }
    public EPublishingStatus Status { get; protected set; }
    public EAssetType Type { get; private set; }
    public virtual bool Readable => false;
    public virtual bool Viewable => false;

    public Asset(EAssetType type)
    {
        Type = type;
        Status = EPublishingStatus.Draft;
        AssetIdentifier = new AcmeAssetIdentifier();
    }

    public Asset()
    {
        Type = EAssetType.ReadableContentItem;
        Status = EPublishingStatus.Draft;
        AssetIdentifier = new AcmeAssetIdentifier();
    }

    public virtual object GetContent()
    {
        return string.Empty;
    }
    
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }
}