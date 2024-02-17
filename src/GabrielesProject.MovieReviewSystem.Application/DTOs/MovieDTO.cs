using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielesProject.MovieReviewSystem.Application.DTOs;

public class MovieDTO
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public decimal Rating { get; set; }

    public string? Comments { get; set; }
}
