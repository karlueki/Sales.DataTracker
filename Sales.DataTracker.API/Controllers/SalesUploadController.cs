using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.DataTracker.API.Dto;
using Sales.DataTracker.API.Interface;

namespace Sales.DataTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "ApiKey")]
    public class SalesUploadController : ControllerBase
    {
        private readonly ILogger<SalesUploadController> _logger;
        private readonly ISalesUpload _salesUpload;
        private readonly ISalesTrackerDBHandler _salesTrackerDBHandler;

        private const long MaxFileSize = 10L * 1024L * 1024L * 1024L; // 10GB, adjust to your need


        public SalesUploadController(ILogger<SalesUploadController> logger, ISalesUpload salesUpload, ISalesTrackerDBHandler salesTrackerDBHandler)
        {
            _logger = logger;
            _salesUpload = salesUpload;
            _salesTrackerDBHandler = salesTrackerDBHandler;
        }

        [HttpPost]
        [Route("UploadOrderDetailsFile")]
        [RequestSizeLimit(MaxFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
        public async Task<ActionResult> UploadOrderDetailsFile([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                List<OrderDetailsDto> orderDetailsDtoList = await _salesUpload.UploadOrderDetails(file);
                _salesTrackerDBHandler.SaveOrderDetails(orderDetailsDtoList);
                return Ok("File successfully uploaded!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(UploadOrderDetailsFile)} failed to complete.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload file.");
            }
        }

        [HttpPost]
        [Route("UploadOrdersFile")]
        [RequestSizeLimit(MaxFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
        public async Task<ActionResult> UploadOrdersFile([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                List<OrderDto> orderDtoList = await _salesUpload.UploadOrder(file);
                _salesTrackerDBHandler.SaveOrder(orderDtoList);
                return Ok("File successfully uploaded!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(UploadOrdersFile)} failed to complete.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload file.");
            }
        }

        [HttpPost]
        [Route("UploadPizzaFile")]
        [RequestSizeLimit(MaxFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
        public async Task<ActionResult> UploadPizzaFile([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                List<PizzaDto> pizzaDtoList = await _salesUpload.UploadPizza(file);
                _salesTrackerDBHandler.SavePizza(pizzaDtoList);
                return Ok("File successfully uploaded!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(UploadPizzaFile)} failed to complete.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload file.");
            }
        }

        [HttpPost]
        [Route("UploadPizzaTypeFile")]
        [RequestSizeLimit(MaxFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = MaxFileSize)]
        public async Task<ActionResult> UploadPizzaTypeFile([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                List<PizzaTypeDto> pizzaTypeDtoList = await _salesUpload.UploadPizzaType(file);
                _salesTrackerDBHandler.SavePizzaTypes(pizzaTypeDtoList);
                return Ok("File successfully uploaded!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(UploadPizzaTypeFile)} failed to complete.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload file.");
            }
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                 
                return Ok(_salesTrackerDBHandler.GetOrders());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(GetOrders)} failed to complete.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to upload file.");
            }
        }
    }
}
