# Squares API Solution

Hi. This is my solution to Squares exercise written by [m0d7](https://github.com/m0d7). The exercise itself can be found [here](https://github.com/m0d7/squares-api-exercise?fbclid=IwAR0wnrKwrzojCN1Pa3LSwTR7NpW_Mh2rrp-snnvev8SwX25u1Afj-8aeN1s).

### Prerequisites

- Docker Engine installed on local system.

### Steps to launch

- Clone the repository
  Navigate to the root folder of repository on your local machine
- Create .env file in this directory and specify connection string (example can be found there named as .env.example). Contents example:
  ```
  CONNECTION_STRING=YourConnectionStringGoesHere
  ```
- Open up `docker-compose.yml` file
- Map port 80 of `api` service inside a container to any open port on your device
- Make sure `web` service port mapping are not targeting an already used port on your device
- Navigate to the root folder of repository in a terminal.
- Run `docker-compose build` commmand
- Run `docker-compose up` commmand
- Open `localhost:{configured_port}/swagger` in a browser to access Swagger documentation of an API.
- You cal also check the background processes through `localhost:{configured_port}/hangfire`
