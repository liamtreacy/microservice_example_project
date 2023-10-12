#!/bin/bash
echo "Running tests"
RandomNumberGenerator/venv/bin/python RandomNumberGenerator/rng_tests.py

echo "Building docker image"
cd RandomNumberGenerator
docker build --tag rng-docker .