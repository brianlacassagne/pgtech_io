using AutoMapper;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
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
            sender.Createdwhen = DateOnly.FromDateTime(DateTime.UtcNow);
            
            Console.WriteLine($"HERE {sender.Client}");
            
            var map = _mapper.Map<Send>(sender);
            
            await _db.Sends.AddAsync(map);
            
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
            var result = _db.Sends.FirstOrDefault(x => x.Id == id);
            
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
            var result = _db.Sends
                .Include(x => x.Responses)
                .Include(x => x.IduserNavigation)
                .Include(x => x.IdsectorNavigation)
                .OrderByDescending(x => x.Createdwhen)
                .ToList();

            foreach (var sender in result)
            {
                var map = _mapper.Map<SenderDTO>(sender);
                if (!string.IsNullOrEmpty(Convert.ToString(sender.Iduser)))
                    map.IdUserNavigation = await _userService.getUserByUserId(sender.Iduser);
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
    
    public async Task<List<SenderDTO?>> GetAllByUserId(string userId)
    {
        var newList = new List<SenderDTO>();
        try
        {
            var result = _db.Sends
                .Where(x => x.Iduser == userId)
                .Include(x => x.Responses)
                .Include(x => x.IduserNavigation)
                .Include(x => x.IdsectorNavigation)
                .OrderByDescending(x => x.Createdwhen)
                .ToList();

            foreach (var sender in result)
            {
                var map = _mapper.Map<SenderDTO>(sender);
                if (!string.IsNullOrEmpty(Convert.ToString(sender.Iduser)))
                    map.IdUserNavigation = await _userService.getUserByUserId(sender.Iduser);
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
            sender.Updatedwhen = DateOnly.FromDateTime(DateTime.UtcNow);
            
            var existingSend = await _db.Sends.FindAsync(id);
            
            existingSend.Client = sender.Client;
            existingSend.Idsector = sender.Idsector;
            existingSend.IdSubsector = sender.Idsubsector;
            existingSend.Problemdescription = sender.Problemdescription;
            existingSend.Updatedwhen = sender.Updatedwhen;
            
            _db.Sends.Update(existingSend);
            
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
            var map = _mapper.Map<Send>(sender);
            
           _db.Sends.Remove(map);
           
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