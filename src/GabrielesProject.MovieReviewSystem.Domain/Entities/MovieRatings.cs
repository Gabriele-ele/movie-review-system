using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielesProject.MovieReviewSystem.Domain.Entities;

public class MovieRatings
{
    public int Id { get; set; }

    public int Movie_id { get; set; }

    public int Rating { get; set; }
}
