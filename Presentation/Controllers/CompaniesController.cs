using Application.Commands;
using Application.Notifications;
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
    private readonly IPublisher _publisher;

    public CompaniesController(
        ISender sender,
        IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
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
            return BadRequest($"{nameof(CompanyForCreationDto)} object is null.");
        }

        var company = await _sender.Send(new CreateCompanyCommand(Company: companyForCreationDto));

        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCompany([FromRoute] int id, [FromBody] CompanyForUpdateDto companyForUpdateDto)
    {
        if (companyForUpdateDto is null)
        {
            return BadRequest($"{nameof(CompanyForUpdateDto)} object is null.");
        }

        await _sender.Send(new UpdateCompanyCommand(Id: id, Company: companyForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCompany([FromRoute] int id)
    {
        await _publisher.Publish(new CompanyDeletedNotification(Id: id, TrackChanges: false));

        return NoContent();
    }
}
