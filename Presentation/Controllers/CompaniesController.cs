using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ISender _sender;

    public CompaniesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetTestMessage()
    {
        var companies = await _sender.Send(new GetCompaniesQuery(TrackChanges: false));

        return Ok(companies);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompany([FromRoute] int id)
    {
        var company = await _sender.Send(new GetCompanyQuery(Id: id, TrackChanges: false));

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreationDto)
    {
        if (companyForCreationDto is null)
        {
            return BadRequest($"{nameof(CompanyForCreationDto)} is null.");
        }

        var company = await _sender.Send(new CreateCompanyCommand(Company: companyForCreationDto));

        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }
}
