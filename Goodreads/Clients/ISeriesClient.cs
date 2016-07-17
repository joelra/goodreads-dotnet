﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Goodreads.Models.Response;

namespace Goodreads.Clients
{
    /// <summary>
    /// The client class for the Series endpoint of the Goodreads API.
    /// </summary>
    public interface ISeriesClient
    {
        /// <summary>
        /// Get all the series an author has written.
        /// </summary>
        /// <param name="authorId">The author to fetch the list of series for.</param>
        /// <returns>A list of series written by the author.</returns>
        Task<IReadOnlyList<Series>> GetListByAuthorId(int authorId);
    }
}