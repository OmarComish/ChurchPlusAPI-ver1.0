using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChurchPlusAPI_v1._0.Controllers;

[ApiController]
[Route("api/expenses")]
public class ExpensesController: ControllerBase
{
    private readonly IExpenses _expenses;
    public ExpensesController(IExpenses expenses)
    {
        _expenses = expenses;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto>> AddOffering(CreateExpenseDto dto)
    {
        var response = new ResponseDto {Status ="error", Message ="Null expenses data. Could not save to database"};
        if(dto!= null)
        {
            //Hardcoded value. Replace with actual user who created the expense
            response = await _expenses.AddExpense(dto, 1);
        }
        return Ok(response);
    }
    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponseDto>> GetExpenseById(int Id)
    {
        var response = await _expenses.GetExpenseById(Id);
        return Ok(response);
    }
    [HttpGet]
    public async Task<ActionResult<ResponseDto>> GetExpenses()
    {
        var response = await _expenses.GetExpenseList();
        return Ok(response);
    }
}