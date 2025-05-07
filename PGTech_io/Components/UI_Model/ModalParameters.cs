using PGTech_io.Interfaces;

namespace PGTech_io.Components.UI_Model;

public class ModalParameters(bool isUpdate, bool isModalVisible, IMessageType? messageType)
{
    public bool isUpdate { get; } = isUpdate;
    public bool isVisible { get; } = isModalVisible;
    public IMessageType? messageType { get; } = messageType;
}