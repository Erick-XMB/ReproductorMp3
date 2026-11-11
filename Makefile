all: back front runFront

back: 
	dotnet build src/back/back.csproj

runBack: 
	dotnet run --project src/back/back.csproj

limpiarBack:
	dotnet clean src/back/back.csproj

front:
	dotnet build src/front/vista/vista.csproj

runFront:
	dotnet run --project src/front/vista/vista.csproj

limpiarCliente:
	dotnet clean src/front/vista/vista.csproj

docs:
	docfx metadata documentos/documentacion/docfx.json
	docfx build documentos/documentacion/docfx.json

servidorDocs:
	docfx serve documentos/documentacion/_site

limpiarDocs:
	rm -rf documentos/documentacion/_site documentos/documentacion/api

clean:
	dotnet clean src/back/back.csproj
	dotnet clean src/front/vista/vista.csproj