using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("carId")]
        public IActionResult UploadImage(int carId, IFormFile file)
        {
            try
            {
                // Validate the car ID (you can add custom validation logic here)
                if (carId <= 0)
                {
                    return BadRequest("Invalid car ID");
                }

                // Check if a file was provided
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file was uploaded");
                }

                // Generate a unique file name
                string fileName = Guid.NewGuid().ToString();
                string[] filenameSplit = file.FileName.Split('.');
                string fileExtension = filenameSplit[1];
                // Define the path to save the file
                fileName = fileName + "." + fileExtension;

                var resp = Directory.CreateDirectory("wwwroot/CarImages");
                string filePath = Path.Combine("wwwroot/CarImages", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok($"Image uploaded successfully for Car ID: {carId}");
            }
            catch (Exception ex)
            {
                // Handle any exception that occurred during the process
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }

    /***********************************************************************************************************/

    //[HttpPost("add")]
    //public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
    //{
    //    var result = _carImageService.Add(file, carImage);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    //[HttpPost("delete")]
    //public IActionResult Delete(CarImage carImage)
    //{
    //    var carDeleteImage = _carImageService.GetByImageId(carImage.Id).Data;
    //    var result = _carImageService.Delete(carDeleteImage);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    //[HttpPost("update")]
    //public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
    //{
    //    var result = _carImageService.Update(file, carImage);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    //[HttpGet("getall")]
    //public IActionResult GetAll()
    //{
    //    var result = _carImageService.GetAll();
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return Ok(result);
    //}
    //[HttpGet("getbyimageid")]
    //public IActionResult GetByImageId(int imageId)
    //{
    //    var result = _carImageService.GetByImageId(imageId);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
}
