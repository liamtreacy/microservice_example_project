# Use the official Golang image as the base image
FROM golang:latest

# Set the working directory to /app
WORKDIR /app

# Copy the current directory contents into the container at /app
COPY . /app

# Download and install any required dependencies
RUN go mod download

RUN go get go.mongodb.org/mongo-driver/mongo

# Build the Go program
RUN go build -o main .

# Expose port 8080 for the application
EXPOSE 8080

# Run the Go program when the container starts
CMD ["./main"]
