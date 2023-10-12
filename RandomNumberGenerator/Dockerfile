# syntax=docker/dockerfile:1

FROM python:3.8-slim-buster

ENV DELAY_LOOP_SECONDS=5
ENV LOWER_BOUND=1
ENV UPPER_BOUND=100

WORKDIR /app

COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt

COPY . .

# lower, upper, interval(seconds)
CMD [ "python3", "main.py"]