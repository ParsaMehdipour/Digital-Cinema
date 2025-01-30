# 🎬 Digital Cinema

Welcome to **Digital Cinema**! This platform offers a seamless movie discovery and ticket booking experience, complete with the latest movie releases and trailers.

---

## 🚀 Features

✅ **Latest Movie Releases** – Stay up to date with newly added movies.<br>
✅ **Watch Trailers** – Preview upcoming and current movies.<br>
✅ **Book Tickets** – A smooth and user-friendly ticket reservation system.<br>
✅ **Advanced Search** – Powered by **ElasticSearch** for lightning-fast results.<br>

---

## 🏗 Project Structure

The solution follows **Domain-Driven Design (DDD)** principles, ensuring scalability and maintainability.

📂 **0.SharedKernel** – Common utilities and shared components.<br>
📂 **1.Domain** – Core business logic and domain entities.<br>
📂 **2.Application** – Application-specific logic and use cases.<br>
📂 **3.Persistence** – Database interactions and repository implementations.<br>
📂 **4.Infrastructure** – External services and infrastructure components.<br>
📂 **5.WebApi** – RESTful API endpoints for interacting with the system.<br>

---

## 🔧 Tech Stack

- **ElasticSearch** – Fast and efficient searching.
- **PostgreSQL** – Reliable and scalable database.
- **Docker** – Containerization for streamlined development and deployment.

---

## 📖 Getting Started

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/ParsaMehdipour/Digital-Cinema.git
cd Digital-Cinema
```

### 2️⃣ Set Up Environment Variables

Ensure that all required environment variables (e.g., database connection strings, ElasticSearch settings) are properly configured.

### 3️⃣ Run with Docker Compose

```bash
docker-compose up
```

This will start PostgreSQL, ElasticSearch, and other required services.

### 4️⃣ Apply Database Migrations

```bash
# Add the command for applying migrations (specific to your ORM)
```

### 5️⃣ Start the Application

```bash
# Add the command to run the Web API
```

### 6️⃣ Access the API

Once running, the API will be accessible at: **`http://localhost:5000`** (or your configured port).

---

## 🤝 Contributing

We welcome contributions! To contribute:
1. **Fork** the repository.
2. **Create a feature branch**: `git checkout -b feature-name`
3. **Commit changes**: `git commit -m "Your message"`
4. **Push to GitHub**: `git push origin feature-name`
5. **Submit a pull request** 🎉

---

## 📜 License

This project is licensed under the **MIT License**. See the [LICENSE](https://github.com/ParsaMehdipour/Digital-Cinema/blob/master/LICENSE) file for details.

