# Marvel Movie API

## Key Information

* There are four different controllers utilized in this application - **Movie**, **Character**, **Team**, and **CastCrew**.

* Updating (PUT) and creating (POST) methods use routing and raw JSON format for the data.

* Reading (GET) and deleting (DELETE) methods use routing to accomplish their tasks.

---
## Movie, Character, Team, Cast & Crew Creation

### URL structure

  The structure of the URL for the POST requests is as follows:

    {baseUrl.com}/api/{ControllerName}/Create

For example, to create a movie

    {baseUrl.com}/api/Movie/Create


---

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
Team Members
* Dan Ficklin
* Alan Murugan
* Findley Griffiths
* Jon Yoli