using FitLog.Api.Dtos;
using FitLog.Api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public IActionResult CreateExercise(CreateExerciseDto dto)
    {
        _exerciseService.CreateExercise(dto);
        return Ok(dto); 
    }
}
