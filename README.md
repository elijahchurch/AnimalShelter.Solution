#  Animal Shelter API

#### By: Jason Elijah Church

#### An Api that allows the user to make calls into an Animal Shelter database to access, create, edit or delete information on cats and dogs at the shelter.

## Technologies Used
* C#
* Markdown
* Git Bash
* Razor
* SQL
* MySQL Workbench
* Visual Code Studio
* .NET
* Postman

## Description/Endpoints:
The API for the animal shelter has various endpoints, but in order to make calls, a user must be authenticated and given a Json Web Token. To create a user, you can make a HTTPPost to this endpoint: http://localhost:5000/shelterapi/v1/users, and include this syntax in the body of the post: <br>
{<br>
    "username": [your username],<br>
    "password": [your password],<br>
    "emailaddress": [your chosen email]<br>
}
<br>
<br>
After this is done, you can then make a POST to http://localhost:5000/gettoken with the same user information included in the body of the post. This endpoint has logic to check if the user information posted matches a user in the database and will generate a JWT if it does. The JWT will appear in the response for the call, and you will need to copy it. When making API calls for the shelter, go into the authorization tab in Postman, for "Type" select "Bearer token", and past the JWT into the token box. 
<br>
Note: A test user was seeded in the database, and you can post its information into the body for the /gettoken POST to skip creating a user. Here is what the post would look like:<br>
{<br>
    "username": "TestUser",<br>
    "password": "Test",<br>
    "emailaddress": "TestUser@gmail.com"<br>
}
<br>
These are the various endpoints for the animal shelter API:

* GET http://localhost:5000/shelterapi/v1/dogs <br>
--> Receive a JSON response of all dog entries in the database
* GET http://localhost:5000/shelterapi/v1/dogs/{id}<br>
--> Receive information for one dog by locating it with its id #, which is added as the variable {id} at the end of this URL.
* POST http://localhost:5000/shelterapi/v1/dogs<br>
--> Create a dog entry in the database. You will need to include information for the dog in this syntax in the body of this POST:<br>
{<br>
    "name": "DOG-NAME",<br>
    "gender": "DOG-GENDER",<br>
    "age": "DOG-AGE",<br>
    "personality": "DOG-PERSONALITY",<br>
    "healthSocialNeeds": "DOG-NEEDS"<br>
}
<br>

* PUT http://localhost:5000/shelterapi/v1/dogs/{id}
--> Edit the information for a dog entry in the database. Take note, that you will need to pass in its {id} into the URL and include it in the body. Here as an example of what should be included in the body:<br>
{<br>
    "dogid" : {id}<br>
    "name": "DOG-NAME",<br>
    "gender": "DOG-GENDER",<br>
    "age": "DOG-AGE",<br>
    "personality": "DOG-PERSONALITY",<br>
    "healthSocialNeeds": "DOG-NEEDS"<br>
}
<br>

* DELETE http://localhost:5000/shelterapi/v1/dogs/{id}
--> Deletes a dog entry from the database. {id} as a variable stand in for the ID of the dog in the databse and is added to the end of the URL.

* GET http://localhost:5000/shelterapi/v1/cats <br>
--> Receive a JSON response of all cat entries in the database
* GET http://localhost:5000/shelterapi/v1/cats/{id}<br>
--> Receive information for one cat by locating it with its id #, which is added as the variable {id} at the end of this URL.
* POST http://localhost:5000/shelterapi/v1/cats<br>
--> Create a cat entry in the database. You will need to include information for the cat in this syntax in the body of this POST:<br>
{<br>
    "name": "CAT-NAME",<br>
    "gender": "CAT-GENDER",<br>
    "age": "CAT-AGE",<br>
    "personality": "CAT-PERSONALITY",<br>
    "healthSocialNeeds": "CAT-NEEDS"<br>
}
<br>

* PUT http://localhost:5000/shelterapi/v1/cats/{id}
--> Edit the information for a cat entry in the database. Take note, that you will need to pass in its {id} into the URL and include it in the body. Here as an example of what should be included in the body:<br>
{<br>
    "catid" : {id}<br>
    "name": "CAT-NAME",<br>
    "gender": "CAT-GENDER",<br>
    "age": "CAT-AGE",<br>
    "personality": "CAT-PERSONALITY",<br>
    "healthSocialNeeds": "CAT-NEEDS"<br>
}
<br>

* DELETE http://localhost:5000/shelterapi/v1/cats/{id}
--> Deletes a cat entry from the database. {id} as a variable stand in for the ID of the cat in the databse and is added to the end of the URL.

With version 2.0, query string parameters can be added to the end of a GET request for either dogs or cats to have a more specified search. A single query can be made by adding a ? to the end of a get request with the paramater name set equal to your search query. Multiple parameters can be added at once by putting a & between each paramater.<br>
An example of a single parameter query: GET http://localhost:5000/shelterapi/v2/cats?name=Garfield<br>
An example of a multiple paramater query: GET http://localhost:5000/shelterapi/v2/cats?name=Garfield&gender=male<br>
Note that v2 needs to be specified in the URL instead of v1, because version 1.0 of this API does not support string queries.<br>
This table represents the various queries you can make:
| Parameter | Description |
|:----------|:------------|
|Name       |Returns all entries matching the name entered|
|Gender     |Returns all entries matching the specified gender|
|Age        |Returns all entries matching the exact age entered|
|MinAge     |Returns all entries equal to or higher than the minimun age entered |
|MaxAge     |Returns all entries equal to or lower than the maximum age entered |
|Personality | Returns all entries that contain the specified word in their personality description|


## Setup/ Installation Requirements

1. Clone this repo.
2. Open your terminal (e.g. Terminal or GitBash) and navigate to this project's production directory called "ShelterApi" and create a new file called appsettings.json.
3. Within the appsettings.json file, add this line of code: { "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter_database;uid=[your user id];pwd=[your password];"}}
4. Additionally in the appsettings.json, you should set JWT settings as follows:  
"Jwt": {
    "Issuer": "http://localhost:5000",
    "Audience": "http://localhost:5000",
    "Key": "SecretKey9999999999"
  }
5. To recreate the database on your local machine, run the command "dotnet ef database update".
5. While in the production folder of this application ("ShelterApi"), in the command line, run the command "dotnet run" to compile and execute the application.
6. Test API calls for various endpoints in Postman. 

## Known Bugs
I have not thoroughly tested if all call methods throw any errors due to versioning, so some bugs may exist.


## License

MIT License

Copyright (c) (2023) Jason Elijah Church

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.