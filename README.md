# BackgroundScrutor

Redis caching decorating with scrutor.

# To test using docker

`
docker run -p 6379:6379 --name redis-master -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
`
