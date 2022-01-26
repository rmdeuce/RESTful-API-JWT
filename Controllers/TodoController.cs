using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReastApiJwt.Data;

namespace ReastApiJwt.Models;

[Route("api/todo")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<Todo>>> Get([FromServices] DataContext context)
    {
        try
        {
            var todo = await context.Todos.AsNoTracking().ToListAsync();
            if (todo == null || todo.Count == 0)
                return NotFound(new { message = "Todo not found." });
            return Ok(todo);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Could not get Todo. Error: {ex.Message}" });
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Todo>> GetById([FromRoute] int id, [FromServices] DataContext context)
    {
        try
        {
            var todo = await context.Todos.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return NotFound(new { message = "todo not found." });
            return Ok(todo);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Could not get todo. Error: {ex.Message}" });
        }
    }

    [HttpPost]
    [Route("")]
    [Authorize]
    public async Task<ActionResult<Todo>> Post([FromBody] Todo model, [FromServices] DataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await context.Todos.AddAsync(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Could not create todo. Error: {ex.Message}" });
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Todo>> Put([FromRoute] int id, [FromBody] Todo model,
        [FromServices] DataContext context)
    {
        if (id != model.Id)
            return NotFound(new { message = "todo not found" });
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return BadRequest(new
                { message = $"Could not Update this Todo (Concurrency exception). Error: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Could not Update this Todo. Error: {ex.Message}" });
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<ActionResult<Todo>> Delete([FromRoute] int id, [FromServices] DataContext context)
    {
        try
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return NotFound(new { message = "product Not Found" });
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return Ok(new { message = "todo Removed" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Could not Delete this todo. Error: {ex.Message}" });
        }
    }
}