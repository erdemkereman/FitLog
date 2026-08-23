using FitLog.Api.Dtos;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitLog.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ExercisesController: ControllerBase
{    
    private readonly IExerciseService  _exerciseService;

    public ExercisesController(IExerciseService  exerciseService)
    {
        _exerciseService = exerciseService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateExercise(CreateExerciseDto dto)
    {
        await _exerciseService.CreateExerciseAsync(dto);
        return Ok(dto); 
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExercisesAsync()
    {
      List<ExerciseDto> exercises= await _exerciseService.GetAllExercisesAsync();
        return Ok(exercises);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExerciseByIdAsync(int id)
    {
        ExerciseDto? exerciseDto= await _exerciseService.GetExerciseByIdAsync(id);
        if (exerciseDto == null)
        {
            return NotFound();
        }
        return Ok(exerciseDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExerciseAsync([FromRoute] int id, [FromBody] UpdateExerciseDto dto)
    {
        bool isUpdated = await _exerciseService.UpdateExerciseAsync(id, dto);

        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }
   
}
