#!/bin/sh

until dotnet ef database update --project Infrastructure --startup-project API; do
    echo "Waiting for database to be ready..."
    sleep 5
done

exec dotnet API.dll