using System;
using ArrayReversingApi.Interface;
using Microsoft.AspNetCore.Mvc;


namespace ArrayReversingApi.Controllers
{
    [Route("api/[controller]")]
    public class ArrayCalcController : Controller
    {
        private readonly IArrayReversingService _arrayReversingService;

        public ArrayCalcController(IArrayReversingService arrayReversingService)
        {
            _arrayReversingService = arrayReversingService;
        }

        // GET api/arraycalc
        [HttpGet]
        public IActionResult GetHome()
        {
            return Ok("Array Calc API");
        }

        // GET api/arraycalc/reverse
        [HttpGet("reverse")]
        public IActionResult GetReversed([FromQuery]string[] productIds)
        {
            try
            {
                var result = _arrayReversingService.ManipulatedArray(productIds);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Error while reversing array: " + e.Message);
            }
        }

        // GET api/arraycalc/deletepart
        [HttpGet("deletepart")]
        public IActionResult GetDeleted([FromQuery]string position, [FromQuery]string[] productIds)
        {
            try
            {
                var result = _arrayReversingService.DeletedArrayElement(productIds, position);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Error while deleteng element: " + e.Message);
            }
        }
    }
}
