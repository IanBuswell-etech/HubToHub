echo Running docker compose on MiniHub
@echo off
cd "d:/programs/docker toolbox/"
docker-compose -f d:/projects/etech/hubtohub/minihub/docker-compose.yml up
pause