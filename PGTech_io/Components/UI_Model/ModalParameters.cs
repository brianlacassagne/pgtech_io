using PGTech_io.Interfaces;

namespace PGTech_io.Components.UI_Model;

public class ModalParameters(bool isUpdate, bool isModalVisible, string? userId, IMessageType? messageType)
{
    public bool isUpdate { get; } = isUpdate;
    public bool isVisible { get; } = isModalVisible;
    public string? userId { get; } = userId;
    public IMessageType? messageType { get; } = messageType;
}