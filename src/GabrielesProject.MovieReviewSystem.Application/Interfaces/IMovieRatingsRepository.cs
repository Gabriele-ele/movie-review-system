﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielesProject.MovieReviewSystem.Application.Interfaces;

public interface IMovieRatingsRepository
{
    public void GetRatings();

    public void UpdateRatings(int movieId, int ratingNumber);
}
