using AutoMapper;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Components.Constants;
using PGTech_io.DTO;
using PGTech_io.Interfaces;
using PGTech_io.Models;
using PGTech_io.Services;

namespace PGTech_io.Repository;

public class SenderRepository : ISender
{
    private readonly Context _db;
    private readonly IMapper _mapper;
    private readonly UserService _userService;

    public SenderRepository(Context context, IMapper mapper, UserService userService)
    {
        _db = context;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<bool> Create(SenderDTO sender)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            Console.WriteLine($"HERE {sender.Client}");
            
            var map = _mapper.Map<Sender>(sender);
            
            await _db.Solicits.AddAsync(map);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Solicitation could not be saved."
            : $"Solicitation saved.");
            
            await transaction.CommitAsync();

            return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<SenderDTO?> Get(int id)
    {
        try
        {
            var result = _db.Solicits.FirstOrDefault(x => x.Id == id);
            
            var map = _mapper.Map<SenderDTO>(result);
            
            return map;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<SenderDTO?>> GetAll()
    {
        var newList = new List<SenderDTO>();
        try
        {
            var result = _db.Solicits
                .Include(x => x.Responses)
                .OrderByDescending(x => x.Createdwhen)
                .ToList();

            foreach (var sender in result)
            {
                var map = _mapper.Map<SenderDTO>(sender);
                if (!string.IsNullOrEmpty(Convert.ToString(sender.Iduser)))
                    map.UserName = await _userService.obtainUserNameByUserId(sender.Iduser);
                if (sender.Responses.Any())
                    map.isAnswered = "Contestado";
                
                newList.Add(map);
            }
            
            if (result.Count == 0)
                Console.WriteLine("No solicitations were found.");
            
            return newList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(SenderDTO sender, int id)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();

        try
        {
            var exitingSolicitation = await _db.Solicits.FindAsync(id);
            
            exitingSolicitation.Client = sender.Client;
            exitingSolicitation.Sector = sender.Sector;
            exitingSolicitation.Subsector = sender.Subsector;
            exitingSolicitation.Problemdescription = sender.Problemdescription;
            exitingSolicitation.Updatedwhen = sender.Updatedwhen;
            
            _db.Solicits.Update(exitingSolicitation);
            
            var saved = await _db.SaveChangesAsync() > 0;
            
            Console.WriteLine(!saved
            ? "Solicitation could not be saved."
            : $"Solicitation saved.");
            
            await transaction.CommitAsync();

            return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Delete(SenderDTO sender)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        
        try
        {
            var map = _mapper.Map<Sender>(sender);
            
           _db.Solicits.Remove(map);
           
           var saved = await _db.SaveChangesAsync() > 0;
           
           Console.WriteLine(!saved
           ? "Solicitation could not be saved."
           : $"Solicitation saved.");

           await transaction.CommitAsync();
           
           return saved;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e);
            throw;
        }
    }
}