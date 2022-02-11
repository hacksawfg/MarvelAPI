# Marvel Movie API

## Introduction
The Marvel API is designed to allow for the entry, retrieval, and editing of information on movies set in the Marvel universe.

---
## Table of Contents
* [Technologies](#technologies)
* [Launch](#launch)
* [Controller Information](#other-information)
* [Movie Endpoints](#movie-endpoints)
* [Team Endpoints](#team-endpoints)
* [Character Endpoints](#character-endpoints)
* [Cast/Crew Endpoints](#castcrew-endpoints)
* [JSON Structure](#example-json-structures)
* [Development Team](#team-members)

---
## Technologies & Software Utilized in Project Development
* .NET SDK Version 5 - latest minor
* dotnet-ef Version 6.0.1
* MSSQL
* Postman
* VS Code
* Azure Data Studio
* Docker Desktop
---

## Key Commands for Implementation
1. `git clone https://github.com/hacksawfg/MarvelAPI`
2. `dotnet-ef database update -p Marvel.Data/ -s Marvel.WebAPI/` (NOTE - this is bash command structure, PowerShell may look slightly different)
3. `dotnet run --project Marvel.WebAPI`
---
## Other Information
There are four different controllers utilized in this application, each containing the associated list of endpoints in the current version:
* **Movie** 
    * [Create a new movie](#create-a-movie)
    * [List all movies](#list-all-movies) 
    * [Get details on a movie by unique ID](#get-movie-details-by-id) 
    * [Update a movie](#update-movie)
    * [Delete a movie by Id](#delete-movie-by-id)
*  **MarvelCharacter** 
    * [Create a character](#create-character)
    * [List all characters](#list-all-characters) 
    * [Get details on a character by unique ID](#get-character-details-by-id)
    * [Update a character](#update-character)
    * [Associate a character with a movie](#associate-a-character-with-a-movie)
    * [Delete a character](#delete-character)
* **Team** 
    * [Create a team](#create-team)
    * [List all teams](#list-all-teams)
    * [Get team details by unique ID](#get-team-details-by-id)
    * [Get team details by team name](#get-team-details-by-name)
    * [Update a team](#update-team)
    * [Associate a team with a character](#associate-team-with-character)
    * [Associate a team with a movie](#associate-team-with-movie)
    * [Delete a character](#delete-character)
* **CastCrew**
    * [Create a cast/crew member](#create-castcrew-member)
    * [List all cast and crew members](#list-all-castcrew-members)
    * [Get cast/crew details via unique ID](#get-castcrew-details-by-id)
    * [Get cast/crew details via name](#get-castcrew-details-by-name) 
    * [Update a cast/crew member](#update-castcrew-information)
    * [Associate a cast/crew member to a movie](#associate-castcrew-with-a-movie)
    * [Associate a cast/crew member to a character](#associate-castcrew-with-a-character)
    * [Delete a cast/crew member](#delete-castcrew-member)

---

## Movie Endpoints

### Base URL
`www.examplehost.com/api/Movie`

### Create a movie
* URL - {baseURL}/Create
* JSON - Required field - movieName
```
{
    "movieName":"Spider-Man: Homecoming"
}
```

### List All Movies
* URL - {baseURL}/List

### Get Movie Details By Id
* URL - {baseURL}/List/{movieId:int}

### Update Movie
* URL - {baseURL}/Update
* JSON
```
{
    "movieId": 1,
    "movieName":"Iron Man",
    "releaseDate":"2008-05-02T00:00:01",
    "movieBoxOfficeUSD":"1.214B",
    "movieDirector":"Jon Favreau"
}
```

### Delete Movie By Id
* URL - {baseURL}/Delete

---

## Team Endpoints

### Base URL
`www.examplehost.com/api/Team`

### Create Team
* URL - {baseURL}/Create
* JSON - Required field - teamName
```
{
    "teamName":"YoungAvengers",
    "leader": "Iron Lad"
}
```

### List all Teams
* URL - {baseURL}/List

### Get Team Details by ID
* URL - {baseURL}/Get/{teamId}

### Get Team Details By Name
* URL - {baseURL}/Find
* x-www-form-urlencoded Data 
    * Key: name
    * Value: X-Force

### Update Team
* URL - {baseURL}/Update/{teamId}
* JSON
```
{
    "teamId": 2,
    "teamName": "X-Men",
    "leader": "Storm"
}
```

### Associate Team with Character
* URL - {baseURL}/AddToCharacter/{teamId}
* JSON - both fields require a value
```
{
    "teamId": 2,
    "characterId": 2
}
```

### Associate Team with Movie
* URL - {baseURL}/AddToMovie/{teamId}
* JSON - both fields require a value
```
{
    "teamId": 1,
    "characterId":1
}
```

### Delete Team
* URL - {baseURL}/Delete/{teamId}

---

## Character Endpoints

### BaseURL
`www.examplehost.com/api/MarvelCharacter`

### Create Character
* URL - {baseURL}/Create
* JSON - Required Field - name
```
{
    "name": "Spider-man"
}
```
### List All Characters
* URL - {baseURL}/List
### Get Character Details By Id
* URL - {baseURL}/GetById/{castCrewId}
### Update Character
* URL - {baseURL}/Update
* JSON
```
{
    "id":1,
    "name":"Iron Man",
    "nemesis":"Mandarin",
    "powers":"Money, intelligence",
    "gear":"Iron Man suits"
}
```
### Associate a Character with a Movie
* URL - {baseURL}/AddToMovie/{characterId}
*JSON - both fields require values
```
{
    "movieId": 2,
    "Id": 2
}
```
### Delete Character
* URL - {baseURL}/Delete/{characterId}

---

## Cast/Crew Endpoints

### Base URL
`www.examplehost.com/api/CastCrew`
### Create Cast/Crew Member
* URL - {baseURL}/Create
* JSON - Required Fields - name, role, imdbPage
```
{
    "name":"Chris Pratt",
    "role": "actor",
    "birthday":"1986-06-01T00:00:00",
    "imdbPage":"https://www.imdb.com"
}
```
### List All Cast/Crew Members
* URL - {baseURL}/List
### Get Cast/Crew Details By Id
* URL - {baseURL}/GetById/1
### Get Cast/Crew Details By Name
* URL - {baseURL}/GetByName
* x-www-form-urlencoded Data
    * Key - name
    * Value - Tom Holland
### Update Cast/Crew Information
* URL - {baseURL}/Update
* JSON
{
    "id":5,
    "name":"Chris Pratt",
    "role":"Actor",
    "imdbPage":"www.imdb.com"
}
### Associate Cast/Crew with a Character
* URL - {baseURL}/SetActorToCharacter
* JSON - both fields require values
```
{
    "castCrewId": 3,
    "marvelCharacterId": 2
}
```
### Associate Cast/Crew with a Movie
* URL - {baseURL}/AddToMovie/{castCrewId}
* JSON - both fields require values
```
{
    "movieId": 2,
    "castCrewId": 1
}
```
### Delete Cast/Crew Member
* URL - {baseURL}/Delete/{castCrewId}

---
## Team Members
* Dan Ficklin
* Alan Murugan
* Findley Griffiths
* Jon Yoli