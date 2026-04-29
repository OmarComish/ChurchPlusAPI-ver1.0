using System.Data.Common;
using AutoMapper;
using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using ChurchPlusAPI_v1._0.Models;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlusAPI_v1._0.Application.Services;

public class ExpenseService : IExpenses
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public ExpenseService(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ResponseDto> AddExpense(CreateExpenseDto dto, int createdBy)
    {
        var response = new ResponseDto{Status ="error", Message ="Failed to add expense"};
        var _rs = _mapper.Map<Expense>(dto);
        _rs.CreatedBy = createdBy;
        _rs.DateCreated = DateTime.UtcNow;
        _rs.ApprovalStatus = RecordStatus.Pending;
        _rs.ExpenseStatus = RecordStatus.Pending;

        await _context.AddAsync(_rs);
        await _context.SaveChangesAsync();

        response.Status ="success";
        response.Message = $"Expense on {_rs.Description} added successully!";

        return response;
    }

    public Task<ResponseDto> DeleteExpense(int Id, int deleteBy)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto> GetExpenseById(int Id, CancellationToken cancellationToken = default)
    {
        var response = new ResponseDto {Status ="error", Message="Invalid or null Expense ID"};
          // Edge case: invalid ID
        if (Id <= 0)
        {
            response.Message =$"Expense ID must be a positive integer {nameof(Id)}";
        }
        try
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(x=>x.Id==Id, cancellationToken);

            //Edge case: Offering not found
            if(expense is null)
            {
                response.Message = $"Expense with ID {Id} was not found";
            }
            response.Status ="success";
            response.Message ="Fetch operation successful";
            response.Payload = _mapper.Map<ReadExpenseDto>(expense);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving the Expense.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving the Expense.",ex);
        }
        return response;
    }

    public async Task<ResponseDto> GetExpenseList()
    {
        var response = new ResponseDto {Status ="error", Message="No data found"};
  
        try
        {
            var expenses = await _context.Expenses.ToListAsync();

            //Edge case: Expense not found
            if(expenses is null)
            {
                response.Message = $"No Expenses were found";
            }
            response.Status ="success";
            response.Message =$"Fetch operation successful. Found {expenses.Count} entries";
            response.Payload = _mapper.Map<IEnumerable<ReadExpenseDto>>(expenses);
        }
        catch(OperationCanceledException)
        {
            throw new OperationCanceledException("The request was cancelled");
        }
        catch(DbException ex)
        {
            throw new ApplicationException("A database error occurred while retrieving the Expenses.", ex);
        }
        catch(Exception ex)
        {
             throw new ApplicationException("An unexpected error occurred while retrieving the Expenses.",ex);
        }
        return response;
    }

    public Task<ResponseDto> UpdateExpense(UpdateExpenseDto dto, int updateBy)
    {
        throw new NotImplementedException();
    }
}