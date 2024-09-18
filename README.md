# MovieSearchAPI

This API project is built using .NET Web API and offers methods for reading data from a manually created SQL Server database.

## Endpoints

The API provides two main functions:

1. **GetMovieByTitle**
   - **Description**: Returns all movies containing the word passed as a parameter.
   - **Endpoint**: `/api/movies/search?title={title}`
   - **Method**: `GET`
   - **Parameter**: `title` (string) – The word to search for in movie titles.
   - **Response**: A list of movies with matching titles, including fields like `Id`, `Title`, `Year`, `Type`, and `Poster`.

2. **GetMovieDetailsById**
   - **Description**: Returns detailed information about a movie by its unique movie ID.
   - **Endpoint**: `/api/movies/movie/{id}`
   - **Method**: `GET`
   - **Parameter**: `id` (int) – The unique ID of the movie.
   - **Response**: Detailed information about the movie, including attributes such as `Title`, `Year`, `Rated`, `Released`, `Runtime`, `Genre`, `Director`, `Actors`, and more.

## Database

The SQL Server database is manually created and structured to store movie data in a master/detail format, which includes:

- **Movies**: Stores basic movie information like `Id`, `Title`, `Year`, `Type`, and `Poster`.
- **MovieDetails**: Stores additional information about the movies, such as `Genre`, `Director`, `Plot`, and `imdbRating`.
- **MovieRatings**: Stores movie ratings from different sources.

## Database Set-Up
- Restore the `MoviesDB_Dea.bak` database.
- After restoring the database, update the connection string in your `appsettings.json` to point to the restored database.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server;Database=MoviesDB_Dea;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
   }
   ```
