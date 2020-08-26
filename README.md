# HobbyHall
Sample application that allow users to list their favorite hobbies.

## Project Structure
   - docker-compose: Contains the docker-compose.yaml file with declarative instructions on how to set up a running 
   docker environment
   - HobbyHall.Api: Web Api project containing the following Components: 
     * Controllers
     * Models
     * Repositories
   - HobbyHall.Api.Tests: Contains some sample unit tests.

## Minimun Requirements:

* Asp.net core 3.1
* Docker >= 19.03.8
* Mongo >= 3.2.22
* docker-compose >= 1.25.4
* git

## Running the Project:
1. Clone this repository by running:
```git clone https://github.com/dalcantara/HobbyHall.git```
2. Change directories to the where you cloned the repository
3. From the solution directory run:
```docker-compose up``` from the command line.
4. Verify the environment was initialized successfully by executing:
```docker ps```
from the command line.

## Accessing the Api
The quickest way to access the existing API is navigating the [SwagerUI](https://swagger.io/tools/swagger-ui/).  To do so type the following 
address in a Browser: [http://localhost:5001/swagger/index.html](http://localhost:5001/swagger/index.html).  
From there you should be able to execute sample requests against a live version of the API.

##Refactoring Notes:
Due to time constraints here are some things that 

1. The current User model though it reflects the correct Aggregate root, it serves multiple purposes. Currently, that model represents
web messages (data on the wire), a potential view model since it has DataAnnotations, as well as the data entities stored in the mongoDB. A better 
approach would've been to create separate models for each concern and map them using a tool like: [https://automapper.org/](https://automapper.org/);
2. Currently there's no request validation. In future versions we would implement an unobtrusive validation mechanism like this: [https://fluentvalidation.net/](https://fluentvalidation.net/)
3. I did not have time to implement a SPA client to this application hence the I wasn't able to implement an Identity Provider integration.
However, I recently implemented SSO integration at Best Buy and can speak about that experience.  Otherwise, I can submit another version tonight
with OpenId integration to google.
4. The unit tests are only there to demonstrate my ability to write isolated unit test.  The project definitely needs additional (unit and integration) tests.
