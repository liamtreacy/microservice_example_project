db.createUser({
    user: 'pastime',
    pwd: 'pastime123',
    roles: [
      {
        role: 'readWrite',
        db: 'pastime'
      }
    ]
  })