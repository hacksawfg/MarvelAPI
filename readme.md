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
* [Updating Entities](#updating-items)
* [JSON Structure](#example-json-structures)

---
## Technologies
* .NET SDK Version 5 - latest minor
* dotnet-ef Version 6.0.1
* MSSQL
---

## Launch
1. `git clone https://github.com/hacksawfg/MarvelAPI`
2. `dotnet-ef database update -p Marvel.Data/ -s Marvel.WebAPI/` (NOTE - this is bash command structure, PowerShell may look slightly different)
3. `dotnet run --project Marvel.WebAPI`
---
## Other Information
There are four different controllers utilized in this application, each containing the associated list of endpoints in the current version:
* **Movie** 
    * Create a new movie
    * List all movies 
    * Get details on a movie by unique ID 
    * Update a movie
    * Delete a movie
*  **MarvelCharacter** 
    * Create a character
    * List all characters 
    * Get details on a character by unique ID
    * Update a character
    * Associate a character with a movie
    * Delete a character
* **Team** 
    * Create a team
    * List all teams
    * Get team details by unique ID
    * Get team details by team name
    * Update a team
    * Associate a character with a team
    * Associate a character with a movie
    * Delete a character
* **CastCrew**
    * Create a cast/crew member
    * List all cast and crew members
    * Get cast/crew details via unique ID
    * Get cast/crew details via name 
    * Update a cast/crew member
    * Associate a cast/crew member to a movie
    * Associate a cast/crew member to a character
    * Delete a cast/crew member

---

## Movie Endpoints

### Base URL
`www.examplehost.com/api/Movie`

### Create a movie
* URL - {baseURL}/Create

### List All Movies
* URL - {baseURL}/List

### Get Movie Details By Id
* URL - {baseURL}/List/{movieId}

### Update Movie
* URL - {baseURL}/Update

### Delete Movie By Id
* URL - {baseURL}/Delete

---

## Team Endpoints

### Base URL
`www.examplehost.com/api/Team`

### Create Team
* URL - {baseURL}/Create

### List all Teams
* URL - {baseURL}/List

### Get Team Details by ID
* URL - {baseURL}/Get/{teamId}

### Get Team Details By Name
* URL - {baseURL}/Find
* Form data (x-www-form-urlencoded) Key: name, Value {TeamName}

### Update Team
* URL - {baseURL}/Update/{teamId}

### Associate Team with Character
* URL - {baseURL}/AddToCharacter/{teamId}

### Associate Team with Movie
* URL - {baseURL}/AddToMovie/{teamId}

### Delete Team
* URL - {baseURL}/Delete/{teamId}

---

## Character Endpoints



## Listing Items - Complete List, or by ItemId

Utilizing the same controllers listed above with http GET requests, the URL to pull a complete list of movies is as follows:

    {baseUrl.com}/api/Movie/List


To get a specific item, append the request with the integer value of the index, as below

    {baseUrl.com}/api/Movie/List/1


---

## Updating Items

Updating items utilize raw JSON in the http PUT request to update information utilizing the following URL structure

    {baseUrl.com}/api/Movie/Update

Example JSON Structure
```
{
    "movieId": 1,
    "movieName": "Iron Man",
    "releaseDate": "0001-01-01T00:00:00",
    "movieBoxOfficeUSD": 1,
    "movieDirector":"Jon Favreau",
    "movieTeams": null,
    "movieCharacters": null
}
```

---
## Deleting Items
Deleting an item utilizes the integer index in combination with an http DELETE request to remove an item from the database table.  Example URL structure as below:

    {baseUrl.com}/api/Movie/Delete/1


---

## Example JSON Structures

Movie
* Required fields - movieId, movieName
* Optional fields information
    * releaseDate format (YYYY-MM-DDThh:mm:ss)
    * movieBoxOffice - double to facilitate using exponents in value (i.e. 1.214e9)
    * movieTeams, movieCharacters are populated & edited from other tables


```
{
    "movieId": 1,
    "movieName": "Iron Man",
    "releaseDate": "2008-05-02T00:00:00",
    "movieBoxOfficeUSD": 1.214e9,
    "movieDirector":"Jon Favreau",
    "movieTeams": null,
    "movieCharacters": null
}
```
Team
* Required fields - teamId, teamName
* Optional fields information
    * releaseDate format (YYYY-MM-DDThh:mm:ss)
    * movieBoxOffice - double to facilitate using exponents in value (i.e. 1.214e9)
    * movieTeams, movieCharacters are populated & edited from other tables

```
{
    "teamId": 1,
    "teamName":"Avengers",
    "leader":"Captain America"
}
```

Character
* Required fields - 
* Optional fields information
    * a
```
{
    
}
```


CastCrew
* Required fields - name, role, ImdbPage
* Optional fields information
    * birthday format (YYYY-MM-DDThh:mm:ss)
    * movies pulled from separate table
```
{
    "name":"Jon Favreau",
    "role":"Happy Hogan",
    "birthday":"1966-10-19T00:00:00",
    "ImdbPage":"https://www.imdb.com/name/nm0269463/",
    "movies":null
}
```



---
Team Members
* Dan Ficklin
* Alan Murugan
* Findley Griffiths
* Jon Yoli