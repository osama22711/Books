# Essential Markdown Files for AI‑Augmented Development

A comprehensive reference for the Markdown files that keep your project
understandable to humans, to AI assistants, and to your future self.

---

## 1. File overview

| File                                 | Purpose                                                                 | Lifetime                         | AI Integration                                                          |
| ------------------------------------ | ----------------------------------------------------------------------- | -------------------------------- | ----------------------------------------------------------------------- |
| `README.md`                          | Project overview, setup, usage                                          | Whole project                    | Manual paste / automatically indexed                                    |
| `ARCHITECTURE.md`                    | High‑level design, components, data flow, key decisions                 | Long‑term (rarely changes)       | Manual paste, MCP resource, or auto‑inject                              |
| `CONTRIBUTING.md`                    | How to contribute, style guide, PR process                              | Long‑term                        | Manual paste, tool rules                                                |
| `CONTEXT.md` (or `DEVELOPMENT.md`)   | Current state: what’s being built, known issues, dependencies           | Sprint‑level (updated weekly)    | Manual paste at session start                                           |
| `memory.md`                          | Persistent AI preferences, conventions, immutable facts                 | Long‑term (occasionally updated) | Auto‑injected by tool (e.g. Cursor .cursorrules) or pasted with CONTEXT |
| `skills.md` (or `skills/` directory) | Reusable AI task templates (crud generator, security audit, etc.)       | Long‑term, grows over time       | Called as named skills or pasted on demand                              |
| `mcp.md`                             | Documentation for your MCP servers – what tools & resources they expose | Long‑term                        | Read by humans and AI to understand available MCP integrations          |
| `specs/`                             | Feature specifications (Gherkin, user stories)                          | Feature‑lifetime                 | Fed to AI as spec → code pipeline                                       |

---

## 2. How they fit together

### The hierarchy
```
README.md
│
├── ARCHITECTURE.md ← explains the big picture
├── CONTRIBUTING.md ← how we work
├── CONTEXT.md ← what’s happening right now
├── memory.md ← what the AI must always remember
├── skills.md / skills/ ← reusable AI workflows
├── mcp.md ← connections to live systems
└── specs/ ← feature definitions that become code
```


