// Controllers/ParametersController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadLibBackend.Data;
using CadLibBackend.Models;

namespace CadLibBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParametersController : ControllerBase
{
    private readonly CadLibDbContext _context;

    public ParametersController(CadLibDbContext context)
    {
        _context = context;
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ParameterDetailsDto>>> GetParametersByObjectName(
    [FromQuery] string objectName)
    {
        var query =
            from pd in _context.ParamDefs
            join ps in _context.ParametersStrs on pd.IdParamDef equals ps.IdParamDef
            join os in _context.ObjectsShadows on ps.IdObject equals os.IdObject
            where os.Name == objectName
            select new ParameterDetailsDto
            {
                ObjectId = os.IdObject,
                ParamDefId = pd.IdParamDef,
                ParamCaption = pd.Caption,       // Используем Caption вместо Name
                ParamValue = ps.Value
            };

        return Ok(await query.ToListAsync());
    }
    [HttpGet("search-by-cdeid")]
    public async Task<ActionResult<IEnumerable<ParameterDetailsDto>>> GetParametersByObjectName(
[FromQuery] int cdeid)
    {
        var query =
            from pd in _context.ParamDefs
            join ps in _context.ParametersStrs on pd.IdParamDef equals ps.IdParamDef
            join os in _context.ObjectsShadows on ps.IdObject equals os.IdObject
            where os.IdObject == cdeid
            select new ParameterDetailsDto
            {
                ObjectId = os.IdObject,
                ParamDefId = pd.IdParamDef,
                ParamCaption = pd.Caption,       // Используем Caption вместо Name
                ParamValue = ps.Value
            };

        return Ok(await query.ToListAsync());
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateParameter([FromBody] UpdateParameterRequest request)
    {
        try
        {
            // 1. Найти параметр в соответствующей таблице по типу
            dynamic parameter = null;
            var paramDef = await _context.ParamDefs.FindAsync(request.ParamDefId);

            switch (paramDef?.IdType)
            {
                case 1: // string
                    parameter = await _context.ParametersStrs
                        .FirstOrDefaultAsync(p =>
                            p.IdParamDef == request.ParamDefId &&
                            p.IdObject == request.ObjectId);
                    break;
                case 2: // int
                    parameter = await _context.ParametersInts
                        .FirstOrDefaultAsync(p =>
                            p.IdParamDef == request.ParamDefId &&
                            p.IdObject == request.ObjectId);
                    break;
                case 3: // double
                    parameter = await _context.ParametersDbls
                        .FirstOrDefaultAsync(p =>
                            p.IdParamDef == request.ParamDefId &&
                            p.IdObject == request.ObjectId);
                    break;
                default:
                    return BadRequest("Unsupported parameter type");
            }

            if (parameter == null)
                return NotFound("Parameter not found");

            // 2. Конвертация значения
            switch (paramDef.IdType)
            {
                case 2 when int.TryParse(request.NewValue, out var intValue):
                    parameter.Value = intValue;
                    break;
                case 3 when double.TryParse(request.NewValue, out var doubleValue):
                    parameter.Value = doubleValue;
                    break;
                case 1:
                    parameter.Value = request.NewValue;
                    break;
                default:
                    return BadRequest("Invalid value for parameter type");
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal error: {ex.Message}");
        }
    }
    public class UpdateParameterRequest
    {
        public int ObjectId { get; set; }
        public int ParamDefId { get; set; }
        public string NewValue { get; set; }
    }
}