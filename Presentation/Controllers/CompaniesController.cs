using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
}
