# Squares API Solution

Hi. This is my solution to Squares exercise written by [m0d7](https://github.com/m0d7). The exercise itself can be found [here](https://github.com/m0d7/squares-api-exercise?fbclid=IwAR0wnrKwrzojCN1Pa3LSwTR7NpW_Mh2rrp-snnvev8SwX25u1Afj-8aeN1s).

## Ok... How to run it?

### Prerequisites

- Docker Engine installed on local system.

### Steps to launch

- Clone the repository
- Create `.env` file in the root directory of this repository and specify the connection string (example can be found there named as `.env.example`). Contents example:
  ```
  POSTGRES_USER=exampleUser
  POSTGRES_PASSWORD=examplePassword
  POSTGRES_DB=exampleDatabase
  CONNECTION_STRING=Server=db;Port=5432;Database=exampleDatabase;User Id=exampleUser;Password=examplePassword;
  PGADMIN_DEFAULT_EMAIL=admin@example.com
  PGADMIN_DEFAULT_PASSWORD=password
  ```
- Open up `docker-compose.yml` file
- Map port 80 of `api` service inside a container to any open port on your device
- Make sure `web` service port mapping are not targeting an already used port on your device
- Navigate to the root folder of repository in a terminal.
- Run `docker-compose build` commmand
- Run `docker-compose up` commmand
- Open `http://localhost:{configured_port}/swagger` in a browser to access Swagger documentation of an API.
- You cal also check the background processes through `localhost:{configured_port}/hangfire`

### If you haven't changed ports here are the default URLs :)

- http://localhost:8085/swagger

- http://localhost:8085/hangfire
