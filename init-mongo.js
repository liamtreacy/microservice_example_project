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

db.createUser({
  user: 'my_reader',
  pwd: 'my_password',
  roles: [
    {
      role: 'read',
      db: 'my_db'
    }
  ]
})
