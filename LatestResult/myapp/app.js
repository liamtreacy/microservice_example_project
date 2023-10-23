const express = require('express')
const MongoClient = require('mongodb').MongoClient;

const app = express()
const port = 8080

// maybe create a seperate user who can only read
// compare this url with the one in dotnet
const url = 'mongodb://my_reader:my_password@mongo:27017?authSource=my_db';

const dbName = 'my_db';

app.get('/', async (req, res) => {
  console.log("== Attempting to conenct");
  console.log(url);

  const client = new MongoClient(url);
let conn;
try {
  conn = await client.connect();

  const db = client.db(dbName);
      
  // Get the first document in the collection
  db.collection('my_collection').findOne({}, function(err, result) {
    if (err) throw err;
    client.close();
    res.send('Latest result: ' + JSON.stringify(result));
  });
} catch(e) {
  console.error(e);
}

/*
    MongoClient.connect(url, function(err, client) {
        if (err) throw err;
        console.log("== Connected successfully to server");
      
        const db = client.db(dbName);
      
        // Get the first document in the collection
        db.collection('my_collection').findOne({}, function(err, result) {
          if (err) throw err;
          client.close();
          res.send('Latest result: ' + JSON.stringify(result));
        });
      });*/
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})
