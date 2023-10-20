db.createUser({
  user: 'my_user',
  pwd: 'my_password',
  roles: [
    {
      role: 'readWrite',
      db: 'my_db'
    }
  ]
})

db. pastime.insertOne({"first_key" : "first_val"})