package main

import (
	"context"
	"fmt"
	"log"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"net/http"
)

const uri = "mongodb://my_reader:my_password@mongo:27017/?authSource=my_db"

type LotteryResult struct {
    Numbers string
}

func main() {

	serverAPI := options.ServerAPI(options.ServerAPIVersion1)
	opts := options.Client().ApplyURI(uri).SetServerAPIOptions(serverAPI)
	

	// Create a new client and connect to the server
	client, err := mongo.Connect(context.TODO(), opts)

	if err != nil {
		panic(err)
	}
	defer func() {
		if err = client.Disconnect(context.TODO()); err != nil {
			panic(err)
		}
	}()

	fmt.Println("You successfully connected to MongoDB!")
	collection := client.Database("my_db").Collection("lottery_collection")

	//filter := bson.D{{"latest", "1, 2, 3"}}

	http.HandleFunc("/", func(w http.ResponseWriter, r *http.Request) {
        //fmt.Fprintf(w, "Hello, World!")
		var result bson.M
		options := options.FindOne().SetSort(bson.M{"$natural": -1})

		err = collection.FindOne(context.TODO(), bson.D{}, options).Decode(&result)
		if err != nil {
			log.Fatal(err)
		}

		fmt.Fprintf(w, "Latest entry: %+v\n", result)
    })

	log.Fatal(http.ListenAndServe(":8080", nil))
}
