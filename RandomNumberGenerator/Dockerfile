# syntax=docker/dockerfile:1

FROM python:3.8-slim-buster

WORKDIR /app

COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt

COPY . .

# lower, upper, interval(seconds)
CMD [ "python3", "main.py", "1", "100", "5"]