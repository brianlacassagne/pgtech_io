using PGTech_io.DTO;
using PGTech_io.Models;

namespace PGTech_io.Interfaces;

public interface ISender
{
    public Task<bool> Create(SenderDTO solicitation);
    public Task<SenderDTO?> Get(int id);
    public Task<List<SenderDTO?>> GetAll();
    public Task<List<SenderDTO?>> GetAllByUserId(string userId);
    public Task<bool> Update(SenderDTO solicitation, int id);
    public Task<bool> Delete(SenderDTO solicitation);
}