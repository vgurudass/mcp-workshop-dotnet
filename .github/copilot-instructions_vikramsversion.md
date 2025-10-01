# Copilot Instructions for MCP Workshop (.NET)

## Project Overview
- This repo is a workshop for building a to-do list MCP server and a Blazor MCP client, designed to run both locally and on Azure (Container Apps).
- The `/start` directory is the initial scaffold; `/complete` contains the full reference implementation.
- The main server is in `src/McpTodoServer.ContainerApp` and the client in `src/McpTodoClient.BlazorApp`.

## Architecture & Data Flow
- **MCP Server**: ASP.NET Core app exposing MCP tools via `/mcp` endpoint. Uses in-memory SQLite DB (see `Program.cs`).
- **MCP Client**: Blazor Server app, connects to MCP server using SSE transport (see `Program.cs`).
- **Communication**: Client and server communicate via the MCP protocol over HTTP/SSE.
- **Containerization**: Dockerfile at `/complete/Dockerfile` builds the server for local or Azure deployment.
- **Azure Integration**: `azure.yaml` configures deployment to Azure Container Apps using Azure Developer CLI (`azd`).

## Developer Workflows
- **Build/Run Locally**:
  - Server: `dotnet run --project ./src/McpTodoServer.ContainerApp`
  - Client: `dotnet watch run --project ./src/McpTodoClient.BlazorApp`
- **Run in Docker**:
  - Build: `docker build -t mcp-todo-list:latest .`
  - Run: `docker run -d -p 8080:8080 --name mcp-todo-list mcp-todo-list:latest`
- **Deploy to Azure**:
  - Login: `azd auth login`
  - Deploy: `azd up`
- **MCP Inspector**: Use `npx @modelcontextprotocol/inspector node build/index.js` to inspect and test MCP endpoints.

## Project Conventions & Patterns
- **Service Registration**: All services and DB context are registered in `Program.cs` using dependency injection.
- **MCP Tool Discovery**: Server auto-discovers tools via `.WithToolsFromAssembly()`.
- **Configuration**: Client expects OpenAI/GitHub model config in `appsettings.json` (see `Program.cs`).
- **Endpoints**: Default server endpoint is `http://localhost:5242/mcp` (change in client for container/remote scenarios).
- **Localization**: Docs and READMEs are localized under `/localisation/<lang>/`.

## Key Files & Directories
- `/complete/src/McpTodoServer.ContainerApp/Program.cs` — Server setup, DB, MCP endpoint
- `/complete/src/McpTodoClient.BlazorApp/Program.cs` — Client setup, model config, MCP connection
- `/complete/azure.yaml` — Azure deployment config
- `/complete/Dockerfile` — Container build for server
- `/docs/` — Step-by-step workshop instructions

## Tips for AI Agents
- Always check `/complete` for canonical patterns and full implementations.
- When updating endpoints or ports, ensure both client and server are aligned.
- Use the provided Dockerfile and `azure.yaml` for deployment scenarios.
- For new tools or endpoints, register them in the server's `Program.cs`.
- Use the MCP Inspector for protocol-level debugging and tool discovery.

---

If any section is unclear or missing, please request clarification or more details from the maintainers.
