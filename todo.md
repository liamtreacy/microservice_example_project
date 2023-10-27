### Issues to be looked at

- [ ] Implement CI/CD (Github actions?)
- [ ] Push images somewhere... how to modify docker-compose to pull those if local build not wanted.
- [ ] Can we have integration/container level tests?
- [ ] How to debug a container? Need docs/how-to here.
- [ ] How does docker-compose determine (or not) that a change has occured in a component and therefore the a new image should be built?
- [ ] Can we have a dedicated place outside of services in the docker-compose file for shared variables? Or what is best practice.

- [ ] Remove startup sleep from the RandomNumberGenerator (there to wait for RabbitMq to startup). There must be a reconnect or something in [pika](https://pika.readthedocs.io/en/stable/)
- [ ] Add unit tests to docker build for RandomNumberGenerator. Investigate using [multi stage builds](https://docs.docker.com/build/building/multi-stage/) to ensure no tests are shipped in images.
- [ ] Review logging in RNG.
- [ ] Rename RNG (to lottery generator?)

- [ ] Review usage of exchanges and channels in RabbitMq e.g. should we not use the default exchange?
- [ ] Add new admin credentials for RabbitMq in docker-compose?

- [ ] DbPopulator, remove startup sleep for connection to RabbitMq
- [ ] DbPopulator, is the `while(true){ sleep(1000) }` on the main thread while listening on the background thread for incoming messages, the correct approach?
- [ ] Code tidy up and tests!
- [ ] DbPopulator, fix warnings.
- [ ] DbPopulator, is there docker image too big? Do we need to ship/publish as much we do?

- [ ] LatestResult, split into proper classes.
- [ ] Add unit tests.
- [ ] Use goformat (if not already applied somehow).
- [ ] Manage connection to db better (is it closed ok?)
- [ ] Better UI for results.
- [ ] Retrieve env vars from docker/env.

- [ ] Add more todos.