- **ARCHITECTURE.md** and **CONTRIBUTING.md** set the foundation. They rarely change.
- **CONTEXT.md** is the living, breathing snapshot – updated every sprint or whenever focus shifts.
- **memory.md** stores the AI’s “personality” and inviolable rules. It’s the layer between static docs and the current session.
- **skills.md** turns common prompts into repeatable building blocks. They often reference the other docs (e.g., “Use the Prisma models from ARCHITECTURE.md”).
- **mcp.md** documents live integrations that can, for example, auto‑fetch `ARCHITECTURE.md` or run a skill.
- **specs/** are the “order forms” – you hand them to the AI and get code back.

---

## 3. Deep dive into each file

### 3.1 `README.md`

**Purpose:** The front door. A new developer or AI should know what the project does, how to run it, and where to find everything else.

**Must contain:**
- One‑line description
- Quick‑start commands that actually work
- Links to all other core docs

**Example:**
```markdown
# ShopBackend – E‑commerce API

> Event‑driven microservices for an online store.

## Quick start
bash:
docker compose up -d
pnpm dev

## Docs
- Architecture
- Contributing
- AI Context
- AI Memory
```


---

### 3.2 `ARCHITECTURE.md`

**Purpose:** The technical blueprint. Explains components, data flow, and *why* things are built that way.

**Key sections:**
- Overview & boundaries
- C4 diagrams (Mermaid)
- Technology stack
- Key design decisions & trade‑offs
- Data flow (write/read paths)
- Deployment & scaling
- Risks & known limitations

**Best practices:**
- Update when major structural changes happen.
- Use Mermaid for diagrams (plain text, AI‑readable).
- One sentence per line for clean diffs.

---

### 3.3 `CONTRIBUTING.md`

**Purpose:** The rulebook for human and AI contributors.

**Must have:**
- Code style (naming, formatting, patterns)
- PR & review process
- Testing requirements
- Commit message format

**Tip:** The AI will follow these rules if you paste this file into its context or reference it in `memory.md`.

---

### 3.4 `CONTEXT.md` (or `DEVELOPMENT.md`)

**Purpose:** The here‑and‑now snapshot. Tells the AI what’s currently being built, what’s broken, and where to start.

**Contents:**
- Current sprint goals
- Known bugs & workarounds
- In‑progress refactors
- Key files to touch for specific features
- Dependencies that are temporarily pinned

**Refresh cadence:** After every planning session or major shift.

**Example:**
```markdown
# Current Context (Sprint 12)

## What we’re building
- Shopping cart service (new)
- Payment integration with Stripe

## Known issues
- Cart does not handle concurrent updates (race condition)
- `GET /products` is slow – will add caching this sprint

## Active branches
- `feature/cart-service` ← main development
- `fix/product-timeout` ← bug fix, almost ready to merge
```

### 3.5 `memory.md`
**Purpose**: The AI’s long‑term memory. It’s loaded automatically by some tools (e.g., Cursor’s `.cursorrules`) or pasted at session start with `CONTEXT.md`.

What goes here:
- Immutable tech stack (language, framework, database)
- Preferred coding patterns (e.g., “always use async/await”, “prefer functional components”)
- Naming conventions
- Personal preferences (“never use any”, “include docstrings for public functions”)
- References to other documents (“Always adhere to the style in CONTRIBUTING.md”)

Characteristics:
- **Stable** – change only when you permanently change a convention.
- **Concise** – bullet points, not prose.
- **Injected** – automatically if the tool supports it, otherwise manually.

**Example:**
```markdown
# AI Memory

## Stack (unchanging)
- TypeScript 5.x, Node 20 LTS, Express, Prisma, PostgreSQL

## Style
- Strict mode, no `any`, prefer `interface` for objects
- File names: kebab-case, named exports
- React: functional components, hooks only

## Conventions
- API routes in `src/routes/`, services in `src/services/`
- Always validate input with Zod
- Use HTTP status codes consistently (401 for unauth, 422 for validation)

## Permanent preferences
- Do not introduce new libraries without asking
- Never include secrets or environment values in generated code
- Always generate tests alongside new code
```

### 3.6 `skills.md` (or `skills/` directory)
**Purpose**: A library of reusable AI task definitions. Instead of re‑typing a complex prompt each time, you define a skill once and invoke it.

Structure of a skill:
- Name & description
- Input parameters
- Step‑by‑step instructions for the AI
- Expected output format

Example: `skills/generate-crud.md`
```markdown
# Skill: Generate CRUD

Creates full CRUD endpoints from a Prisma model.

## Input
- `modelName` (PascalCase)

## Instructions
1. Read the Prisma schema to find the model.
2. Generate a Zod validation schema.
3. Generate a service with `create`, `getAll`, `getById`, `update`, `delete`.
4. Generate an Express route handler that uses the service.
5. Write tests for all endpoints.

## Output
All files in a single Markdown code block, separated by file path comments.
```

Usage:
- “Using the generate-crud skill, create endpoints for the Product model.”
- Skills can be stored in a shared repo so the whole team uses the same quality‑checked templates.

Why they matter:
- Consistency – every CRUD is built the same way.
- Speed – no need to repeat instructions.
- Composability – combine skills (“generate CRUD, then run the security audit skill on it”).

### 3.7 `mcp.md`
**Purpose**: Documents the Model Context Protocol (MCP) servers available in the project. This tells both humans and AIs what live tools and resources can be accessed.

Contents:
- List of MCP servers with their purpose
- Resources they expose (e.g., project://architecture, db://schema)
- Tools they offer (e.g., run_tests, deploy_preview)
- Configuration example (the mcp.json snippet)

Example:
```markdown
# MCP Services

## Project Context Server
Provides project documentation and tools.

### Resources
- `project://architecture` – contents of ARCHITECTURE.md
- `project://context` – contents of CONTEXT.md
- `project://memory` – contents of memory.md

### Tools
- `run_tests` – executes `npm test` and returns the output
- `github_issue` – fetches a GitHub issue by number

### Configuration (Cursor)
```json
{
  "mcpServers": {
    "project-context": {
      "command": "node",
      "args": ["mcp-servers/project-context/index.js"]
    }
  }
}
```

**Why it matters:** MCP lets the AI actively fetch the latest docs, run tests, and interact with external systems – no more copy/pasting stale context. The `mcp.md` file is the human‑readable map to those capabilities.

---

### 3.8 `specs/` directory

**Purpose:** Feature specifications written before coding. They are the blueprint for AI‑generated implementation.

**Format:** Gherkin, user stories, or structured Markdown.

**Example:** `specs/shopping-cart.md`
```markdown
# Feature: Shopping Cart

As a customer, I want to add products to a cart so I can purchase them later.

## Scenarios
- **Add item to empty cart** → cart contains 1 item with correct quantity
- **Add same item twice** → quantity increments
- **Remove item** → item removed, cart total updated
- **Integration**: “Based on the spec specs/shopping-cart.md, generate the Express routes and tests.”
```

## 4. Practical file structure
```
my-project/
├── README.md
├── ARCHITECTURE.md
├── CONTRIBUTING.md
├── CONTEXT.md
├── memory.md
├── mcp.md
├── skills/
│   ├── generate-crud.md
│   ├── security-audit.md
│   └── release-notes.md
├── specs/
│   └── feature-xyz.md
└── .cursor/
    ├── rules          (Cursor’s own memory file – can mirror memory.md)
    └── mcp.json       (MCP server config)
```

## 5. Best practices for the whole set
1. **Version everything** – all these files live in Git right next to your code.
2. **Separate concerns** – stable rules in memory.md, volatile status in CONTEXT.md, reusable workflows in skills/.
3. **Link heavily** – memory.md points to CONTRIBUTING.md, ARCHITECTURE.md links to ADRs, etc.
4. **Test your AI context** – periodically ask the AI a question that should be answered by these files to verify they’re being loaded.
5. **Automate freshness** – CI can warn if CONTEXT.md hasn’t been updated when the sprint milestone changes, or if a new service appears without an ADR.
6. **One sentence per line** – for clean diffs across all docs.

## 6. The complete picture
- **Humans** read `README`, `ARCHITECTURE`, `CONTRIBUTING `to understand the project.
- **AI** reads `memory.md` for permanent rules, `CONTEXT.md` for the current situation, and `skills/` for how to perform common tasks.
- **MCP** bridges the gap, giving the AI live access to these documents and tools.
- **specs/** are the raw input that starts the vibe coding loop.

When all these Markdown files work together, you move from ad‑hoc prompting to a **structured, repeatable, and scalable AI‑assisted development workflow** – for solo projects and large enterprises alike.