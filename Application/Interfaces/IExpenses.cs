using ChurchPlusAPI_v1._0.DTOs;

namespace ChurchPlusAPI_v1._0.Application.Interfaces;
public interface IExpenses
{
    Task<ResponseDto> AddExpense(CreateExpenseDto dto, int createdby);
    Task<ResponseDto> GetExpenseList();
    Task<ResponseDto> GetExpenseById(int Id, CancellationToken cancellationToken = default);
    Task<ResponseDto> UpdateExpense(UpdateExpenseDto dto, int updateBy);
    Task<ResponseDto> DeleteExpense(int Id, int deleteBy);

}