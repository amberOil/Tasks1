using FibonacciAndRobot.Models;
using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathFinderController : ControllerBase
    {
        [HttpPost]
        public IActionResult FindPaths(PathFinderInputModel inputModel)
        {
            int totalPaths = CalculateTotalPaths(inputModel.M, inputModel.N, inputModel.StartX, inputModel.StartY, inputModel.FinishX, inputModel.FinishY);
            return Ok(new PathFinderOutputModel { TotalPaths = totalPaths });
        }

        private int CalculateTotalPaths(int M , int N, int startX, int startY, int finishX, int finishY)
        {
            if (startX > finishX || startY > finishY)
                return 0;
            if (startX == finishX && startY == finishY)
                return 1;

            int rightPaths = CalculateTotalPaths(M, N, startX + 1, startY, finishX, finishY);
            int upPaths = CalculateTotalPaths(M, N, startX, startY + 1, finishX, finishY);

            return rightPaths + upPaths;
        }
    }
}