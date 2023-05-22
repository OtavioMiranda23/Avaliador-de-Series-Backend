using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class SerieController : ControllerBase
{
    private SerieContext _context;
    private IMapper _mapper;
    
    public SerieController(SerieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSerie([FromBody] CreateSerieDto serieDto)
    {
        Serie serie = _mapper.Map<Serie>(serieDto);
        _context.Series.Add(serie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaById), new { id = serie.Id }, serie);


    }
    
    [HttpGet]
    public IEnumerable<ReadSerieDto> RecuperaSerie([FromQuery] int skip = 0, [FromQuery]int take = 10)
    {
        return _mapper.Map<List<ReadSerieDto>>(_context.Series.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaById(int id)
    {
        var serie = _context.Series
            .FirstOrDefault(serie => serie.Id == id);
        if (serie == null) return NotFound();
        var serieDto = _mapper.Map<ReadSerieDto>(serie);
        return Ok(serieDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaSerie(int id, [FromBody] UpdateSerieDto serieDto)
    {
        var serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
        if (serie == null) return NotFound();
        _mapper.Map(serieDto, serie);
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult AtualizaSerieParcial(int id, JsonPatchDocument<UpdateSerieDto> patch)
    {
        var serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
        if (serie == null) return NotFound();

        var serieParaAtualizar = _mapper.Map<UpdateSerieDto>(serie);
        patch.ApplyTo(serieParaAtualizar, ModelState);
        if (!TryValidateModel(serieParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(serieParaAtualizar, serie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaSerie(int id)
    {
        var serie = _context.Series.FirstOrDefault(serie => serie.Id == id);
        if (serie == null) return NotFound();
        _context.Remove(serie);
        _context.SaveChanges();
        return NoContent();

    }
}