# 1. docker build -f CoOp19Mvc.Dockerfile -t rest-reviews:3.0 ../../nick-project1
# 2. docker run --rm -it -p 8000:80 -e "ConnectionStrings__CoOp19Db=(connection string)" rest-reviews:3.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

# when docker goes through a dockerfile's steps, it keeps track of all the "inputs"
# to each given line.
COPY *.sln ./
COPY CoOp19.App/*.csproj CoOp19.App/
COPY CoOp19.Lib/*.csproj CoOp19.Lib/
COPY CoOp19.Dtb/*.csproj CoOp19.Dtb/
COPY CoOp19.Test/*.csproj CoOp19.Test/

RUN dotnet restore

# so long as the csproj/sln files haven't changed, we'll always cache up to this point.
# saves on build time!

# now copy everything else so we can build
COPY . ./


RUN dotnet publish CoOp19.App -o publish --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build /app/publish ./

CMD [ "dotnet","CoOp19.App.dll" ]
