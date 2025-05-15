using PGTech_io.Data;
using PGTech_io.Interfaces;

namespace PGTech_io.Components.UI_Model;

public class ModalParameters(bool isUpdate, bool isModalVisible, ApplicationUser appUser, IMessageType? messageType)
{
    public bool isUpdate { get; } = isUpdate;
    
    public ApplicationUser appUser { get; } = appUser;
    public bool isVisible { get; } = isModalVisible;
    public IMessageType? messageType { get; } = messageType;
}