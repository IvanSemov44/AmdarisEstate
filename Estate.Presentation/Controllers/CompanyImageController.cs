namespace IvanRealEstate.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using IvanRealEstate.Presentation.ActionFilter;
    using IvanRealEstate.Application.Commands.ImageCommads;
    using IvanRealEstate.Application.Queries.CompanyImageQuery;
    using IvanRealEstate.Shared.DataTransferObject.CompanyImage;
    using IvanRealEstate.Application.Commands.CompanyImageCommands;

    [ApiController]
    [Route("api/companies/{companyId:guid}/images")]
    public class CompanyImageController : ControllerBase
    {
        private readonly ISender _sender;

        public CompanyImageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImageForCompany(Guid companyId)
        {
            var imagesForReturn = await _sender.Send(new GetAllCompanyImagesQuery(companyId, TrackChanges: false));

            return Ok(imagesForReturn);
        }

        [HttpGet("{imageId:guid}", Name = "GetImageForCompany")]
        public async Task<IActionResult> GetImageForCompany(Guid companyId, Guid imageId)
        {
            var imageForReturn = await _sender.Send(new GetCompanyImageQuery(companyId, imageId, TrackChanges: false));

            return Ok(imageForReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateImageForCompany(Guid companyId, [FromBody] CompanyImageForCreationDto imageForCreationDto)
        {
            var imageForReturn = await _sender.Send(new CreateCompanyImageCommand(companyId, imageForCreationDto, TrackChanges: false));

            return CreatedAtRoute("GetImageForCompany", new { companyId, imageId = imageForReturn.CompanyImageId }, imageForReturn);
        }

        [HttpPut("{imageId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateImageForEstate(Guid companyId, Guid imageId, CompanyImageForUpdateDto imageForUpdateDto)
        {
            await _sender.Send(new UpdateCompanyImageCommand(companyId, imageId, imageForUpdateDto, CompanyTrackChanges: false, CompanyImageTrackChanges: true));

            return NoContent();
        }

        [HttpDelete("{imageId:guid}")]
        public async Task<IActionResult> DeleteImageForCompany(Guid companyId, Guid imageId)
        {
            await _sender.Send(new DeleteCompanyImageCommand(companyId, imageId, TrackChanges: false));

            return NoContent();
        }
    }
}
