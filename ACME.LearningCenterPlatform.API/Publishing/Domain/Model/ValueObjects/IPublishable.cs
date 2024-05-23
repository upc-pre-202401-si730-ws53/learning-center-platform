namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

public interface IPublishable
{
    void SendToEdit();
    void SendToApproval();
    void ApproveAndLock();
    void Reject();
    void ReturnToEdit();
}