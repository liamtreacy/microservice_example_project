# Random Number Generator

This project sends a rabbitmq message containing a random number at regaular intervals.

The interval at which these are sent, and the lower and upper bounds for the random number generation are defined in the `Dockerfile`.

## Requirements

- Docker
- Python (to run tests locally)

## Usage

To run tests

`./build.sh`

To bring up the system

`docker-compose up`

## Known issues


## TODO

A proper callback to see when the exchange is up (currently the program sleeps for 15 secs before attempting to send first message)
  
