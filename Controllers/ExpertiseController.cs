using CadLibBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadLibBackend.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class ExpertiseController : ControllerBase
{
    private readonly CadLibDbContext _context;

    public ExpertiseController(CadLibDbContext context)
    {
        _context = context;
    }

    // �������� ��� ���������� �������
    [HttpGet("by-object/{idObject}")]
    public async Task<ActionResult<IEnumerable<ExpertiseDto>>> GetByObject(int idObject)
    {
        return await _context.Expertises
            .Where(e => e.IdObject == idObject)
            .Select(e => new ExpertiseDto
            {
                Status = e.Status,
                Date = e.Date,
                Message = e.Message,
                Comment = e.Comment,
                IdObject = e.IdObject,
                IdFile = e.IdFile,
                IdNode = e.IdNode,
                ImageBase64 = e.Image != null ? Convert.ToBase64String(e.Image) : null,
                DocumentBase64 = e.Document != null ? Convert.ToBase64String(e.Document) : null,
                DocumentFileName = e.DocumentFileName,
                HazardCategory = e.HazardCategory
            })
            .ToListAsync();
    }

    // ������� ����� ����������
    [HttpPost]
    public async Task<ActionResult<Expertise>> Create([FromBody] CreateExpertiseDto dto)
    {
        try
        {
            if (dto.HazardCategory != null && dto.HazardCategory.Length > 100)
            {
                return BadRequest("��������� ��������� �� ������ ��������� 100 ��������");
            }

            var expertise = new Expertise
            {
                Status = dto.Status,
                Date = dto.Date ?? DateTime.UtcNow,
                Message = dto.Message,
                Comment = dto.Comment,
                IdObject = dto.IdObject,
                IdFile = dto.IdFile,
                IdNode = dto.IdNode,
                Image = dto.ImageBase64 != null ? Convert.FromBase64String(dto.ImageBase64) : null,
                Document = dto.DocumentBase64 != null ? Convert.FromBase64String(dto.DocumentBase64) : null,
                DocumentFileName = dto.DocumentFileName,
                HazardCategory = dto.HazardCategory
            };

            _context.Expertises.Add(expertise);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByObject), new { idObject = expertise.IdObject }, expertise);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest($"������ ����������: {ex.InnerException?.Message}");
        }
        catch (FormatException)
        {
            return BadRequest("������������ ������ ����������� ��� ��������� (��������� Base64)");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}