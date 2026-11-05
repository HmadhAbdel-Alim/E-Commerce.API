# 🛒 E-Commerce Web API (.NET Core)

A RESTful E-Commerce Web API built with ASP.NET Core and Clean Architecture, covering authentication, product catalog, Redis-backed baskets, Stripe payments, and order management.


## 🏗️ Architecture & How It Works

The solution is split into distinct layers to enforce **Separation of Concerns (SoC)** and testability:
```
├── API (Controllers, Middlewares, Program.cs)
├── Application (Services, DTOs, Interfaces, Specifications)
├── Core / Domain (Entities, Enums, Business Rules)
└── Infrastructure (Data Context, Repositories, Redis, Stripe Integration)
```

### Key Modules & Workflow:
1. **Catalog & Products:** Efficient querying with filtering, sorting, search, and server-side pagination using the **Specification Pattern**.
2. **Redis-Powered Basket:** temporary in-memory storage for customer shopping baskets using **Redis**.
3. **Identity & Authentication:** Secure user management using **ASP.NET Core Identity** with JWT authentication tokens.
4. **Order Management & Shipping:** Automated price recalculations, order status tracking, and delivery method integration.
5. **Stripe Payment & Webhook Handling:** 
   - Generates/Updates Stripe PaymentIntents securely.
   - Listens to asynchronous **Stripe Webhooks** (`payment_intent.succeeded` & `payment_intent.payment_failed`) to update order states directly in the database.
6. **Global Error Handling:** Custom `ExceptionMiddleware` intercepts unhandled runtime exceptions and standardizes API response schemas.
7. **CORS Enabled:** configured for cross-origin integration with frontend clients (Angular/React).

---

## 🛠️ Tech Stack & Design Patterns

* **Framework:** ASP.NET Core Web API (.NET)
* **Data Access & Storage:** SQL Server, Entity Framework Core (Code First), Redis Caching
* **Payments:** Stripe API & Webhooks
* **Architectural & Design Patterns:** Clean Architecture, Repository Pattern, Unit of Work, Specification Pattern, Dependency Injection

---

## ⚙️ How to Setup & Run

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/HmadhAbdel-Alim/E-Commerce.API.git](https://github.com/HmadhAbdel-Alim/E-Commerce.API.git)
Configure App Settings:
Add your database connection strings, Redis host, and Stripe keys in appsettings.json:

JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=EcommerceDb;...",
    "Redis": "localhost"
  },
  "StripeSettings": {
    "SecretKey": "sk_test_...",
    "WhSecret": "whsec_..."
  }
}
Update Database:

Bash
dotnet ef database update --project Infrastructure --startup-project API
Run the Application:

Bash
dotnet run --project API
## 👨‍💻 Developer
**Hmadh Abdel-Alim Hmad**  
* Junior .NET Backend Developer  
* [LinkedIn Profile](https://www.linkedin.com/in/hmadh-abdel-alim-0a7974373) | [GitHub Profile](https://github.com/HmadhAbdel-Alim)
